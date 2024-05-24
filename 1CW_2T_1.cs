using cw2;
using System;

namespace cw2
{
    public class Number
    {
        public int Real { get; set; }

        public Number(int real)
        {
            Real = real;
        }
    }
    public class ComplexNumber : Number
    {
        public int Mnimoe { get; set; }
        public Mnimoe(int mnimoe, int real) : base(real)
        {
            Mnimoe = mnimoe;
        }
        public static ComplexNumber summa(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real + b.Real, a.Mnimoe + b.Mnimoe);
        }

        public static ComplexNumber raznost(Number a, Number b)
        {
            return new ComplexNumber(a.Real - b.Real, a.Mnimoe - b.Mnimoe);
        }

        public static ComplexNumber proizvedenie(Number a, Number b)
        {
            return new ComplexNumber(a.Real * b.Real, a.Mnimoe * b.Mnimoe);
        }

        public static ComplexNumber chastnoe(Number a, Number b)
        {
            return new ComplexNumber(a.Real / b.Real, a.Mnimoe / b.Mnumoe);
        }

        public override string ToString()
        {
            return $"chislo = {Real} + {Mnimoe}i";
        }
    }

    class Program
    {
        static void Main()
        {
            ComplexNumber a = new ComplexNumber(6, 2);
            ComplexNumber b = new ComplexNumber(3, 4);
            ComplexNumber sum = ComplexNumber.summa(a, b);
            ComplexNumber diff = ComplexNumber.raznost(a, b);
            ComplexNumber multiple = ComplexNumber.proizvedenie(a, b);
            ComplexNumber del = ComplexNumber.chastnoe(a, b);

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(sum + " / summa");
            Console.WriteLine(diff + " / Bbi4eTaHuE");
            Console.WriteLine(multiple + " / umnojenie");
            Console.WriteLine(del + " / delenie");
        }
    }
}





