using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsacClient.Simulator.Core.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Tests.Scheduler
{
    [TestClass]
    public class BasicSchedulerTests
    {
        /// <summary>
        /// Tests a single event
        /// </summary>
        [TestMethod]
        public void TestSingleSend()
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
                    }
                }
            });
        }

        /// <summary>
        /// Tests two events added at the same time
        /// </summary>
        [TestMethod]
        public void TestSingleSend2()
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
                            },
                            new MsacSimEvent
                            {
                                Start = Utility.Time(0, 15, 0),
                                Length = Utility.Time(0, 5, 0),
                                Comment = "b",
                                ImageFilename = "img2"
                            }
                        }
                    }
                }
            });
        }

        /// <summary>
        /// Tests reusing image within a short time within the same request
        /// </summary>
        [TestMethod]
        public void TestReuseImageShort()
        {
            var r = Utility.RunSimulation(new MsacSimTest
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
                                Length = Utility.Time(0, 2, 0),
                                Comment = "a",
                                ImageFilename = "img1"
                            },
                            new MsacSimEvent
                            {
                                Start = Utility.Time(0, 12, 0),
                                Length = Utility.Time(0, 1, 0),
                                Comment = "b",
                                ImageFilename = "img2"
                            },
                            new MsacSimEvent
                            {
                                Start = Utility.Time(0, 13, 0),
                                Length = Utility.Time(0, 1, 0),
                                Comment = "c",
                                ImageFilename = "img1"
                            }
                        }
                    }
                }
            });
            Assert.IsTrue(r.Lots.Count == 2);
        }
    }
}
