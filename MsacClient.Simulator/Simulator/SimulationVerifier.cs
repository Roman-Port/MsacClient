using MsacClient.Simulator.Simulator.Output;
using MsacClient.Simulator.Simulator.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Simulator.Simulator
{
    public abstract class SimulationVerifier
    {
        public SimulationVerifier(SimOutput result)
        {
            //Set
            this.result = result;

            //Do a kind of simulation ourselves to find what PSDs are expected to have been sent
            //Collect all requests from all timelines (there will be duplicates)
            List<Tuple<MsacSimEventList, MsacSimEvent>> events = new List<Tuple<MsacSimEventList, MsacSimEvent>>();
            foreach (var t in result.Settings.Timeline)
                events.AddRange(t.Events.Select(x => new Tuple<MsacSimEventList, MsacSimEvent>(t, x)));

            //Order by time then select ones where their event list is topmost
            var orderedTimelines = result.Settings.Timeline.OrderBy(x => x.Time).ToArray();
            foreach (var e in events.OrderBy(x => x.Item2.Start))
            {
                //Determine what was topmost at this time
                MsacSimEventList topmost = orderedTimelines.Where(x => x.Time < e.Item2.Start).LastOrDefault();
                if (topmost == null)
                    throw new Exception();

                //Check if this event's frame was topmost when this started
                if (topmost != e.Item1)
                    continue;

                //Register this
                sentPsds.Add(e.Item2);
            }
        }

        private readonly SimOutput result;
        private readonly List<MsacSimEvent> sentPsds = new List<MsacSimEvent>();

        /// <summary>
        /// Verifies that the result is valid.
        /// </summary>
        /// <param name="result"></param>
        public void Verify()
        {
            VerifyPsds();
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

                //Check that times match
                AssertTrue($"PSD sent time {oup.Time.Ticks} does not equal scheduled time of {(result.Settings.Epoch + inp.Start).Ticks}.", oup.Time == (result.Settings.Epoch + inp.Start));

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
                    }
                } else if (inp.ImageFilename != null)
                {
                    Fault("Output image has no lot assigned when there should be an input file.");
                }
            }
        }

        /// <summary>
        /// Called when an error is detected.
        /// </summary>
        /// <param name="message"></param>
        protected abstract void Fault(string message);

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
