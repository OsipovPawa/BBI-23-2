using System;

abstract class Football
{
    private string _name;
    private int _zabit;
    private int _propusk;
    private int _ochki;

    public string Name => _name;
    public int Zabit => _zabit;
    public int Propusk => _propusk;
    public int Ochki => _ochki;

    public Football(string name, int Zabit, int Propusk)
    {
        _name = name;
        _zabit = Zabit;
        _propusk = Propusk;
        if (Zabit > Propusk)
        {
            _ochki = 3;
        }
        else if (Zabit == Propusk)
        {
            _ochki = 1;
        }
        else
        {
            _ochki = 0;
        }
    }

    public string PrintTeamInfo()
    {
        return $"{Name}: {Ochki} очков";
    }
}

class WomanTeam : Football
{
    public WomanTeam(string name, int Zabit, int Propusk) : base(name, Zabit, Propusk)
    {
    }
}

class ManTeam : Football
{
    public ManTeam(string name, int Zabit, int Propusk) : base(name, Zabit, Propusk)
    {
    }
}

class Program
{
    static void Main()
    {
        Football[] teams = new Football[10];
        teams[0] = new WomanTeam("Динамо", 1, 1);
        teams[1] = new WomanTeam("Цска", 3, 1);
        teams[2] = new WomanTeam("Крылья советов", 4, 0);
        teams[3] = new WomanTeam("Зенит", 2, 3);
        teams[4] = new WomanTeam("Спартак", 2, 2);
        teams[5] = new ManTeam("Локомотив", 5, 1);
        teams[6] = new ManTeam("Енисей", 3, 2);
        teams[7] = new ManTeam("Амкал", 4, 1);
        teams[8] = new ManTeam("Факел", 2, 4);
        teams[9] = new ManTeam("Шахтер", 1, 1);

        for (int i = 0; i < teams.Length - 1; i++)
        {
            for (int j = 0; j < teams.Length - i - 1; j++)
            {
                if (teams[j].Ochki < teams[j + 1].Ochki)
                {
                    var temp = teams[j];
                    teams[j] = teams[j + 1];
                    teams[j + 1] = temp;
                }
                else if (teams[j].Ochki == teams[j + 1].Ochki)
                {
                    int diff1 = teams[j].Zabit - teams[j].Propusk;
                    int diff2 = teams[j + 1].Zabit - teams[j + 1].Propusk;
                    if (diff1 < diff2)
                    {
                        var temp = teams[j];
                        teams[j] = teams[j + 1];
                        teams[j + 1] = temp;
                    }
                }
            }
        }

        Console.WriteLine("Таблица результатов:");
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine($"{i + 1}. {teams[i].PrintTeamInfo()}");
        }
    }
}