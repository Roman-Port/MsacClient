using MsacClient.Entities;
using MsacClient.Exceptions;
using MsacClient.XmlData;
using System;
using System.IO;
using System.Net;
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

        public string DataServiceName { get; set; } = "SLHD1";

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
                    xmlPayloadString = stringWriter.ToString() + "\r\n";
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
        public async Task<StatusInfo> RequestStatusAsync()
        {
            //Create the request body
            HDRadioEnvelope req = new HDRadioEnvelope
            {
                MsacRequest = new MsacRequest
                {
                    MsgInfo = new MsgInfo
                    {
                        MsgType = "Status Request",
                        DataServiceName = DataServiceName
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
        public async Task SendPSDAsync(PsdSendInfo info)
        {
            //Validate request
            if (info == null)
                throw new ArgumentNullException(nameof(info));
            if (info.AudioChannel == null)
                throw new ArgumentNullException(nameof(info.AudioChannel));
            if (info.Title == null)
                throw new ArgumentNullException(nameof(info.Title));
            if (info.Artist == null)
                throw new ArgumentNullException(nameof(info.Artist));
            if (info.Album == null)
                throw new ArgumentNullException(nameof(info.Album));
            if (info.Genre == null)
                throw new ArgumentNullException(nameof(info.Genre));

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
                        Location = info.ExporterAddress,
                        AudioProgram = info.AudioChannel
                    },
                    PsdFields = new PsdFields
                    {
                        Core = new CorePsdField
                        {
                            Title = info.Title,
                            Artist = info.Artist,
                            Album = info.Album,
                            Genre = info.Genre
                        },
                        Xhdr = new XhdrPsdField
                        {
                            MimeType = "0XD9C72536",
                            BlankScreen = "true"
                        }
                    }
                }
            };

            //Send and get response (any errors would be caught in the validation)
            await SendRequestGetResponse(req);
        }
    }
}
