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

public class OldKata
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
    
    public static Dictionary<char, int> Count(string str)
    {
        if (string.IsNullOrWhiteSpace(str)) return null;
        return str.GroupBy(ch => ch).ToDictionary(c => c.Key, v => v.Count());
    }
    
    public static string[] TowerBuilder(int nFloors)
    {
        var len = nFloors * 2 - 1;
        var gap = 0;

        var strings = new List<string>();
        for (var i = 0; i < nFloors; i++)
        {
            strings.Add($"{new string(' ', gap)}{new string('*', len)}{new string(' ', gap)}");
            gap += 1;
            len -= 2;
        }

        return strings.ToArray().Reverse().ToArray();
    }
    
    public static string WhatTimeIsIt(double angle)
    {
        // Your code here
        var mins = Math.Floor(angle * 2);
        var hours = (int)mins / 60;
        mins = (int)mins % 60;

        return $"{hours:00}:{mins:00}";
    }
    
    public static string CannonsReady(Dictionary<string, string> gunners)
    {
        return gunners.Values.All(v => v == "aye") ? "Fire!" : "Shiver me timbers!";
    }    
    
    public static int find_it(int[] seq)
    {
        return seq.GroupBy(n => n).Where(n => n.Count() % 2 == 1).Select(n => n.Key).Single();
    }    
    
    public static string High(string s)
    {
        var maxWord = "";
        var maxScore = 0;
        var words = s.Split(' ');
        
        foreach(var w in words)
        {
            var score = w.Select(ch => ch - 'a' + 1).Sum();
            if (score == maxScore) continue;
            if (score <= maxScore) continue;
            maxScore = score;
            maxWord = w;
        }

        return maxWord;
    }    
    
    public static string ExpandedForm(long num)
    {
        var cols = new List<long>();
        var millions = num / 1000000 * 1000000;
        var thousands = (num % 1000000) / 1000 * 1000;
        var hundreds = (num % 1000) / 100 * 100;
        var tens = (num % 100) / 10 * 10;
        var units = num % 10;
        
        cols.Add(millions);
        cols.Add(thousands);
        cols.Add(hundreds);
        cols.Add(tens);
        cols.Add(units);

        return string.Join(" + ", cols.Where(c => c > 0));
    }
    
    public static int PrimeIndeces(int [] arr)
    {  
        bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i+=2)
                if (number % i == 0)
                    return false;

            return true;        
        }

        var sum = 0;
        for (var i = 0; i < arr.Length; i++)
        {
            if (IsPrime(i))
            {
                sum += arr[i];
            }
        }

        return sum;
    }
    
    public static bool XO (string input)
    {
        return input.Count(ch => char.ToLower(ch) == 'x') == input.Count(ch => char.ToLower(ch) == 'o');
    }
    
    public static string Rot13(string message)
    {
        var sb = new StringBuilder();
        foreach (var ch in message)
        {
            var rot13Char = 0;
            if (char.IsUpper(ch))
            {
                rot13Char = ((ch - 64 + 13) % 26) + 64;
                sb.Append((char)rot13Char);
            }
            else if (char.IsLower(ch))
            {
                rot13Char = ((ch - 96 + 13) % 26) + 96;
                sb.Append((char)rot13Char);
            }
            else
            {
                sb.Append(ch);
            }
        }
        return sb.ToString();
    }    
    
    public static int BouncingBall(double h, double bounce, double window) 
    {
        if (h <= 0) return -1;
        if (bounce is <= 0 or >= 1) return -1;
        if (window >= h) return - 1;

        var sighted = 1;
        while (h > window)
        {
            h = h * bounce;
            if (h > window)
            {
                sighted += 2;
            }
        }
        return sighted;
    }  
    
    public static int SquareDigits(int n)
    {
        var sb = new StringBuilder();
        foreach (var dichar in n.ToString())
        {
            sb.Append(Math.Pow(double.Parse(dichar.ToString()), 2));
        }
        return int.Parse(sb.ToString());
    }
    
    public static long[] Digitize(long n)
    {
        return n.ToString().Select(ch => long.Parse(ch.ToString())).Reverse().ToArray();
    }    
    
    public static int GetUnique(IEnumerable<int> numbers)
    {
        var theList = numbers.ToList();
        return theList.Distinct().Single(n => theList.Count(i => i == n) == 1);
    }
    
    public static int[] InvertValues(int[] input)
    {
        return input.Select(n => n * -1).ToArray();
    }
    
    public static int DuplicateCount(string str)
    {
        return str.GroupBy(ch => ch).Select(g => g.Count()).Count(g => g > 1);
    }
    
    public static string FindNeedle(object[] haystack)
    {
        //return $"found the needle at position { haystack.Select((n, i) => new { hay = n.ToString(), index = i }).Where(a => a.hay == "needle").Select(a => a.index).Single()}";
        return $"found the needle at position {Array.IndexOf(haystack, "needle")}";
    }
    
    public static int PositiveSum(int[] arr)
    {
        return arr.Where(i => i > 0).Sum();
    } 
    
    public static string ReverseWords(string str)
    {
        return string.Join(" ", str.Split(' ').Select(word => new string(word.Reverse().ToArray())));
    }
    
    public static int FindEvenIndex(int[] arr)
    {
        for (var n = 0; n < arr.Length; n++)
        {
            var left = 0;
            for (var l = 0; l < n; l++)
            {
                left += arr[l];
            }

            var right = 0;
            for (var r = n + 1; r < arr.Length; r++)
            {
                right += arr[r];
            }

            if (left == right)
            {
                return n;
            }
        }

        return -1;
    }
    
    public static bool Comp(int[] a, int[] b)
    {
        var ordA = a.OrderBy(n => n).ToArray();
        var ordB = b.OrderBy(n => n).ToArray();

        for (var i = 0; i < ordA.Length; i++)
        {
            if (ordB[i] != (int)Math.Pow(ordA[i], 2)) return false;
        }
        return true;
    }    
    
    public static int SumMinMax(int[] numbers)
    {
        return numbers.OrderBy(n => n).Skip(1).Take(numbers.Length - 2).Sum();
    }
    
    public static string AlphabetPosition(string text)
    {
        return string.Join(' ', text.Select(ch => char.IsUpper(ch) ? ch - 64 : char.IsLower(ch) ? ch - 96 : 0).Where(ch => ch != 0));
    }
    
    public static String Accum(string s)
    {
        return string.Join('-', s.Select((c, i) => $"{new string(char.ToUpper(c), 1)}{new string(char.ToLower(c), i)}"));
    }    
    
    public static string Likes(string[] name)
    {
        return name.Length switch
        {
            0 => "",
            1 => $"{name[0]} likes this",
            2 => $"{name[0]} and {name[1]} like this",
            3 => $"{name[0]}, {name[1]} and {name[2]} like this",
            _ => $"{name[0]}, {name[1]} and {name.Length - 2} others like this"
        };
    }    
}

