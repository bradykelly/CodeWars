using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CodeWars.Cli;

internal class Kata
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
}

