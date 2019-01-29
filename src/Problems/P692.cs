using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
    /// <summary>
    /// https://leetcode.com/problems/top-k-frequent-words/
    /// </summary>
    public class P692
    {
        public IList<string> TopKFrequent(string[] words, int k)
        {
            var dict = new Dictionary<string, int>();

            foreach(var word in words)
            {
                if(dict.ContainsKey(word))
                {
                    dict[word] += 1;
                }
                else
                {
                    dict[word] = 1;
                }
            }

            return dict.OrderByDescending(kv => kv, new KvComparer()).Take(k).Select(kv => kv.Key).ToList();
        }

        private class KvComparer : IComparer<KeyValuePair<string, int>>
        {
            public int Compare(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
            {
                if (x.Value == y.Value)
                {
                    return 0-x.Key.CompareTo(y.Key);
                }
                return x.Value.CompareTo(y.Value);
            }
        }
    }
}
