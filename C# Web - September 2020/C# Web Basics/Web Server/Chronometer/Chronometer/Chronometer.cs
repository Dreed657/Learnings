using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private Stopwatch timer;

        public string GetTime => this.timer.Elapsed.ToString();
        
        public List<string> Laps { get; }

        public Chronometer()
        {
            this.timer = new Stopwatch();
            this.Laps = new List<string>();
        }

        public void Start()
        {
            this.timer.Start();
        }

        public void Stop()
        {
            this.timer.Stop();
        }

        public string Lap()
        {
            var lap = this.timer.Elapsed;
            Laps.Add(lap.ToString());
            return lap.ToString();
        }

        public void Reset()
        {
            this.timer.Reset();
            this.Laps.Clear();
        }

        public string GetLaps()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Laps:");

            for (var i = 0; i < Laps.Count; i++)
            {
                sb.AppendLine($"{i}. {Laps[i]}");
            }

            return sb.ToString().Trim();
        }
    }
}
