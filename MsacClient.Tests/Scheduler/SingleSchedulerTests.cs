using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsacClient.Tests.Testing;
using MsacClient.Utility.Scheduler;
using MsacClient.Utility.Upload;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Tests.Scheduler
{
    [TestClass]
    public class SingleSchedulerTests
    {
        /// <summary>
        /// Tests that events put in at the same time will work
        /// </summary>
        [TestMethod]
        public void NowSend()
        {
            Sim s = RunSim(TimeSpan.Zero, TimeSpan.FromMinutes(2));
            TestingConnection conn = s.conn;

            Assert.IsTrue(conn.EventsSendPsd.Count == 1);
            Assert.IsTrue(conn.EventsPreSendSyncLot.Count == 1);
        }

        /// <summary>
        /// Tests that events in the past will work
        /// </summary>
        [TestMethod]
        public void PastSend()
        {
            Sim s = RunSim(TimeSpan.FromMinutes(-1), TimeSpan.FromMinutes(2));
            TestingConnection conn = s.conn;

            Assert.IsTrue(conn.EventsSendPsd.Count == 1);
            Assert.IsTrue(conn.EventsPreSendSyncLot.Count == 1);
        }

        /// <summary>
        /// Tests that events from before they started will not have images sent to the msac
        /// </summary>
        /*[TestMethod]
        public void PastSendPre()
        {
            Sim s = RunSim(TimeSpan.FromMinutes(-15), TimeSpan.FromMinutes(2));
            TestingConnection conn = s.conn;

            Assert.IsTrue(conn.EventsSendPsd.Count == 1);
            Assert.IsTrue(conn.EventsPreSendSyncLot.Count == 0);
        }*/

        /// <summary>
        /// Tests that lots will be made to expire if removed
        /// </summary>
        [TestMethod]
        public void SendCancel()
        {
            Sim s = RunSim(TimeSpan.FromMinutes(0), TimeSpan.FromMinutes(2));
            TestingConnection conn = s.conn;

            Assert.IsTrue(conn.EventsSendPsd.Count == 1);
            Assert.IsTrue(conn.EventsPreSendSyncLot.Count == 1);

            s.schedList.UpdateItems(new MsacScheduledRequest[0]);
            s.sched.DebugProcessTick(s.now);

            Assert.IsTrue(conn.EventsPreSendSyncLot.FirstEvent.Event.returnValue.EventsCancel.Count == 1);
        }

        /// <summary>
        /// Tests that lots will be moved around
        /// </summary>
        [TestMethod]
        public void SendChangeTiming()
        {
            Sim s = RunSim(TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(2));
            TestingConnection conn = s.conn;

            Assert.IsTrue(conn.EventsSendPsd.Count == 0); // not sent yet
            Assert.IsTrue(conn.EventsPreSendSyncLot.Count == 1); // but image should be sent to msac

            s.request.start -= TimeSpan.FromMinutes(1);
            s.schedList.UpdateItems(new MsacScheduledRequest[]
            {
                s.request
            });
            s.sched.DebugProcessTick(s.now);

            Assert.IsTrue(conn.EventsPreSendSyncLot.FirstEvent.Event.returnValue.EventsModifyStart.Count == 1);
        }

        struct Sim
        {
            public DateTime now;
            public SimulatedState state;
            public TestingConnection conn;
            public MsacUploadManager uploader;
            public MsacScheduler sched;
            public MsacScheduledRequest request;
            public IMsacSchedulerList schedList;
        }

        private Sim RunSim(TimeSpan itemDelay, TimeSpan duration)
        {
            DateTime now = new DateTime(2025, 1, 1);
            SimulatedState state = new SimulatedState
            {
                SimulatedTime = now
            };
            TestingConnection conn = new TestingConnection(state);
            MsacUploadManager uploader = new MsacUploadManager(conn);
            MsacScheduler sched = new MsacScheduler(conn, uploader)
            {
                ImageLifespan = TimeSpan.FromMinutes(10)
            };
            IMsacSchedulerList schedList = sched.CreateList("dummy");

            sched.DebugProcessTick(now);
            MsacScheduledRequest request = new MsacScheduledRequest
            {
                start = now + itemDelay,
                end = now + itemDelay + duration,
                image = new TestingScheduledImage("test"),
                psd = SchedulerUtil.CreateDummyPsd()
            };
            schedList.UpdateItems(new MsacScheduledRequest[]
            {
                request
            });

            sched.DebugProcessTick(now);

            return new Sim
            {
                now = now,
                state = state,
                conn = conn,
                sched = sched,
                schedList = schedList,
                uploader = uploader,
                request = request
            };
        }
    }
}
