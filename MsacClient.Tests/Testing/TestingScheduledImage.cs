using MsacClient.Utility.Scheduler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MsacClient.Tests.Testing
{
    public class TestingScheduledImage : IMsacScheduledImage
    {
        public TestingScheduledImage(string filename)
        {
            this.filename = filename;
            data = Encoding.ASCII.GetBytes(filename);
        }

        private readonly string filename;
        private readonly byte[] data;

        public string Filename => filename;

        public string DataService => "dummy";

        public Stream Open()
        {
            return new MemoryStream(data);
        }
    }
}
