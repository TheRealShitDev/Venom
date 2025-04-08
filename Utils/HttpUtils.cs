namespace Venom.Utils;

public class HttpUtils
{
    static readonly HttpClient client = new HttpClient();
    static readonly Random random = new Random();
    
    static readonly List<string> userAgents = new List<string>
{
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 Chrome/121.0.0.0 Safari/537.36",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:118.0) Gecko/20100101 Firefox/118.0",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 Edge/90.0.818.49 Safari/537.36",
    "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/605.1.15 Version/15.0 Safari/605.1.15",
    "Mozilla/5.0 (Macintosh; Intel Mac OS X 11_1_0) AppleWebKit/537.36 Chrome/90.0.4430.212 Safari/537.36",
    "Mozilla/5.0 (Macintosh; Intel Mac OS X 11_2_3; rv:87.0) Gecko/20100101 Firefox/87.0",
    "Mozilla/5.0 (Linux; Android 11; Pixel 4) AppleWebKit/537.36 Chrome/96.0.4664.45 Mobile Safari/537.36",
    "Mozilla/5.0 (Linux; Android 10; SM-G975F) AppleWebKit/537.36 Chrome/89.0.4389.72 Mobile Safari/537.36",
    "Mozilla/5.0 (Linux; Android 9; SAMSUNG SM-G930F) AppleWebKit/537.36 Chrome/78.0.3904.108 Mobile Safari/537.36",
    "Mozilla/5.0 (iPhone; CPU iPhone OS 14_2 like Mac OS X) AppleWebKit/605.1.15 Version/14.0 Mobile Safari/604.1",
    "Mozilla/5.0 (iPhone; CPU iPhone OS 15_0 like Mac OS X) AppleWebKit/605.1.15 Version/15.0 Mobile Safari/604.1",
    "Mozilla/5.0 (iPad; CPU OS 14_0 like Mac OS X) AppleWebKit/605.1.15 Version/14.0 Mobile Safari/604.1",
    "Googlebot/2.1 (+http://www.google.com/bot.html)",
    "Mozilla/5.0 (compatible; Bingbot/2.0; +http://www.bing.com/bingbot.htm)",
    "DuckDuckBot/1.0; (+http://duckduckgo.com/duckduckbot.html)",
    "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 Chrome/92.0.4515.107 Safari/537.36",
    "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:89.0) Gecko/20100101 Firefox/89.0",
    "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 Chrome/91.0.4472.124 Safari/537.36 HeadlessChrome/91.0.4472.124"
};

    
    static Dictionary<string, string> GenerateHeaders()
    {
        return new Dictionary<string, string>
        {
            { "User-Agent", userAgents[random.Next(userAgents.Count)] },
            { "X-Forwarded-For", $"{random.Next(1, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}" },
            { "Accept-Language", "en-US,en;q=0.9" },
        };
    }
    
    public static async Task SimulateRequest(string baseUrl)
    {
        string url = baseUrl;
        
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

        foreach (var header in GenerateHeaders())
        {
            request.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }

        try
        {
            client.SendAsync(request);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Error: {ex.Message}");
        }

        await Task.Delay(random.Next(200, 1000));
    }
    
}