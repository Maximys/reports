﻿namespace Benchmarking.Entities.Destination
{
    public class FooDest
    {
        public string Name { get; set; }

        public int Int32 { get; set; }

        public long Int64 { set; get; }

        public int? NullInt { get; set; }

        public float Floatn { get; set; }

        public double Doublen { get; set; }

        public DateTime DateTime { get; set; }

        public InnerFooDest Foo1 { get; set; }

        public List<InnerFooDest> Foos { get; set; }

        public InnerFooDest[] FooArr { get; set; }

        public int[] IntArr { get; set; }

        public int[] Ints { get; set; }
    }
}
