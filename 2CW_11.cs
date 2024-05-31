using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Serialization;
abstract class Task
{
    protected string text;
    public string Text
    {
        get => text;
        protected set => text = value;
    }
    public Task(string text)
    {
        this.text = text;
    }
}
class Task1 : Task
{
    [JsonConstructor]
    public Task1(string text) : base(text) { }
    public override string ToString()
    {
        return ($"\n  Первые буквы заглавные:\n {UpperLetter()} \n");
    }

    private string UpperLetter()
    {
            string[] words = text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
            }
            return string.Join(", ", words);
    }
    class Task2 : Task
    {
        [JsonConstructor]
        public Task2(string text) : base(text) { }
        public override string ToString()
        {
            return $"\n Числа:\n {Chisla()}\n";
        }
        private string Chisla()
        {
            return text;
        }

        class Json
        {
            public static void Write<T>(T obj, string filepath)
            {
                using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize(fs, obj);
                }
            }
            public static T Read<T>(string filepath)
            {
                using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
                {
                    return JsonSerializer.Deserialize<T>(fs);
                }
                return default(T);
            }
        }
        class Program
        {
            static void Main()
            {
                string text = "Слон — крупное толстокожее хоботное млекопитающее семейства слоновых. Самый крупный наземный обитатель Земли в настоящее время. Ареал обитания — в тропических лесах и саваннах.";
                Task[] tasks = { new Task1(text), new Task2(text) };
                Console.WriteLine(tasks[0]);
                Console.WriteLine(tasks[1]);
                string path = @"C:\Users\m2301144\Desktop";
                string folder = "Answer";
                path = Path.Combine(path, folder);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string file_name_1 = "cw2_1.json";
                string file_name_2 = "cw2_2.json";

                Console.Write("Десереализованные файлы: \n");

                file_name_1 = Path.Combine(path, file_name_1);
                file_name_2 = Path.Combine(path, file_name_2);

                if (!File.Exists(file_name_1))
                {
                    Json.Write<Task1>((Task1)tasks[0], file_name_1);
                    Json.Write<Task2>((Task2)tasks[1], file_name_2);
                }
                else
                {
                    var t1 = Json.Read<Task1>(file_name_1);
                    var t2 = Json.Read<Task2>(file_name_2);
                    Console.WriteLine(t1);
                    Console.WriteLine(t2);
                }
            }
        }
    }
}