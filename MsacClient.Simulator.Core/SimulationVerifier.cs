﻿using MsacClient.Simulator.Core.Output;
using MsacClient.Simulator.Core.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Simulator.Core
{
    public abstract class SimulationVerifier
    {
        public SimulationVerifier(SimOutput result)
        {
            //Set
            this.result = result;

            //Do a kind of simulation ourselves to find what PSDs are expected to have been sent
            /*//Collect all requests from all timelines (there will be duplicates)
            List<Tuple<MsacSimEventList, MsacSimEvent>> events = new List<Tuple<MsacSimEventList, MsacSimEvent>>();
            foreach (var t in result.Settings.Timeline)
                events.AddRange(t.Events.Select(x => new Tuple<MsacSimEventList, MsacSimEvent>(t, x)));

            //Order by time then select ones where their event list is topmost
            var orderedTimelines = result.Settings.Timeline.OrderBy(x => x.Time).ToArray();
            foreach (var e in events.OrderBy(x => x.Item2.Start))
            {
                //Determine what was topmost at this time by selecting the last timeline where the timeline time is before the start time of this item
                MsacSimEventList topmost = orderedTimelines.Where(x => x.Time < e.Item2.Start).LastOrDefault();
                if (topmost == null)
                    continue; // This PSD was never in a state where it can be displayed?

                //Check if this event's frame was topmost when this started
                if (topmost != e.Item1)
                    continue;

                //Register this
                sentPsds.Add(e.Item2);
            }*/
            sentPsds = CalculateSentPsds(result.Settings.Timeline);
        }

        private readonly SimOutput result;
        private readonly List<MsacSimEvent> sentPsds = new List<MsacSimEvent>();

        /// <summary>
        /// PSDs calculated to be sent
        /// </summary>
        public List<MsacSimEvent> ExpectedPsds => sentPsds;

        private static List<MsacSimEvent> CalculateSentPsds(IEnumerable<MsacSimEventList> input)
        {
            //Order timelines by time
            var orderedTimelines = input.OrderBy(x => x.Time).ToArray();

            //Enumerate them
            List<MsacSimEvent> output = new List<MsacSimEvent>();
            MsacSimEvent latest = null;
            for (int i = 0; i < orderedTimelines.Length; i++)
            {
                //Determine next tick from the next timeline, if any
                TimeSpan nextTick = TimeSpan.MaxValue;
                if (i + 1 < orderedTimelines.Length)
                    nextTick = orderedTimelines[i + 1].Time;

                //Build a list of "sub ticks" where events occur between these, in addition to the time of this timeline
                TimeSpan[] ticks = orderedTimelines[i].Events.Where(x => x.Start >= orderedTimelines[i].Time && x.Start < nextTick)
                    .Select(x => x.Start)
                    .Concat(new TimeSpan[] { orderedTimelines[i].Time })
                    .OrderBy(x => x)
                    .ToArray();

                //Simulate each tick
                TimeSpan lastSimulated = TimeSpan.MinValue;
                foreach (TimeSpan tick in ticks)
                {
                    //Determine the PSD to be rendered at this time (ignoring ones already simulated)
                    MsacSimEvent psd = orderedTimelines[i].Events.Where(x => x.Start <= tick && x.End > tick && !x.Pending)
                        .OrderBy(x => x.Start)
                        .FirstOrDefault();
                    lastSimulated = tick;

                    //Skip if none were found
                    if (psd == null)
                        continue;

                    //Check if this matches the last one
                    if (latest != null && latest.Comment == psd.Comment && latest.ImageFilename == psd.ImageFilename)
                        continue;

                    //Update last
                    if (latest != null)
                        latest.End = tick;

                    //Create clone
                    psd = new MsacSimEvent
                    {
                        Start = tick,
                        Comment = psd.Comment,
                        Pending = psd.Pending,
                        ImageFilename = psd.ImageFilename,
                        End = tick
                    };

                    //Add and update state
                    output.Add(psd);
                    latest = psd;
                }
            }

            return output;
        }

        /// <summary>
        /// Verifies that the result is valid.
        /// </summary>
        /// <param name="result"></param>
        public void Verify()
        {
            VerifyPsds();
            VerifyLots();
        }

        private string FormatTime(DateTime time)
        {
            TimeSpan span = time - result.Settings.Epoch;
            return span.TotalSeconds.ToString();
        }

        private void VerifyPsds()
        {
            //Get input and output PSDs, ordered by time
            var il = sentPsds.OrderBy(x => x.Start).ToArray();
            var ol = result.Psds.OrderBy(x => x.Time).ToArray();

            //Check length
            AssertTrue($"Output PSDs {ol.Length} do not equal expected {il.Length}.", il.Length == ol.Length);
            
            //Loop
            for (int i = 0; i < il.Length; i++)
            {
                //Get input and output items
                MsacSimEvent inp = il[i];
                SimOutputPsd oup = ol[i];

                //Find the first time the system was "aware" of this PSD by enumerating timelines
                DateTime firstAvail = DateTime.MinValue;
                foreach (var t in result.Settings.Timeline.OrderBy(x => x.Time))
                {
                    //Break after this event
                    if (t.Time > inp.Start)
                        break;

                    //Check if this contains a matching PSD
                    bool containsMatch = false;
                    foreach (var candidate in t.Events)
                        containsMatch = containsMatch || (candidate.Comment == inp.Comment && candidate.ImageFilename == inp.ImageFilename);

                    //If no match, clear available counter. Otherwise only set it if not set
                    if (containsMatch && firstAvail == DateTime.MinValue)
                        firstAvail = result.Settings.Epoch + t.Time;
                    if (!containsMatch)
                        firstAvail = DateTime.MinValue;
                }

                //Check that PSD times
                DateTime sentTime = result.Settings.Epoch + inp.Start;
                AssertTrue($"PSD #{i+1} sent time {FormatTime(oup.Time)} does not equal scheduled time of {FormatTime(sentTime)}.", oup.Time == sentTime);

                //Check that content matches
                AssertTrue($"PSD times match but content doesn't.", inp.Comment == oup.Text);

                //Do lot-related tasks
                if (oup.LotId.HasValue)
                {
                    //Find the associated lot
                    var lots = result.Lots.Where(x => x.LotId == oup.LotId.Value).ToArray();
                    if (lots.Length == 0)
                    {
                        Fault($"Could not find specified lot ID {oup.LotId}");
                    } else if (lots.Length > 1)
                    {
                        Fault($"{lots.Length} lots were found for lot ID {oup.LotId}; Exactly 1 was expected.");
                    } else
                    {
                        //Get the lot
                        SimOutputLot lot = lots[0];

                        //Check that the filenames match
                        AssertTrue($"Output lot filename \"{lot.Filename}\" does not match input \"{inp.ImageFilename}\".", lot.Filename == inp.ImageFilename);

                        //Check that it arrived on time
                        if (lot.FinalStartTime > oup.Time)
                            Fault($"Lot {lot.LotId} was scheduled to start sending {(lot.FinalStartTime - oup.Time).TotalSeconds} seconds late.");

                        //Check that the lot wasn't ancient
                        DateTime lotExpiry = lot.FinalStartTime + result.Settings.SchedulerSettings.ImageLifespan;
                        if (lotExpiry < oup.Time)
                            Fault($"Lot {lot.LotId} was expired before being sent (expired {(oup.Time - lotExpiry).TotalSeconds} secs before).");
                    }
                } else if (inp.ImageFilename != null)
                {
                    Fault("Output image has no lot assigned when there should be an input file.");
                }
            }
        }

        private void VerifyLots()
        {
            foreach (var lot in result.Lots)
            {
                //Find any associated PSDs
                SimOutputPsd[] psds = result.Psds.Where(x => x.LotId == lot.LotId).OrderBy(x => x.Time).ToArray();
                SimOutputPsd firstPsd = psds.FirstOrDefault();

                //If this wasn't cancelled but no delivered PSDs have it, fault
                if (psds.Length == 0 && !lot.Cancelled)
                {
                    Fault($"Lot {lot.LotId} wasn't cancelled but has no PSDs referencing it.");
                    continue;
                }

                //Switch depending on if it were cancelled. If not cancelled, assume there is at least one PSD
                if (!lot.Cancelled)
                {
                    //Check that the msac was notified at the correct time. Only functions if it was NOT moved
                    if (lot.InitialStartTime == lot.FinalStartTime) // Only perform this test if it was NOT moved
                    {
                        DateTime scheduledMsacNotify = firstPsd.Time - result.Settings.SchedulerSettings.ImagePreNotify;
                        if (scheduledMsacNotify < result.Settings.Epoch)
                        {
                            //Test for this lot is imposible; The MSAC delivery time cannot be checked because it's scheduled before the test would've started!
                            Warn($"Test is invalid; Unable to check MSAC delivery time for lot {lot.LotId} because epoch is after scheduled notify time {scheduledMsacNotify.ToLongTimeString()}.");
                        } else
                        {
                            if (lot.CreatedAt > scheduledMsacNotify)
                                Fault($"Lot {lot.LotId} notified the MSAC too late by {(lot.CreatedAt - scheduledMsacNotify).TotalSeconds} seconds (expected at {scheduledMsacNotify.ToLongTimeString()}).");
                            if (lot.CreatedAt < scheduledMsacNotify)
                                Fault($"Lot {lot.LotId} notified the MSAC too early by {(scheduledMsacNotify - lot.CreatedAt).TotalSeconds} seconds (expected at {scheduledMsacNotify.ToLongTimeString()}).");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Called when an error is detected.
        /// </summary>
        /// <param name="message"></param>
        protected abstract void Fault(string message);

        /// <summary>
        /// Reports a warning that doesn't mean the test failed but indicates something is off (usually something untestable)
        /// </summary>
        /// <param name="message"></param>
        protected abstract void Warn(string message);

        /// <summary>
        /// Faults if condition is false.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="condition"></param>
        protected virtual void AssertTrue(string message, bool condition)
        {
            if (!condition)
                Fault(message);
        }
    }
}
