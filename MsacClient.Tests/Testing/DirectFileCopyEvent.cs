using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Tests.Testing
{
    public struct DirectFileCopyEvent
    {
        public string filename;
        public byte[] buffer;
        public int index;
        public int count;
    }
}
