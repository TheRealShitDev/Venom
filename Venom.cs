using Venom.Utils;

namespace Venom;

public class Venom
{

    public void Start()
    {
        Console.WriteLine("Welcome to Venom v1.0");
        Console.WriteLine("\nPlease enter a URL: ");

        string url = Console.ReadLine();

        if (!url.Contains("http://") && !url.Contains("https://"))
        {
            Console.WriteLine("Invalid url. Please make sure the url has http(s)://");
            return;
        }
        
        Console.WriteLine("How many threads do you want to use? ");
        int threads = int.Parse(Console.ReadLine());

        if (threads <= 0)
        {
            Console.WriteLine("You must use more than 0 threads");
            return;
        }

        for (int i = 0; i < threads; i++)
        {
            Console.WriteLine($"Starting thread {i} ");
            Task.Run(() =>
            {
                while (true)
                {
                    HttpUtils.SimulateRequest(url);   
                }
            });
        }

        Console.WriteLine("Press any key to stop");
        Console.ReadKey();
    }
    
}