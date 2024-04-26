namespace kontr;
abstract class Task
{
    private string _text;

    public Task(string text)
    {
        _text = text;
    }
}
class Task1 : Task
{
    public Task1(string text):base(text)
    {
    }
}

class Task2 : Task
{
    public Task2(string text):base(text)
    {

    }
}
class program
{
    static void Main(string[] args)
    {
        попытка не пытка
    }
}


