using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CodeWars.Cli.ListUtils;

namespace CodeWars.Cli;

public class Kata
{
    public static String LongestConsec(string[] strarr, int k)
    {
        if (strarr.Length == 0 || k > strarr.Length || k <= 0) return "";
        return string.Concat(strarr
            .Distinct()
            .Select((s, i) => new { val = s, index = i })
            .OrderByDescending(s => s.val.Length)
            .ThenBy(s => s.index)
            .Take(k)
            .OrderBy(s => s.val)
            .Select(s => s.val));
    }

    public static bool IsPangram(string str)
    {
        return "abcdefghijklmnopqrstuvwxyz".All(ch => str.Where(char.IsLetter).Select(char.ToLower).Contains(ch));
    }

    public static string Remove_char(string s)
    {
        return s[1..^1];
    }

    public static int SumMix(object[] x)
    {
        return x.Select(n => (n is string ? int.Parse(n.ToString()) : (int)n)).Sum();
    }

    public static string SeriesSum(int n)
    {
        return Math.Round(Enumerable.Range(1, n).Select(i => 1 / (double)(3 * (i - 1) + 1)).Sum(), 2).ToString(CultureInfo.InvariantCulture);
    }

    public static int[] CountPositivesSumNegatives(int[] input)
    {
        if (input.Length == 0) return input;
        return new int[] { input.Count(n => n > 0), input.Where(n => n < 0).Sum() }; //return an array with count of positives and sum of negatives
    }

    public static string DuplicateEncode(string word)
    {
        var counts = word.ToLower().GroupBy(ch => ch).ToDictionary(g => g.Key, h => h.Count());
        return new string(word.Select(ch => ((char)counts[char.ToLower(ch)] > 1 ? ')' : '(')).ToArray());
    }

    // Calculate multiplicative persistence, sum of product of all digits until product is only 1 digit long 
    public static int Persistence(long n)
    {
        int DigitProduct(long l)
        {
            var i = 1;
            var chars = l.ToString().ToCharArray();
            foreach (var ch in chars)
            {
                i *= int.Parse(ch.ToString());
            }

            return i;
        }

        var result = DigitProduct(n);
        while (result > 9)
        {
            result = DigitProduct((result));
        }

        return 0;
    }

    public static string BookBalance(string book)
    {
        var lineRx = new Regex(@"^(\d{1,3}) (\w*).*? ?(\d{1,4}\.\d{2}).*$");
        var balRx = new Regex(@"^(\d{1,4}\.\d{2})\b");

        var sb = new StringBuilder();
        var total = 0m;
        var origBalance = 0m;
        var runBalance = 0m;
        var lines = book.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        for (var i = 0; i < lines.Length; i++)
        {
            if (i == 0)
            {
                origBalance = decimal.Parse(balRx.Match(lines[i]).Value);
                runBalance = origBalance;
                sb.Append($"Original Balance: {Math.Round(origBalance, 2):0.00}");
                sb.Append('\n');
            }
            else
            {
                var match = lineRx.Match(lines[i]);
                var amtStr = decimal.Parse(match.Groups[3].Value);

                runBalance = runBalance - amtStr;
                total += amtStr;
                sb.Append($"{match.Groups[1].Value} {match.Groups[2].Value} {Math.Round(amtStr, 2):0.00} Balance {Math.Round(runBalance, 2):0.00}");
                sb.Append('\n');
            }
        }

        sb.Append($"Total expense  {Math.Round(total, 2):0.00}");
        sb.Append('\n');
        sb.Append($"Average expense  {Math.Round(total / (lines.Length - 1), 2):0.00}");

        return sb.ToString();
    }

    public static int[] SortArrayOddNumbers(int[] array)
    {
        var evensList = array.Where(n => n % 2 == 0).ToList();
        var oddValList = array.Where(n => n % 2 == 1).OrderBy(n => n).ToList();
        var oddPosList = array.Select((n, i) => new { Index = i, Val = n }).Where(n => n.Val % 2 == 1).Select(n => n.Index).ToList();

        for (var i = 0; i < oddPosList.Count; i++)
        {
            evensList.Insert(oddPosList[i], oddValList[i]);
        }

        return evensList.ToArray();
    }

    public static int SumOfIntegersInString(string s)
    {
        var sum = 0;
        var number = new StringBuilder();
        foreach (var ch in s)
        {
            if (char.IsDigit(ch))
                number.Append(ch);
            else if (number.Length > 0)
            {
                sum += int.Parse(number.ToString());
                number.Clear();
            }
        }

        if (number.Length > 0)
        {
            sum += int.Parse(number.ToString());
        }

        return sum;
    }

    public static string[] ChunkByTwo(string str)
    {
        List<List<T>> ChunkBy<T>(IEnumerable<T> source, int chunkSize)
        {
            return source.Select((x, i) => new { Index = i, Value = x }).GroupBy(x => x.Index / chunkSize).Select(x => x.Select(v => v.Value).ToList()).ToList();
        }

        var chunks = ChunkBy(str, 2);
        var ret = chunks.Take(chunks.Count - 1);
        ret = chunks[^1].Count == 1 ? ret.Append(string.Concat(chunks[^1][0], "_").ToList()) : ret.Append(chunks[^1]);
        return ret.Select(cl => string.Join("", cl)).ToArray();
    }
    
    public static string PigIt(string str)
    {
        return string.Join(' ', str.Split(' ')
            .Select(s => s.ToCharArray())
            .Select(carr => carr.Length > 1 ? 
                string.Join("", new string(carr[1..]), carr[0].ToString(), "ay") : 
                carr[0].ToString()));        
    }    
    
    public static string ConvertToRoman(int n)
    {
        var romanNums = new Dictionary<char, int> { { 'M', 1000 }, { 'D', 500 }, { 'C', 100 }, { 'L', 50 }, { 'X', 10 }, { 'V', 5 }, { 'I', 1 } };

        var rsb = new StringBuilder();
        foreach(var kvp in romanNums)
        {
            var m = n / kvp.Value;
            rsb.Append(new string(kvp.Key, m));
            n = n % kvp.Value;
        }



        return rsb.ToString();
    }    
}