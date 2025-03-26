using MsacClient.Entities;
using MsacClient.Exceptions;
using MsacClient.XmlData;
using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MsacClient
{
    public class MsacConnection
    {
        public MsacConnection(MsacTransport transport)
        {
            this.transport = transport;
        }

        private readonly MsacTransport transport;

        private Task<HDRadioEnvelope> SendRequestGetResponse(HDRadioEnvelope request)
        {
            return SendRequestGetResponse(request, null, 0, 0);
        }

        private async Task<HDRadioEnvelope> SendRequestGetResponse(HDRadioEnvelope request, byte[] extra, int extraIndex, int extraLength)
        {
            //Set up empty namespace and settings  
            var settings = new XmlWriterSettings
            {
                Indent = false,
                OmitXmlDeclaration = true
            };
            var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            XmlSerializer ser = new XmlSerializer(typeof(HDRadioEnvelope));

            //Serialize to a string
            string xmlPayloadString;
            using (var stringWriter = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(stringWriter, settings))
                {
                    ser.Serialize(writer, request, ns);
                    xmlPayloadString = stringWriter.ToString();
                }
            }

            //Convert to bytes
            byte[] xmlPayload = Encoding.UTF8.GetBytes(xmlPayloadString);

            //Begin transaction
            byte[] rxBuffer = new byte[4096];
            int rxBufferRead = 0;
            using (IMsacTransportTransaction transaction = await transport.StartTransaction())
            {
                //Send the XML
                await transaction.SendAsync(xmlPayload, 0, xmlPayload.Length);

                //Send binary data, if specified
                if (extra != null)
                    await transaction.SendAsync(extra, extraIndex, extraLength);

                //Wait for response
                rxBufferRead = await transaction.ReadToEndAsync(rxBuffer, 0, rxBuffer.Length);
            }

            //Read recieved data as string
            string rxDataString = Encoding.UTF8.GetString(rxBuffer, 0, rxBufferRead);

            //Deserialize
            HDRadioEnvelope result;
            using (StringReader sr = new StringReader(rxDataString))
                result = (HDRadioEnvelope)ser.Deserialize(sr);

            //Do some basic validation
            if (result.MsacResponse == null || result.MsacResponse.ReturnString == null || result.MsacResponse.MsgInfo == null)
                throw new Exception("The MSAC response was invalid.");
            if (result.MsacResponse.ReturnString != "OK")
                throw new MsacBadStatusException(result.MsacResponse.ReturnString);
            if (request.MsacRequest != null && request.MsacRequest.MsgInfo != null && request.MsacRequest.MsgInfo.MsgType != null && result.MsacResponse.MsgInfo.MsgType != request.MsacRequest.MsgInfo.MsgType)
                throw new Exception($"The returned msg type \"{result.MsacResponse.MsgInfo.MsgType}\" did not match the one transmitted \"{request.MsacRequest.MsgInfo.MsgType}\".");

            return result;
        }

        /// <summary>
        /// Requests basic status from the MSAC.
        /// </summary>
        /// <returns></returns>
        public async Task<StatusInfo> RequestStatusAsync(string dataServiceName = "SLHD1")
        {
            //Create the request body
            HDRadioEnvelope req = new HDRadioEnvelope
            {
                MsacRequest = new MsacRequest
                {
                    MsgInfo = new MsgInfo
                    {
                        MsgType = "Status Request",
                        DataServiceName = dataServiceName
                    }
                }
            };

            //Send and get response
            HDRadioEnvelope response = await SendRequestGetResponse(req);

            //Wrap info
            return new StatusInfo
            {
                MsacOS = response.MsacResponse.MsacOS,
                MsacVersion = response.MsacResponse.MsacVersion,
                LotId = response.MsacResponse.LotInfo != null ? response.MsacResponse.LotInfo.LotId : null
            };
        }

        /// <summary>
        /// Sends a PSD update.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public Task SendPSDAsync(PsdSendBuilder psd, string exportAddress, string audioChannel = "HD1")
        {
            //Validate
            if (psd == null)
                throw new ArgumentNullException(nameof(psd));
            psd.Validate();

            //Build and send
            return SendPSDAsync(psd.Psd, exportAddress, audioChannel);
        }

        /// <summary>
        /// Sends a PSD update.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task SendPSDAsync(PsdFields psd, string exportAddress, string audioChannel = "HD1")
        {
            //Validate request
            if (psd == null)
                throw new ArgumentNullException(nameof(psd));
            if (exportAddress == null)
                throw new ArgumentNullException(nameof(exportAddress));
            if (audioChannel == null)
                throw new ArgumentNullException(nameof(audioChannel));

            //Create the request body
            HDRadioEnvelope req = new HDRadioEnvelope
            {
                MsacRequest = new MsacRequest
                {
                    MsgInfo = new MsgInfo
                    {
                        MsgType = "PSD Send",
                        InputFormat = "xml",
                        OutputFormat = "hdp",
                        Protocol = "udp",
                        Location = exportAddress,
                        AudioProgram = audioChannel
                    },
                    PsdFields = psd
                }
            };

            //Send and get response (any errors would be caught in the validation)
            await SendRequestGetResponse(req);
        }

        /// <summary>
        /// Directly uploads a file to the server.
        /// </summary>
        /// <param name="filename">The destination filename.</param>
        /// <param name="buffer">Buffer to read from.</param>
        /// <param name="index">Index within the buffer to read from.</param>
        /// <param name="count">Number of bytes in the buffer.</param>
        /// <returns></returns>
        public async Task FileCopyDirectAsync(string filename, byte[] buffer, int index, int count)
        {
            //Validate
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index + count > buffer.Length || index < 0 || count < 0)
                throw new ArgumentException("Buffer size is out of range.");

            //Create the request body
            HDRadioEnvelope req = new HDRadioEnvelope
            {
                MsacRequest = new MsacRequest
                {
                    MsgInfo = new MsgInfo
                    {
                        MsgType = "Direct File Copy",
                        FileDestination = filename,
                        FileSize = count.ToString(),
                        Offset = "0"
                    }
                }
            };

            //Send (this will do validation)
            await SendRequestGetResponse(req, buffer, index, count);
        }

        /// <summary>
        /// Sends a sync lot. Use this for sending images tied to audio like album art.
        /// </summary>
        /// <param name="startTime">The estimated time this image will be displayed.</param>
        /// <param name="fileName">The filename on the exporter to use.</param>
        /// <param name="duration">The duration of the item.</param>
        /// <param name="lotId">The requested lot ID.</param>
        /// <param name="expiry">The expiration of this lot.</param>
        /// <param name="dataService">The data service to send this on.</param>
        /// <param name="triggerType">The type of trigger to use.</param>
        /// <param name="cancelPrior">If true, cancels other items being sent.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ISyncSendLot> SyncPreSendAsync(DateTime startTime, string fileName, TimeSpan duration, int lotId, DateTime expiry, string dataService = "AAHD1", SyncSendTriggerType triggerType = SyncSendTriggerType.Passive, bool cancelPrior = false)
        {
            //Create the request body
            HDRadioEnvelope req = new HDRadioEnvelope
            {
                MsacRequest = new MsacRequest
                {
                    MsgInfo = new MsgInfo
                    {
                        MsgType = "Sync Pre Send",
                        StartTime = Utils.DateTimeToMsacString(startTime),
                        FileName = fileName,
                        DataServiceName = dataService,
                        SongDuration = ((int)duration.TotalSeconds).ToString(),
                        TriggerType = triggerType.ToString(),
                        CancelPrior = cancelPrior ? "TRUE" : "FALSE"
                    },
                    LotInfo = new LotInfo
                    {
                        LotId = lotId.ToString(),
                        ExpirationDate = Utils.DateTimeToMsacString(expiry)
                    }
                }
            };

            //Send and get response
            HDRadioEnvelope response = await SendRequestGetResponse(req);

            //Validate
            if (response.MsacResponse.UniqueTag == null)
                throw new Exception("Malformed response: Unique tag was not set.");
            if (response.MsacResponse.LotInfo == null)
                throw new Exception("Malformed response: LotInfo was not set.");
            if (response.MsacResponse.LotInfo.LotId == null || !int.TryParse(response.MsacResponse.LotInfo.LotId, out int returnLotId))
                throw new Exception("Malformed response: Lot ID was either not set or was invalid.");

            //Wrap
            return new SendingSyncImpl(this, response.MsacResponse.UniqueTag, returnLotId, dataService, response.MsacResponse.MsgInfo.State);
        }

        class SendingSyncImpl : ISyncSendLot
        {
            public SendingSyncImpl(MsacConnection msac, string uniqueTag, int lotId, string dataServiceName, string state)
            {
                this.msac = msac;
                this.uniqueTag = uniqueTag;
                this.lotId = lotId;
                this.dataServiceName = dataServiceName;
                this.state = state;
            }

            private readonly MsacConnection msac;
            private readonly string uniqueTag;
            private readonly int lotId;
            private readonly string dataServiceName;
            private string state;

            public int LotId => lotId;
            public string State => state;

            /// <summary>
            /// Takes a response from any state-supplying message and updates the state after verifying it
            /// </summary>
            /// <param name="envelope"></param>
            private void ApplyStateUpdate(HDRadioEnvelope envelope)
            {
                if (envelope.MsacResponse == null || envelope.MsacResponse.MsgInfo == null || envelope.MsacResponse.MsgInfo.State == null)
                    throw new Exception("Malformed response: State not set.");
                state = envelope.MsacResponse.MsgInfo.State;
            }

            public async Task RefreshStateAsync()
            {
                //Create the request body
                HDRadioEnvelope req = new HDRadioEnvelope
                {
                    MsacRequest = new MsacRequest
                    {
                        MsgInfo = new MsgInfo
                        {
                            MsgType = "Status Request",
                            DataServiceName = dataServiceName,
                            UniqueTag = uniqueTag
                        }
                    }
                };

                //Send and get response (this will also check result code)
                HDRadioEnvelope response = await msac.SendRequestGetResponse(req);

                //Apply change
                ApplyStateUpdate(response);
            }

            public async Task ModifyStartAsync(DateTime start)
            {
                //Create the request body
                HDRadioEnvelope req = new HDRadioEnvelope
                {
                    MsacRequest = new MsacRequest
                    {
                        MsgInfo = new MsgInfo
                        {
                            MsgType = "Modify Start",
                            StartTime = Utils.DateTimeToMsacString(start),
                            DataServiceName = dataServiceName,
                            UniqueTag = uniqueTag
                        }
                    }
                };

                //Send and get response (this will also check result code)
                HDRadioEnvelope response = await msac.SendRequestGetResponse(req);

                //Apply change
                ApplyStateUpdate(response);
            }

            public async Task CancelSendAsync(bool cancelPrior = false)
            {
                //Create the request body
                HDRadioEnvelope req = new HDRadioEnvelope
                {
                    MsacRequest = new MsacRequest
                    {
                        MsgInfo = new MsgInfo
                        {
                            MsgType = "Cancel Send",
                            DataServiceName = dataServiceName,
                            UniqueTag = uniqueTag,
                            CancelPrior = cancelPrior ? "TRUE" : "FALSE"
                        }
                    }
                };

                //Send and get response (this will also check result code)
                HDRadioEnvelope response = await msac.SendRequestGetResponse(req);

                //Apply change
                ApplyStateUpdate(response);
            }
        }
    }
}
