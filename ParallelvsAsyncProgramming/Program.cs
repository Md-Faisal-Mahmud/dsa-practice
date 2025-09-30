#region HTTP Fetching Async
class Program
{
    static async Task Main()
    {
        string[] urls = new string[]
        {
            "https://example.com",
            "https://example.org",
            "https://example.net",
            "https://example.com",
            "https://example.org",
            "https://example.net",
            "https://example.com",
            "https://example.org",
            "https://example.net",
            "https://example.com",
            "https://example.org",
            "https://example.net",
            "https://example.com",
            "https://example.org",
            "https://example.net",
            "https://example.com",
            "https://example.org",
            "https://example.net",
        };

        // Async approach - non-blocking, all requests start together
        var sw = System.Diagnostics.Stopwatch.StartNew();
        Task<string>[] tasks = new Task<string>[urls.Length];

        for (int i = 0; i < urls.Length; i++)
        {
            tasks[i] = FetchAsync(urls[i]);
        }

        string[] results = await Task.WhenAll(tasks);
        sw.Stop();

        Console.WriteLine($"Async fetch finished in {sw.ElapsedMilliseconds} ms");

        // Print results lengths
        foreach (var r in results)
        {
            Console.WriteLine(r.Length);
        }
    }

    static async Task<string> FetchAsync(string url)
    {
        using HttpClient client = new HttpClient();
        return await client.GetStringAsync(url); // await frees thread while waiting
    }
}
/* 
Async fetch finished in 987 ms
1256
1256
1256

✅ Why async helps here:
Each GetStringAsync waits for network I/O.
Async does not block the main thread.
All requests start together, and CPU can do other work.
Using Parallel.For here would not help, because threads would just block waiting for the network response, wasting CPU thread
*/
#endregion


//#region HTTP Fetching Parallel
//class Program
//{
//    static void Main()
//    {
//        string[] urls = new string[]
//        {
//            "https://example.com",
//            "https://example.org",
//            "https://example.net",
//            "https://example.com",
//            "https://example.org",
//            "https://example.net",
//            "https://example.com",
//            "https://example.org",
//            "https://example.net",
//            "https://example.com",
//            "https://example.org",
//            "https://example.net",
//            "https://example.com",
//            "https://example.org",
//            "https://example.net",
//            "https://example.com",
//            "https://example.org",
//            "https://example.net",
//        };

//        var sw = System.Diagnostics.Stopwatch.StartNew();

//        Parallel.For(0, urls.Length, i =>
//        {
//            using HttpClient client = new HttpClient();
//            // This blocks the thread until the HTTP request finishes
//            string result = client.GetStringAsync(urls[i]).GetAwaiter().GetResult();
//            Console.WriteLine($"Fetched {urls[i]} length: {result.Length}");
//        });

//        sw.Stop();
//        Console.WriteLine($"Parallel.For fetch finished in {sw.ElapsedMilliseconds} ms");
//    }
//}

///* 
//Fetched https://example.com length: 1256
//Fetched https://example.com length: 1256
//Fetched https://example.org length: 1256
//Fetched https://example.com length: 1256
//Fetched https://example.org length: 1256
//Fetched https://example.com length: 1256
//Fetched https://example.org length: 1256
//Fetched https://example.com length: 1256
//Fetched https://example.org length: 1256
//Fetched https://example.org length: 1256
//Fetched https://example.com length: 1256
//Fetched https://example.org length: 1256
//Fetched https://example.net length: 1256
//Fetched https://example.net length: 1256
//Fetched https://example.net length: 1256
//Fetched https://example.net length: 1256
//Fetched https://example.net length: 1256
//Fetched https://example.net length: 1256
//Parallel.For fetch finished in 1147 ms
//*/
//#endregion
