namespace Benchmarking.Entities.Source
{
    public class Foo
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Int32 { get; set; }

        public long Int64 { set; get; }

        public int? NullInt { get; set; }

        public float Floatn { get; set; }

        public double Doublen { get; set; }

        public DateTime DateTime { get; set; }

        public InnerFoo Foo1 { get; set; }

        public List<InnerFoo> Foos { get; set; }

        public List<InnerFoo> FooArr { get; set; }

        public List<int> IntArr { get; set; }

        public List<int> Ints { get; set; }
    }
}
