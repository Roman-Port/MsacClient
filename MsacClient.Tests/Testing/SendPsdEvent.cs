using MsacClient.XmlData;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Tests.Testing
{
    public struct SendPsdEvent
    {
        public PsdFields psd;
        public string exportAddress;
        public string audioChannel;
    }
}
