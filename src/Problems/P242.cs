using System.Collections.Generic;

namespace LeetCode.Problems
{
    /// <summary>
    /// https://leetcode.com/problems/valid-anagram/
    /// </summary>
    public class P242
    {
        public object Run()
        {
            return IsAnagram("anagram", "nagaram");
        }

        public bool IsAnagram(string s, string t)
        {
            if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(t))
            {
                return true;
            }
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
            {
                return false;
            }
            if (s.Length != t.Length)
            {
                return false;
            }
            var dict = new Dictionary<char, int>();
            for (var i = 0; i < s.Length; ++i)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]]++;
                }
                else
                {
                    dict[s[i]] = 1;
                }
            }

            for (var i = 0; i < t.Length; ++i)
            {
                if (!dict.ContainsKey(t[i]))
                {
                    return false;
                }
                dict[t[i]]--;
            }

            foreach (var kv in dict)
            {
                if (kv.Value != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
