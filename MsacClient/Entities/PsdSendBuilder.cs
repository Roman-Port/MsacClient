using MsacClient.XmlData;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Entities
{
    /// <summary>
    /// Class for building commands to set PSD
    /// </summary>
    public class PsdSendBuilder
    {
        private PsdFields psd = new PsdFields();

        public PsdSendBuilder SetTitle(string title)
        {
            if (psd.Core == null)
                psd.Core = new CorePsdField();
            psd.Core.Title = title;
            return this;
        }

        public PsdSendBuilder SetArtist(string artist)
        {
            if (psd.Core == null)
                psd.Core = new CorePsdField();
            psd.Core.Artist = artist;
            return this;
        }

        public PsdSendBuilder SetAlbum(string album)
        {
            if (psd.Core == null)
                psd.Core = new CorePsdField();
            psd.Core.Album = album;
            return this;
        }

        public PsdSendBuilder SetGenre(string genre)
        {
            if (psd.Core == null)
                psd.Core = new CorePsdField();
            psd.Core.Genre = genre;
            return this;
        }

        public PsdSendBuilder XhdrSetMime(string mime)
        {
            if (mime == null)
                throw new ArgumentNullException(nameof(mime));
            if (!mime.ToLower().StartsWith("0x"))
                throw new Exception("Mime type specified is invalid. Must be a hexidecimal value.");
            if (psd.Xhdr == null)
                psd.Xhdr = new XhdrPsdField();
            psd.Xhdr.MimeType = mime;
            return this;
        }

        public PsdSendBuilder XhdrTriggerImage(ILot lot)
        {
            if (lot == null)
                throw new ArgumentNullException(nameof(lot));
            return XhdrTriggerImage(lot.LotId);
        }

        public PsdSendBuilder XhdrTriggerImage(int lotId)
        {
            if (psd.Xhdr == null)
                psd.Xhdr = new XhdrPsdField();
            if (psd.Xhdr.FlushMemory == "TRUE" || psd.Xhdr.BlankScreen == "TRUE")
                throw new Exception("Invalid operation: Flush memory or blank screen cannot be set when triggering an image.");
            psd.Xhdr.Trigger = "TRUE";
            psd.Xhdr.LotId = lotId.ToString();
            return this;
        }

        public PsdSendBuilder XhdrBlankScreen()
        {
            if (psd.Xhdr == null)
                psd.Xhdr = new XhdrPsdField();
            if (psd.Xhdr.FlushMemory == "TRUE" || psd.Xhdr.Trigger == "TRUE")
                throw new Exception("Invalid operation: Flush memory or trigger cannot be set when blanking screen.");
            psd.Xhdr.BlankScreen = "TRUE";
            return this;
        }

        public PsdSendBuilder XhdrFlushMemory()
        {
            if (psd.Xhdr == null)
                psd.Xhdr = new XhdrPsdField();
            if (psd.Xhdr.BlankScreen == "TRUE" || psd.Xhdr.Trigger == "TRUE")
                throw new Exception("Invalid operation: Blank screen or trigger cannot be set when flushing memory.");
            psd.Xhdr.FlushMemory = "TRUE";
            return this;
        }

        /// <summary>
        /// Checks if the PSD is valid. Throws an exception if invalid
        /// </summary>
        /// <returns></returns>
        public void Validate()
        {
            //CORE
            if (psd.Core == null)
                throw new Exception("PSD core is not set.");
        }

        /// <summary>
        /// Gets the underlying PSD object.
        /// </summary>
        public PsdFields Psd => psd;
    }
}
