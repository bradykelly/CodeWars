using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CodeWars.Cli;

public class Kata
{
    public static string GetMiddle(string s)
    {
        return s.Length % 2 == 0 ? s.Substring(s.Length / 2 - 1, 2) : s.Substring(s.Length / 2, 1);
    }

    public static bool IsSquare(int n)
    {
        return Math.Sqrt(n) -  Math.Floor(Math.Sqrt(n)) == 0;
    }

    public static bool ValidatePin(string pin)
    {
        return Regex.Match(pin, @"(^\d{4}\z)|(^\d{6}\z)").Success;
    }

    public static string PrinterError(String s)
    {
        return $"{s.Count(ch => !"abcdefghijklm".Contains(ch))}/{s.Length}";
    }

    public static int GetVowelCount(string str)
    {
        return str.Count(ch => "aeiou".Contains(ch));
    }

    public static string Longest(string s1, string s2)
    {
        var allChars = string.Concat(s1, s2);
        return new string (string.Concat(s1, s2).Distinct().OrderBy(ch => ch).ToArray());
    }

    public static int SequenceSum(int start, int end, int step)
    {
        if (end < start) return 0;
        if (end == start) return end;

        var total = 0;
        for (var n = start; n <= end; n += step)
        {
            total += n;
        }

        return total;
    }

    public static int binaryArrayToNumber(int[] BinaryArray)
    {
        return Convert.ToInt32(new string(BinaryArray.Select(ch => ch.ToString()[0]).ToArray()), 2);
    }

    public static bool Xo(string input)
    {
        return input.ToLower().Count(ch => ch == 'o') == input.ToLower().Count(ch => ch == 'x');
    }

    public static string[] SortByLength(string[] array)
    {
        return array.OrderBy(s => s.Length).ToArray();
    }

    public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
    {
        return listOfItems.Where(i => i is int).Select(i => int.Parse(i.ToString()!));
    }
    
    public static string Solve(string s)
    {
        var isLower = s.Count(char.IsLower) >= s.Count(char.IsUpper);
        return s.Count(char.IsLower) >= s.Count(char.IsUpper) ? s.ToLower() : s.ToUpper();
    }
    
    public static bool SmallEnough(int[] a, int limit)
    {
        return a.All(n => n <= limit);
    }    
    
    public static string EncryptThis(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return "";
        var oldWords = input.Split(' ');
        var newWords = new List<string>();
        foreach(var word in oldWords)
        {
            var first = ((int)word[0]).ToString();
            if (word.Length == 1)
            {
                newWords.Add(first);
                continue;
            }
            var second = word[^1];
            if (word.Length == 2)
            {
                newWords.Add($"{first}{second}");
                continue;
            }
            newWords.Add($"{first}{second}{word[Math.Min(word.Length - 1, 2)..^1]}{word[1]}");
        }

        return string.Join(' ', newWords);
    }
    
    public static string DecipherThis(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return "";
        var oldWords = s.Split(' ');
        var newWords = new List<string>();
        
        foreach(var word in oldWords)
        {
            var digits = word.Where(ch => ch is >= '0' and <= '9').ToArray().AsSpan();
            var ascii = int.Parse(digits);
            var asciiLen = ascii.ToString().Length;
            var first = Convert.ToChar(ascii).ToString();
            if (word.Length == asciiLen)
            {
                newWords.Add(first);
                continue;
            }
            var second = word[^1];
            if (word.Length == asciiLen + 1)
            {
                newWords.Add($"{first}{second}");
                continue;
            }
            newWords.Add($"{first}{second}{word[(asciiLen + 1)..^1]}{word[asciiLen]}");
        }      
        return string.Join(' ', newWords);
    }    
    
    public static int[] ArrayDiff(int[] a, int[] b)
    {
        return a.Where(n => !b.Contains(n)).ToArray();
    }
    
    public static int[,] MultiplicationTable(int size)
    {
        var ret = new int[size, size];
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                ret[x, y] = (x + 1) * (y + 1);
            }
        }

        return ret;
    }
    
    public static string Stat(string strg)
    {
        if (string.IsNullOrEmpty(strg)) return "";
        
        var rawTimes = strg.Split(',');
        var timesInSeconds = new List<int>();
        foreach (var t in rawTimes)
        {
            var tSplit = t.Trim().Split('|');
            int.TryParse(tSplit[0], out int hours);
            int.TryParse(tSplit[1], out int mins);
            int.TryParse(tSplit[2], out int secs);
            timesInSeconds.Add(hours * 60 * 60 + mins * 60 + secs);
        }

        var range = timesInSeconds.Max() - timesInSeconds.Min();
        var mean = (int)Math.Floor(timesInSeconds.Average());
        int halfIndex = timesInSeconds.Count / 2;
        var sortedNumbers = timesInSeconds.OrderBy(n=>n).ToList();
        int median;
        if ((timesInSeconds.Count % 2) == 0)
        {
            median = (int)Math.Floor((sortedNumbers.ElementAt(halfIndex) + sortedNumbers.ElementAt(halfIndex - 1)) / 2d);
        } else {
            median = sortedNumbers.ElementAt(halfIndex);
        }

        var tsMedian = new TimeSpan(0, 0, median);
        var tsMean = new TimeSpan(0, 0, mean);
        var tsRange = new TimeSpan(0, 0, range);

        return $"Range: {tsRange:hh\\|mm\\|ss} Average: {tsMean:hh\\|mm\\|ss} Median: {tsMedian:hh\\|mm\\|ss}";
    }	
    
    public static string BinaryToString(string binary)
    {
        if (string.IsNullOrWhiteSpace(binary)) return "";
        var text = new StringBuilder();

        for (int i = 0; i < binary.Length; i += 8)
        {
            text.Append(Convert.ToChar(Convert.ToInt32(binary[i..(i + 8)], 2)));
        }
      
        return text.ToString();
    }   
    
    public static int[] UpArray(int[] num)
    {
        if (num.Any(n => n > 9) || num.Any(n => n < 0)) return null;
        var numStr = new string(num.Select(n => n.ToString()[0]).ToArray());
        var big = (BigInteger.Parse(numStr) + 1).ToString().PadLeft(num.Length).Replace(" ", "0");
        return big.Select(ch => int.Parse(ch.ToString())).ToArray();

        return num;
    }
    
    public static int[] DataReverse(int[] data)
    {
        IEnumerable<List<T>> SplitList<T>(List<T> locations, int nSize=30)  
        {        
            for (int i = 0; i < locations.Count; i += nSize) 
            { 
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i)); 
            }  
        }
        return SplitList(data.ToList(), 8).Reverse().SelectMany(b => b).ToArray();
    }    
    
    public static int GetLongestPalindrome(string str)
    {
        bool IsPalindrome(string maybe)
        {
            return maybe.Reverse().SequenceEqual(maybe);
        }

        var largest = 0;
        for (int i = 0; i < str.Length; i++)
        {
            for (int j = i; j < str.Length; j++)
            {
                if (IsPalindrome(str.Substring(i, j - i + 1)) && j - i + 1 > largest) largest = j - i + 1;
            }
        }
        return largest;
    }    
    
    public static string ExtractFileName(string dirtFileName)
    {
        var rx = new Regex(@"^(\d+)_(.*)\.");
        return rx.Match(dirtFileName).Groups[2].Value;
    }
}

