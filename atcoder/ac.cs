using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AC
{
    public class shiokara
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sc = new Scanner(sr);
            var solver = new Solver(sc);

        }
    }

    public class Solver
    {
        private Scanner scanner;
        public Solver(Scanner scanner){ this.scanner = scanner;}

        public void Solve(){

        }

        public int[] Ints => scanner.IntRL();
        public int Int => scanner.IntR();
        public double[] Doubles => scanner.DoubleRL();
        public double Double => scanner.DoubleR();
        public long[] Longs => scanner.LongRL();
        public long Long => scanner.LongR();
    }

    //読み込む
    public class Scanner
    {
        private TextReader reader;
        public Scanner(TextReader reader){ this.reader = reader;}

        public int[] IntRL() => reader.ReadLine().Split(' ').Select(int.Parse).ToArray();
        public int IntR() => int.Parse(reader.ReadLine());

        public double[] DoubleRL() => reader.ReadLine().Split(' ').Select(double.Parse).ToArray();
        public double DoubleR() => double.Parse(reader.ReadLine());

        public long[] LongRL() => reader.ReadLine().Split(' ').Select(long.Parse).ToArray();
        public long LongR() => long.Parse(reader.ReadLine());
    }
}