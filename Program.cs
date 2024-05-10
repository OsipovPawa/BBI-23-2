using System;
using System.Xml.Linq;
abstract class Student
{
    protected string _name;
    protected int _missed;

    public Student(string name, int missed)
    {
        _name = name;
        _missed = missed;
    }

    public int missed => _missed;

    public virtual void StudentInfo()
    {
        Console.WriteLine($"{_name} {_missed}");
    }
    public static void SortMachine(Student[] array, int leftIndex, int rightIndex)
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = array[leftIndex].missed;
        while (i <= j)
        {
            while (array[i].missed > pivot)
            {
                i++;
            }

            while (array[j].missed < pivot)
            {
                j--;
            }
            if (i <= j)
            {
                Student temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
        }

        if (leftIndex < j)
            SortMachine(array, leftIndex, j);
        if (i < rightIndex)
            SortMachine(array, i, rightIndex);
    }
}
class Math : Student
{
    private int _MathMark;

    public Math(string name, int MathMark, int missed) : base(name, missed)
    {
        _MathMark = MathMark;
    }
    public override void StudentInfo()
    {
        Console.WriteLine($"{_name} mathmark: {_MathMark} missed classes: {_missed}");
    }
    public int MathMark => _MathMark;
}
class Inf : Student
{
    private int _InfoMark;

    public Inf(string name, int InfoMark, int missed) : base(name, missed)
    {
        _InfoMark = InfoMark;
    }
    public override void StudentInfo()
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
            new Math("George", 2, 1),
            new Math("Valentina", 2, 2),
            new Math("Panteleimon", 5, 5)
        };

        Inf[] inf = new Inf[5]
        {
            new Inf("Valera", 4, 6),
            new Inf("Sergey", 5, 5),
            new Inf("George", 2, 6),
            new Inf("Valentina", 2, 8),
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
        for (int i = 0; i < inf.Length; i++)
            if (inf[i].InfoMark == 2)
            {
                failed[z] = inf[i];
                z++;
            }

        Student.SortMachine(failstud, 0, failstud.Length - 1);
        Student.SortMachine(failed, 0, failed.Length - 1);
        Console.WriteLine("студенты с неудовлетворильной оценкой:");

        for (int i = 0; i < failed.Length; i++)
        {
            failed[i].StudentInfo();
        }
        for (int i = 0; i < failed.Length; i++)
        {
            failstud[i].StudentInfo();
        }
    }
}



