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
        private string title;
        private string artist;
        private string genre;
        private string album;

        private string xhdrMime;
        private string xhdrFlush;
        private string xhdrBlank;
        private string xhdrTrigger;
        private string xhdrLotId;

        public PsdSendBuilder SetTitle(string title)
        {
            this.title = title;
            return this;
        }

        public PsdSendBuilder SetArtist(string artist)
        {
            this.artist = artist;
            return this;
        }

        public PsdSendBuilder SetAlbum(string album)
        {
            this.album = album;
            return this;
        }

        public PsdSendBuilder SetGenre(string genre)
        {
            this.genre = genre;
            return this;
        }

        public PsdSendBuilder XhdrSetMime(string mime)
        {
            if (mime == null)
                throw new ArgumentNullException(nameof(mime));
            if (!mime.ToLower().StartsWith("0x"))
                throw new Exception("Mime type specified is invalid. Must be a hexidecimal value.");
            xhdrMime = mime;
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
            if (xhdrFlush == "TRUE" || xhdrBlank == "TRUE")
                throw new Exception("Invalid operation: Flush memory or blank screen cannot be set when triggering an image.");
            xhdrTrigger = "TRUE";
            xhdrLotId = lotId.ToString();
            return this;
        }

        public PsdSendBuilder XhdrBlankScreen()
        {
            if (xhdrFlush == "TRUE" || xhdrTrigger == "TRUE")
                throw new Exception("Invalid operation: Flush memory or trigger cannot be set when blanking screen.");
            xhdrBlank = "TRUE";
            return this;
        }

        public PsdSendBuilder XhdrFlushMemory()
        {
            if (xhdrBlank == "TRUE" || xhdrTrigger == "TRUE")
                throw new Exception("Invalid operation: Blank screen or trigger cannot be set when flushing memory.");
            xhdrFlush = "TRUE";
            return this;
        }

        /// <summary>
        /// Checks if the PSD is valid. Throws an exception if invalid
        /// </summary>
        /// <returns></returns>
        public void Validate()
        {
            //Check that at least title or artist is set
            if (title == null && artist == null)
                throw new Exception("At least title or artist should be set.");
        }

        /// <summary>
        /// Gets the underlying PSD object.
        /// </summary>
        public PsdFields Psd
        {
            get
            {
                //Build core
                CorePsdField core = new CorePsdField
                {
                    Title = title,
                    Artist = artist,
                    Album = album,
                    Genre = genre
                };

                //Build XHDR if specified
                XhdrPsdField xhdr = null;
                if (xhdrMime != null || xhdrBlank != null || xhdrFlush != null || xhdrTrigger != null || xhdrLotId != null)
                {
                    xhdr = new XhdrPsdField
                    {
                        BlankScreen = xhdrBlank,
                        FlushMemory = xhdrFlush,
                        Trigger = xhdrTrigger,
                        LotId = xhdrLotId,
                        MimeType = xhdrMime
                    };
                }

                //Build
                return new PsdFields
                {
                    Core = core,
                    Xhdr = xhdr
                };
            }
        }

        /// <summary>
        /// Makes a deep clone.
        /// </summary>
        /// <returns></returns>
        public PsdSendBuilder Clone()
        {
            return new PsdSendBuilder
            {
                title = title,
                artist = artist,
                album = album,
                genre = genre,
                xhdrLotId = xhdrLotId,
                xhdrBlank = xhdrBlank,
                xhdrTrigger = xhdrTrigger,
                xhdrFlush = xhdrFlush,
                xhdrMime = xhdrMime
            };
        }
    }
}
