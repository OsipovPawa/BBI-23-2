//using System;
//public struct Student
//{
//    private string _name;
//    private int _mark;
//    private int _missed;

//    public Student(string name, int mark, int missed)
//    {
//        _name = name;
//        _mark = mark;
//        _missed = missed;
//    }

//    public int mark => _mark;

//    public int missed => _missed;

//    public void Print()
//    {
//        Console.WriteLine($"{_name} {_mark} {_missed}");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Student[] students = new Student[5]
//        {
//            new Student("Иван", 5, 6),
//            new Student("Сергей", 2, 7),
//            new Student("Коля", 2, 8),
//            new Student("Виктория", 2, 10),
//            new Student("Александра", 4, 1)
//        };

//        int fails = 0;
//        for (int i = 0; i < students.Length; i++)
//        {
//            if (students[i].mark == 2)
//            {
//                fails++;
//            }
//        }

//        Student[] failstud = new Student[fails];
//        int j = 0;
//        for (int i = 0; i < students.Length; i++)
//        {
//            if (students[i].mark == 2)
//            {
//                failstud[j] = students[i];
//                j++;
//            }
//        }
//        int z = 1;
//        int r = z + 1;
//        while (z < failstud.Length)
//        {
//            if (z == 0 || failstud[z].missed <= failstud[z-1].missed)
//            {
//                z = r;
//                r++;
//            }
//            else if(failstud[z].missed >= failstud[z-1].missed)
//            {
//                Student temp = failstud[z-1];
//                failstud[z-1] = failstud[z];
//                failstud[z] = temp;
//                z--;
//            }
//        }


//        Console.WriteLine("Студенты с неудовлетворительной оценкой:");
//        for (int k = 0; k < failstud.Length; k++)
//        {
//            failstud[k].Print();
//        }
//    }
//}


using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

struct Student
{
    private string _Name;
    private string _Surname;
    private int[] _Subjects;


    public string Name => _Name;
    public string Surname => _Surname;
    public int[] Subjects => _Subjects;
    public double Average
    {
        get
        {
            double sum = 0;
            foreach (int subject in _Subjects)
            {
                sum += subject;
            }
            return sum / _Subjects.Length;
        }
    }

    public Student(string name, string surname, int math, int phys, int russ)
    {
        _Subjects = new int[] { math, phys, russ };
        _Name = name;
        _Surname = surname;
        bool failed = false;
        foreach (int subject in _Subjects)
        {
            if (subject == 2)
            {
                failed = true;
            }
        }
        if (failed)
        {
            _Subjects = new int[] { 0, 0, 0 };
        }
    }

    public void Print()
    {
        Console.WriteLine($"{_Name} {_Surname} - средний балл: {Average}");
    }
}

class Program
{
    static void Main()
    {
        Student[] students = new Student[5]
        {
            new Student("Ivan", "Ivanov", 3, 4, 5),
            new Student("Igor", "Igorev", 4, 5, 4),
            new Student("Volga", "Motors", 5, 5, 5),
            new Student("Erik", "Davidov", 2, 3, 4),
            new Student("Face", "Eshkere", 4, 3, 2),
        };

        Student[] successfulStudents = new Student[students.Length];
        int successfulCount = 0;

        foreach (var student in students)
        {
            if (student.Average >= 3.5)
            {
                successfulStudents[successfulCount] = student;
                successfulCount++;
            }
        }

        for (int i = 0; i < successfulCount - 1; i++)
        {
            for (int j = 0; j < successfulCount - 1 - i; j++)
            {
                if (successfulStudents[j].Average < successfulStudents[j + 1].Average)
                {
                    var temp = successfulStudents[j];
                    successfulStudents[j] = successfulStudents[j + 1];
                    successfulStudents[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Отсортированный список успешно сдавших экзамены учащихся:");
        for (int i = 0; i < successfulCount; i++)
        {
            successfulStudents[i].Print();
        }
        Console.ReadKey();
    }
}
