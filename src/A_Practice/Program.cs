
//public class Solution
//{
//    public bool IsAnagram(string s, string t)
//    {
//        //if (s.Length != t.Length)
//        //{
//        //    return false;
//        //}

//        Dictionary<char, int> countS = new Dictionary<char, int>();
//        Dictionary<char, int> countT = new Dictionary<char, int>();
//        for (int i = 0; i < s.Length; i++)
//        {
//            countS[s[i]] = countS.GetValueOrDefault(s[i], 0) + 1;
//            countT[t[i]] = countT.GetValueOrDefault(t[i], 0) + 1;
//        }

//        var x1111 = countS.OrderByDescending(x => x.Key);
//        var y1111 = countT.OrderByDescending(x => x.Key);
//        var res = countS.Except(countT);

//        return countS.Count == countT.Count && !countS.Except(countT).Any();
//    }

//    public static void Main(string[] args)
//    {
//        //Solution solution = new Solution();
//        //string s = "ccat";
//        //string t = "atcd";
//        //bool result = solution.IsAnagram(s, t);
//        //Console.WriteLine(result); // Output: True

//        var counter = new Counter();
//        Parallel.For(0, 1000, i =>
//        {
//            counter.Value++;
//        });
//        Console.WriteLine(counter.Value);

//        var counter = new Counter();
//        Parallel.For(0, 1000, i =>
//        {
//            lock (counter)
//            {
//                counter.Value++;
//            }
//        });
//        Console.WriteLine(counter.Value);

//    }
//}

using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int n = 50_000_000;

        // Single-threaded loop
        var sw = Stopwatch.StartNew();
        long sum1 = 0;
        for (int i = 0; i < n; i++)
        {
            sum1 += i;
        }
        sw.Stop();
        Console.WriteLine($"Single-threaded sum: {sum1}, Time: {sw.ElapsedMilliseconds} ms");

        // Parallel.For loop
        sw.Restart();
        long sum2 = 0;
        Parallel.For(0, n,
            () => 0L, // Initialize thread-local sum
            (i, loopState, localSum) => localSum + i, // accumulate in local sum
            localSum => Interlocked.Add(ref sum2, localSum) // combine safely
        );
        sw.Stop();
        Console.WriteLine($"Parallel sum: {sum2}, Time: {sw.ElapsedMilliseconds} ms");
    }
}
