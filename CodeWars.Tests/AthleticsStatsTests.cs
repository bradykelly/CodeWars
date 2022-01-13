using System;
using System.Linq;
using CodeWars.Cli;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars.Tests;

[TestClass]
public class AthleticsStatsTests
{
    private static int time2snd13411(string s)
    {
        int[] arr = s.Split('|').Select(x => int.Parse(x)).ToArray();
        return 3600 * arr[0] + 60 * arr[1] + arr[2];
    }
    
    private static string snd2time13411(int n)
    {
        int h = n / 3600;
        int re = n % 3600;
        int mn = re / 60;
        int s = re % 60;
        return string.Format("{0:00}|{1:00}|{2:00}", h, mn, s);
    }
    
    public static string stat13411(string strg)
    {
        if (strg == "") return "";
        int[] r = strg.Split(',').Select(x => time2snd13411(x)).ToArray();
        Array.Sort(r);
        int lg = r.Length;
        int avg = (int)(r.Sum() / lg);
        int rge = r[lg - 1] - r[0];
        int md = (int)((r[(int)((lg - 1) / 2)] + r[(int)(lg / 2)]) / 2.0);
        return string.Format("Range: {0} Average: {1} Median: {2}", snd2time13411(rge), snd2time13411(avg), snd2time13411(md));
    }
    
    public static string comb13411(Random rnd) 
    {
        string a = "01|15|59, 1|47|16, 01|17|20, 1|32|34, 2|17|17";
        string b = "02|15|59, 2|47|16, 02|17|20, 2|32|34, 2|17|17, 2|22|00, 2|31|41";
        string c = "02|15|59, 2|47|16, 02|17|20, 2|32|34, 2|32|34, 2|17|17";
        string d = "00|15|59, 00|16|16, 00|17|20, 00|22|34, 00|19|34, 00|15|17";
        string e = "11|15|59, 10|16|16, 12|17|20, 9|22|34, 13|19|34, 11|15|17, 11|22|00, 10|26|37, 12|17|48, 9|16|30, 12|20|14, 11|25|11";
        string f = "1|15|59, 1|16|16, 1|17|20, 1|22|34, 1|19|34, 1|15|17, 1|22|00, 1|26|37, 1|17|48, 1|16|30, 1|20|14, 1|25|11";
        string k = a + ", " + b + ", " + c + ", " + d + ", " + e + ", " + f;
        string[] v = k.Split(',');
        int l = v.Length;
        string res = "";
        int n = rnd.Next(0, 20);
        //Console.WriteLine(n);
        for (int i = 0; i < n; i++) {
            int rr = rnd.Next(0, l); 
            res += v[rr];
            if (i < n - 1) res += ", ";
        }
        return res;
    }    
    
    [TestMethod]
    public void BasicTest() {    
        Assert.AreEqual("Range: 01|01|18 Average: 01|38|05 Median: 01|32|34", 
            Kata.Stat("01|15|59, 1|47|16, 01|17|20, 1|32|34, 2|17|17"));
        Assert.AreEqual("Range: 00|31|17 Average: 02|26|18 Median: 02|22|00", 
            Kata.Stat("02|15|59, 2|47|16, 02|17|20, 2|32|34, 2|17|17, 2|22|00, 2|31|41"));
        Assert.AreEqual("Range: 00|31|17 Average: 02|27|10 Median: 02|24|57", 
            Kata.Stat("02|15|59, 2|47|16, 02|17|20, 2|32|34, 2|32|34, 2|17|17"));
        Assert.AreEqual("Range: 00|07|34 Average: 00|17|47 Median: 00|16|48", 
            Kata.Stat("0|15|59, 0|16|16, 0|17|20, 0|22|34, 0|19|34, 0|15|0"));    
        Assert.AreEqual("Range: 04|03|04 Average: 11|14|36 Median: 11|18|59", 
            Kata.Stat("11|15|59, 10|16|16, 12|17|20, 9|22|34, 13|19|34, 11|15|17, 11|22|00, 10|26|37, 12|17|48, 9|16|30, 12|20|14, 11|25|11"));
        Assert.AreEqual("Range: 00|11|20 Average: 01|19|36 Median: 01|18|41", 
            Kata.Stat("1|15|59, 1|16|16, 1|17|20, 1|22|34, 1|19|34, 1|15|17, 1|22|00, 1|26|37, 1|17|48, 1|16|30, 1|20|14, 1|25|11"));
        Assert.AreEqual("", 
            Kata.Stat(""));
    }
}