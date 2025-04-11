using MsacClient.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Tests.Scheduler
{
    static class SchedulerUtil
    {
        public static PsdSendBuilder CreateDummyPsd(string title = "dummy", string artist = "artist")
        {
            return new PsdSendBuilder()
                .SetTitle(title)
                .SetArtist(artist);
        }
    }
}
