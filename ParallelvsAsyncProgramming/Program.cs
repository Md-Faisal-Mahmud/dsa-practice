using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Linq;

class Program
{
    static async Task Main()
    {
        // Base URLs (only 5 unique ones)
        string[] baseUrls =
        {
            "https://www.example.com",
            "https://www.microsoft.com",
            "https://www.github.com",
            "https://www.stackoverflow.com",
            "https://www.wikipedia.org"
        };

        // Make 100 URLs by repeating the base list
        string[] urls = Enumerable.Range(0, 20)
                                  .SelectMany(_ => baseUrls)
                                  .ToArray(); // 20 × 5 = 100

        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible; ExampleApp/1.0)");

        // --- Async version ---
        var sw = Stopwatch.StartNew();

        var tasks = new Task<string>[urls.Length];
        for (int i = 0; i < urls.Length; i++)
            tasks[i] = httpClient.GetStringAsync(urls[i]);

        var results = await Task.WhenAll(tasks);

        sw.Stop();
        Console.WriteLine($"Async finished in {sw.ElapsedMilliseconds} ms");
        Console.WriteLine($"Async got {results.Length} results");

        Console.WriteLine();
        Console.WriteLine("Press ENTER to run Parallel version...");
        Console.ReadLine();

        // --- Parallel version ---
        sw.Restart();
        Parallel.ForEach(urls, url =>
        {
            try
            {
                string result = httpClient.GetStringAsync(url).Result; // blocking
                Console.WriteLine(result.Substring(0, 40) + "...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching {url}: {ex.Message}");
            }
        });
        sw.Stop();
        Console.WriteLine($"Parallel.ForEach finished in {sw.ElapsedMilliseconds} ms");
    }
}

// here async is good.