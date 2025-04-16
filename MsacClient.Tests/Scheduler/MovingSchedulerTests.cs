using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsacClient.Simulator.Core.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Tests.Scheduler
{
    /// <summary>
    /// Tests moving items around
    /// </summary>
    [TestClass]
    public class MovingSchedulerTests
    {
        /// <summary>
        /// Tests a single event that will move before air time long before it will air
        /// </summary>
        [TestMethod]
        public void TestSingleFar()
        {
            Utility.RunSimulation(new MsacSimTest
            {
                Timeline = new List<MsacSimEventList>()
                {
                    new MsacSimEventList
                    {
                        Time = Utility.Time(0, 0, 0),
                        Events = new List<MsacSimEvent>()
                        {
                            new MsacSimEvent
                            {
                                Start = Utility.Time(0, 10, 0),
                                Length = Utility.Time(0, 5, 0),
                                Comment = "a",
                                ImageFilename = "img1"
                            }
                        }
                    },
                    new MsacSimEventList
                    {
                        Time = Utility.Time(0, 1, 0),
                        Events = new List<MsacSimEvent>()
                        {
                            new MsacSimEvent
                            {
                                Start = Utility.Time(0, 11, 0),
                                Length = Utility.Time(0, 5, 0),
                                Comment = "a",
                                ImageFilename = "img1"
                            }
                        }
                    }
                }
            });
        }

        /// <summary>
        /// Tests a single event that will move before air time shortly before it will air, notifying the MSAC
        /// </summary>
        [TestMethod]
        public void TestSingleNear()
        {
            Utility.RunSimulation(new MsacSimTest
            {
                Timeline = new List<MsacSimEventList>()
                {
                    new MsacSimEventList
                    {
                        Time = Utility.Time(0, 0, 0),
                        Events = new List<MsacSimEvent>()
                        {
                            new MsacSimEvent
                            {
                                Start = Utility.Time(0, 10, 0),
                                Length = Utility.Time(0, 5, 0),
                                Comment = "a",
                                ImageFilename = "img1"
                            }
                        }
                    },
                    new MsacSimEventList
                    {
                        Time = Utility.Time(0, 9, 30),
                        Events = new List<MsacSimEvent>()
                        {
                            new MsacSimEvent
                            {
                                Start = Utility.Time(0, 10, 0.1),
                                Length = Utility.Time(0, 5, 0),
                                Comment = "a",
                                ImageFilename = "img1"
                            }
                        }
                    }
                }
            });
        }
    }
}
