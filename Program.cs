using NAudio.Wave;
using System.Text.Json.Serialization;
using static NovelVer._2.Chapter;

namespace NovelVer._2;
internal class Program
{
    static async Task Main(string[] args)
    {    
    Chapter chapter1 = new Chapter("C:\\Users\\ЕвпатийКалоед\\Desktop\\Проекты\\NovelVer.2\\bin\\Debug\\net8.0\\Сцены\\ПлощадьНачало.txt", 9, " C:\\Users\\ЕвпатийКалоед\\Desktop\\Проекты\\NovelVer.2\\bin\\Debug\\net8.0\\Sounds\\Square.mp3");
        { 
            Console.WriteLine(chapter1.MakeAnswer());
            await chapter1.PlayMusicAsync();
            Console.Clear();
        }
        Text text1 = new Text { ChoiceText = "\n Возможно, я все-таки бездельник. Время двигается вперед, а я здесь без дела. Может быть, пора что-то менять?" };
        Text text2 = new Text { ChoiceText = "\n \n Нет, я герой! Даже герою положено немного отдохнуть. Я посижу еще немного и подумаю о следующем приключении." };
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(text1.ChoiceText);
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("|1| Пойти по пути: Я герой");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(text2.ChoiceText);
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("|2| Пойти по пути: Я бездельник");
       
        int Choice = 0;
        while (true)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out Choice))
            {
                if (Choice == 1 || Choice == 2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите только 1 или 2.");
                }
            }
            else
            {
                Console.WriteLine("Пожалуйста, введите только 1 или 2.");
            }
        }
        Console.ResetColor();
        Console.Clear();

        if (Choice == 1)
        {
            Chapter chapter2 = new Chapter("C:\\Users\\ЕвпатийКалоед\\Desktop\\Проекты\\NovelVer.2\\bin\\Debug\\net8.0\\Сцены\\ПредисловиеГеройКалита.txt", 61, "C:\\Users\\ЕвпатийКалоед\\Desktop\\Проекты\\NovelVer.2\\bin\\Debug\\net8.0\\Sounds\\Square.mp3");
            
              
                
            Console.WriteLine(chapter2.MakeAnswer());
            await chapter2.PlayMusicAsync();

        }
        if(Choice == 2)
        {
            Chapter chapter3 = new Chapter("C:\\Users\\ЕвпатийКалоед\\Desktop\\Проекты\\NovelVer.2\\bin\\Debug\\net8.0\\Сцены\\ПредисловиеГеройКалита.txt", 61, "C:\\Users\\ЕвпатийКалоед\\Desktop\\Проекты\\NovelVer.2\\bin\\Debug\\net8.0\\Sounds\\Square.mp3");
            Console.WriteLine(chapter3.MakeAnswer());
            await chapter3.PlayMusicAsync();


        }

    }

}
public partial class Chapter
{ 
    public int i;
    private static bool isMusicPlayed = false;
    public string FilePath { get; private set; }
    public int Index { get; private set; }
    public string MusicPath { get; private set; }
    public Chapter(string filePath, int index, string musicPath)
    {
        FilePath = filePath;
        Index = index;
        MusicPath = musicPath;  
    }
    public Text MakeAnswer()
    {
        if (!isMusicPlayed)
        {
             PlayMusicAsync();
            isMusicPlayed =true ;
        }
        string text = File.ReadAllText(FilePath);
        string answer = "" ;
      
        for (i = 1; i <= Index; i++)
        {           
            string searchString = $"{i}.";
            int start = text.IndexOf(searchString);
            if (start == -1)
            {
                Console.WriteLine($"Подстрока {searchString} не найдена.");
            }
            else
            {
                int end = text.IndexOf($"{i + 1}.");
                if (end == -1)
                {
                    end = text.Length;
                }
                int windowHeight = Console.WindowHeight;
                Console.SetCursorPosition(0, windowHeight - 1);
                answer = text.Substring(start, end - start);
                if (answer.Contains("Евпатий:"))
                {
                    ConsoleHelper.WriteLineGreen("Евпатий:");
                    Console.WriteLine(answer.Remove(0, i.ToString().Length + 1).Replace("Евпатий:", ""));
                }
                
                else if (answer.Contains("Камень:"))
                {
                    ConsoleHelper.WriteLineGray("Камень:");
                    Console.WriteLine(answer.Remove(0, i.ToString().Length + 1).Replace("Камень:", ""));
                }
                else if (answer.Contains("Девочка-Кошка:"))
                {
                    ConsoleHelper.WriteLineMagenta("Девочка-Кошка:");
                    Console.WriteLine(answer.Remove(0, i.ToString().Length + 1).Replace("Девочка-Кошка:", ""));
                }
                else if (answer.Contains("Бомбат:"))
                {
                    ConsoleHelper.WriteLineMagenta("Бомбат:");
                    Console.WriteLine(answer.Remove(0, i.ToString().Length + 1).Replace("Бомбат:", ""));
                }
                else if (answer.Contains("Стражник:"))
                {
                    ConsoleHelper.WriteLineDarkBlue("Стражник:");
                    Console.WriteLine(answer.Remove(0, i.ToString().Length + 1).Replace("Стражник:", ""));
                }
                else if (answer.Contains("Королева:"))
                {
                    ConsoleHelper.WriteLineRed("Королева:");
                    Console.WriteLine(answer.Remove(0, i.ToString().Length + 1).Replace("Королева:", ""));
                }
                else if (answer.Contains("Кричащая-Калита:"))
                {
                    ConsoleHelper.WriteLineRed("Кричащая-Калита:");
                    Console.WriteLine(answer.Remove(0, i.ToString().Length + 1).Replace("Кричащая-Калита:", ""));
                }
                else if (answer.Contains("Справка:"))
                {
                    ConsoleHelper.WriteLineYellow("Справка:");
                    Console.WriteLine(answer.Remove(0, i.ToString().Length + 1).Replace("Справка:", ""));
                }
                else if (answer.Contains("Архизлокал Калейдоскопа:"))
                {
                    ConsoleHelper.WriteLineRed("Архизлокал Калейдоскопа:");
                    Console.WriteLine(answer.Remove(0, i.ToString().Length + 1).Replace("Архизлокал Калейдоскопа:", ""));
                }
                else if (answer.Contains("Калейдоскоп-Коварства:"))
                {
                    ConsoleHelper.WriteLineDarkMagenta("Калейдоскоп-Коварства:");
                    Console.WriteLine(answer.Remove(0, i.ToString().Length + 1).Replace("Калейдоскоп-Коварства:", ""));
                }
                else if (answer.Contains("Скрипучая Дубина:"))
                {
                    ConsoleHelper.WriteLineDarkGray("Скрипучая Дубина:");
                    Console.WriteLine(answer.Remove(0, i.ToString().Length + 1).Replace("Скрипучая Дубина:", ""));
                }
                else
                {
                    ConsoleHelper.WriteLineCyan(answer.Remove(0, i.ToString().Length + 1));
                }

                Console.ReadKey();
                Console.Clear();
               
            }
                if (i == Index)
            {
                Text ch = new Text();
                ch.ChoiceText = answer;
                return ch;
            }
        }
        return new Text { ChoiceText = answer };

    }
    public async Task PlayMusicAsync()
    {
        await Task.Run(() =>
        {
            using (var waveOut = new WaveOutEvent())
            {
                using (var audioFileReader = new AudioFileReader(MusicPath))
                {
                    waveOut.Init(audioFileReader);

                    waveOut.PlaybackStopped += (sender, eventArgs) =>
                    {
                        waveOut.Dispose();
                    };

                    if ( i==1|| i<=Index)
                    { 
                    waveOut.Play();
                    }
                    
                    while (waveOut.PlaybackState == PlaybackState.Playing)
                    {
                        if (i == Index)
                        {
                          
                            Task.Delay(1000).Wait(); 
                            waveOut.Stop();
                        }

                        Task.Delay(100).Wait();
                    }
                }
            }
      
        });
        
    
    }
}
    

