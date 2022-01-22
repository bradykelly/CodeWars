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
}