﻿using Ppt23.Shared;

namespace Ppt23.API.Data
{
    public class Revize
    {
        public Guid Id { get; set; }
        public Vybaveni? Vybaveni { get; set; } = null!;
        public Guid VybaveniId { get; set; }
        public string? Name { get; set; }
        public DateTime? DateTime { get; set; }

        public void SetRandomDate(VybaveniVm vyb, DateTime from, DateTime to)
        {
            Random rand = new Random();
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(rand.NextDouble() * range.Ticks));

            DateTime = from + randTimeSpan;
        }
    }
}
