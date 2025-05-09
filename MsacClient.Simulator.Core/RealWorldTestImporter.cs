using MsacClient.Simulator.Core.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MsacClient.Simulator.Core
{
    public static class RealWorldTestImporter
    {
        public static List<MsacSimEventList> ImportFromFile(string filename)
        {
            List<MsacSimEventList> output = new List<MsacSimEventList>();
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                int index = 0;
                while (true)
                {
                    //Read each line sequencially
                    string lineRaw = sr.ReadLine();
                    if (lineRaw == null)
                        break;

                    //Decode line
                    Line line = JsonConvert.DeserializeObject<Line>(lineRaw);

                    //Convert
                    output.Add(new MsacSimEventList
                    {
                        Time = line.Time,
                        Comment = $"Event #{index++ + 1}",
                        Events = line.Events.Select(x =>
                        {
                            return new MsacSimEvent
                            {
                                Start = x.Start,
                                End = x.End,
                                Comment = x.Comment,
                                ImageFilename = x.Filename,
                                Pending = x.Pending // TODO: IMPLEMENT!!!
                            };
                        }).ToList()
                    });
                }
            }
            return output;
        }

        class Line
        {
            [JsonProperty("time")]
            public TimeSpan Time { get; set; }

            [JsonProperty("events")]
            public LineEvent[] Events { get; set; }
        }

        class LineEvent
        {
            [JsonProperty("start")]
            public TimeSpan Start { get; set; }

            [JsonProperty("end")]
            public TimeSpan End { get; set; }

            [JsonProperty("comment")]
            public string Comment { get; set; }

            [JsonProperty("filename")]
            public string Filename { get; set; }

            [JsonProperty("pending")]
            public bool Pending { get; set; }
        }
    }
}
