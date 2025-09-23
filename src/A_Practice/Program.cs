
public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        //if (s.Length != t.Length)
        //{
        //    return false;
        //}

        Dictionary<char, int> countS = new Dictionary<char, int>();
        Dictionary<char, int> countT = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            countS[s[i]] = countS.GetValueOrDefault(s[i], 0) + 1;
            countT[t[i]] = countT.GetValueOrDefault(t[i], 0) + 1;
        }

        var x1111 = countS.OrderByDescending(x => x.Key);
        var y1111 = countT.OrderByDescending(x => x.Key);
        var res = countS.Except(countT);

        return countS.Count == countT.Count && !countS.Except(countT).Any();
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        string s = "ccat";
        string t = "atcd";
        bool result = solution.IsAnagram(s, t);
        Console.WriteLine(result); // Output: True
    }
}

