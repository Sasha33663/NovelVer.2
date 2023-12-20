using NAudio.Wave;
using static NovelVer._2.Chapter;

namespace NovelVer._2;

internal class Program
{
    static async Task Main(string[] args)
    {
          
    Chapter chapter1 = new Chapter("C:\\Users\\ЕвпатийКалоед\\Desktop\\Проекты\\NovelVer.2\\bin\\Debug\\net8.0\\Сцены\\ПлощадьНачало.txt", 9, " C:\\Users\\ЕвпатийКалоед\\Desktop\\Проекты\\NovelVer.2\\bin\\Debug\\net8.0\\Sounds\\Square.mp3");

        Console.WriteLine(chapter1.MakeAnswer());
        await chapter1.PlayMusicAsync();
        Console.Clear();
       
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
            
            Chapter chapter2 = new Chapter("C:\\Users\\ЕвпатийКалоед\\Desktop\\Проекты\\NovelVer.2\\bin\\Debug\\net8.0\\Сцены\\ПредисловиеГеройКалита.txt", 61, "D:\\Downloads\\Final Fantasy XIV — Limsa Lominsa (Day) (www.lightaudio.ru).mp3");
            chapter2.PlayMusicAsync();
            Console.WriteLine(chapter2.MakeAnswer());
            
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
        string answer = "";


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
                
              
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(answer.Remove(0, i.ToString().Length + 1));
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

                    if (i == 1)
                    {
                        waveOut.Play();
                    }

                    while (waveOut.PlaybackState == PlaybackState.Playing)
                    {
                       
                        if (i == Index)
                        {
                            waveOut.Stop();
                            
                        }
                        
                        Task.Delay(100).Wait();
                    }
                }
            }
        });
     }
}
    
