using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
    /// <summary>
    /// https://leetcode.com/problems/top-k-frequent-elements/
    /// </summary>
    public class P347
    {
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if(!dict.ContainsKey(num))
                {
                    dict[num] = 0;
                }
                dict[num] += 1;
            }

            var buckets = new List<int>[nums.Length + 1];
            foreach (var kv in dict)
            {
                if(buckets[kv.Value] == null)
                {
                    buckets[kv.Value] = new List<int>();
                }
                buckets[kv.Value].Add(kv.Key);
            }

            var result = new List<int>();

            for(var i = nums.Length; i>=0; --i)
            {
                if(buckets[i] != null)
                {
                    buckets[i].Sort();
                    result.AddRange(buckets[i]);
                }
            }

            return result.Take(k).ToList();
        }
    }
}
