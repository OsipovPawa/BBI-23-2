using cw1;
using System;

namespace cw1
{
    public struct Number
    {
        public int Real { get; set; }

        public Number(int real)
        {
            Real = real;
        }

        public static Number summa(Number a, Number b)
        {
            return new Number(a.Real + b.Real);
        }

        public static Number raznost(Number a, Number b)
        {
            return new Number(a.Real - b.Real);
        }

        public static Number proizvedenie(Number a, Number b)
        {
            return new Number(a.Real * b.Real);
        }

        public static Number chastnoe(Number a, Number b)
        {
            return new Number(a.Real / b.Real);
        }

        public override string ToString()
        {
            return $"chislo = {Real}";
        }
    }
}

class Program
{
    static void Main()
    {
        Number a = new Number(6);
        Number b = new Number(3);
        Number sum = Number.summa(a,b);
        Number diff = Number.raznost(a,b);
        Number multiple = Number.proizvedenie(a,b);
        Number del = Number.chastnoe(a,b);

        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(sum + " / summa");
        Console.WriteLine(diff + " / Bbi4eTaHuE");
        Console.WriteLine(multiple + " / umnojenie");
        Console.WriteLine(del + " / delenie");
    }
}


