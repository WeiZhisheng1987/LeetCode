using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Problems
{
    /// <summary>
    /// https://leetcode.com/problems/minimum-genetic-mutation/
    /// </summary>
    public class P433
    {
        public object Run()
        {
            var bank = new [] { "AACCGGTA" };

            return MinMutation("AACCGGTT", "AACCGGTA", bank);
        }

        public int MinMutation(string start, string end, string[] bank)
        {
            if (start == end)
            {
                return 0;
            }

            var bankSet = new HashSet<string>(bank);

            if (!bankSet.Contains(end))
            {
                return -1;
            }

            var set = new HashSet<string>() { start };
            return MinMutation(set, end, bankSet, 0);
        }

        public int MinMutation(HashSet<string> currentSet, string end, HashSet<string> bank, int level)
        {
            if (currentSet.Count == 0 || bank.Count == 0)
            {
                return -1;
            }

            foreach (var gene in currentSet)
            {
                bank.Remove(gene);
            }

            var set = new HashSet<string>();
            foreach (var gene in currentSet)
            {
                for (var i = 0; i < gene.Length; ++i)
                {
                    var chars = gene.ToCharArray();
                    foreach (var c in new[] { 'A', 'C', 'G', 'T' })
                    {
                        chars[i] = c;
                        var s = new string(chars);

                        if (bank.Contains(s) && s == end)
                        {
                            return level + 1;
                        }

                        if (bank.Contains(s))
                        {
                            set.Add(s);
                        }
                    }
                }
            }

            return MinMutation(set, end, bank, level + 1);
        }
    }
}
