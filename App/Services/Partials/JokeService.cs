namespace AllWeKnow.App.Services.Partials;

public class JokeService
{
    public static string GetJoke()
    {
        try
        {
            // Open the text file using a stream reader.
            using (var steamReader = new StreamReader("wwwroot/resources/loading/loadingjokes.txt"))
            {
                int count = 0;
                List<string> lines = new List<string>();
                Random r = new Random();  
                
                while (steamReader.ReadLine() is { } line)
                {
                    count++;
                    lines.Add(line);
                }
                return lines[r.Next(0, count)];
            }
        }
        catch (IOException e)
        {
            return e.Message;
        }
    }
}