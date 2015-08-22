using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DailyProgrammer;

namespace DailyProgrammer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            RedditGetter getter = new RedditGetter();
            var challenges = getter.GetDailyProgrammerChallenges().ToArray();
        }
    }
}
