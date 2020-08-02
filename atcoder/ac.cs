using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AC
{
    partial class Solver
    {
        public void Solve()
        {
            
        }
    }
}

namespace AC
{
    public class shiokara
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var Re = new Reader(sr);
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            var Wr = new Writer(sw);
            var solver = new Solver(Re, Wr);
            solver.Solve();
            sw.Flush();
        }
    }

    partial class Solver
    {
        private Reader reader;
        private Writer writer;
        public Solver(Reader reader, Writer writer){ this.reader = reader; this.writer = writer; }

        public int[] Ints => reader.IntRL();
        public int Int => reader.IntR();
        public double[] Doubles => reader.DoubleRL();
        public double Double => reader.DoubleR();
        public long[] Longs => reader.LongRL();
        public long Long => reader.LongR();

        public void WL(string s) => writer.WL(s);
        public void WL(object o) => writer.WL(o);
    }

    //読み込む
    public class Reader
    {
        private TextReader reader;
        public Reader(TextReader reader){ this.reader = reader; }

        public int[] IntRL() => reader.ReadLine().Split(' ').Select(int.Parse).ToArray();
        public int IntR() => int.Parse(reader.ReadLine());
        public double[] DoubleRL() => reader.ReadLine().Split(' ').Select(double.Parse).ToArray();
        public double DoubleR() => double.Parse(reader.ReadLine());
        public long[] LongRL() => reader.ReadLine().Split(' ').Select(long.Parse).ToArray();
        public long LongR() => long.Parse(reader.ReadLine());
    }

    //書き込む
    public class Writer
    {
        private TextWriter writer;
        public Writer(TextWriter writer){ this.writer = writer; }

        public void WL(string w){ writer.WriteLine(w); }
        public void WL(object o){ writer.WriteLine(o); }
    }
}