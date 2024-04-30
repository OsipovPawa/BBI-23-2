using System;
using System.Xml.Linq;
abstract class Student
{
    protected string _name;
    protected int _missed;

    public Student(string name,int missed)
    {
        _name = name;
        _missed = missed;
    }

    public int missed => _missed;

    public void Print()
    {
        Console.WriteLine($"{_name} {_missed}");
    }
}
class Math : Student
{
    private int _MathMark;

    public Math(string name, int MathMark, int missed) : base (name,missed)
    {
        _MathMark = MathMark;
    }
    public void Print()
    {
        Console.WriteLine($"{_name} mathmark: {_MathMark} missed classes: {_missed}");
    }
    public int MathMark => _MathMark;
}
class Inf : Student
{
    private int _InfoMark;

    public Inf(string name, int InfoMark, int missed) : base (name,missed) 
    {
        _InfoMark = InfoMark;
    }
    public void Print()
    {
        Console.WriteLine($"{_name} infmark: {_InfoMark} missed classes: {_missed}");
    }
    public int InfoMark => _InfoMark;
}

class Program
{
    static void Main()
    {
        Math[] math = new Math[5]
        {
            new Math("Valera", 3, 4),
            new Math("Sergey", 2, 5),
            new Math("George", 5, 4),
            new Math("Valentina", 3, 2),
            new Math("Panteleimon", 5, 5)
        };

        Inf[] inf = new Inf[5]
        {
            new Inf("Valera", 4, 6),
            new Inf("Sergey", 5, 5),
            new Inf("George", 2, 6),
            new Inf("Valentina", 4, 1),
            new Inf("Panteleimon", 2, 7)
        };

        int fails1 = 0;
        for (int i = 0; i < math.Length; i++)
            if (math[i].MathMark == 2)
                fails1++;
        Math[] failstud = new Math[fails1];
        int j = 0;
        for (int i = 0; i < math.Length; i++)
            if (math[i].MathMark == 2)
            {
                failstud[j] = math[i];
                j++;
            }
        int fails2 = 0;
        for (int i = 0; i < inf.Length; i++)
            if (inf[i].InfoMark == 2)
                fails2++;
        Inf[] failed = new Inf[fails2];
        int z = 0;
        for (int i = 0; i< inf.Length; i++)
        if (inf[i].InfoMark == 2)
        {
                failed[z] = inf[i];
                z++;
        }

        for (int i = 0; i < failstud.Length - 1; i++)
        {
            for (int k = 0; k < failstud.Length - i - 1; k++)
            {
                if (failstud[k].missed < failstud[k + 1].missed)
                {
                    Math temp = failstud[k];
                    failstud[k] = failstud[k + 1];
                    failstud[k + 1] = temp;
                }
            }
        }
        for (int i = 0; i < failed.Length - 1; i++)
        {
            for (int k = 0; k < failed.Length - i - 1; k++)
            {
                if (failed[k].missed < failed[k + 1].missed)
                {
                    Inf temp = failed[k];
                    failed[k] = failed[k + 1];
                    failed[k + 1] = temp;
                }
            }
        }
        Console.WriteLine("студенты с неудовлетворильной оценкой:");
        
        for (int i = 0; i < failed.Length; i++)
        {
            failed[i].Print();
        }
        for (int i = 0; i < failed.Length; i++)
        {
            failstud[i].Print();
        }
    }
}