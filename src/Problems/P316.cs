using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Problems
{
    /// <summary>
    /// https://leetcode.com/problems/remove-duplicate-letters
    /// </summary>
    public class P316
    {
        public object Run()
        {
            return RemoveDuplicateLetters("ababacc");
        }

        public string RemoveDuplicateLetters(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            var chars = s.ToCharArray();
            Array.Sort(chars);

            var builder = new StringBuilder();
            var c = chars[0];
            builder.Append(c);
            for(var i=1; i<chars.Length; ++i)
            {
                if (c != chars[i])
                {
                    c = chars[i];
                    builder.Append(c);
                }
            }

            return builder.ToString();
        }
    }
}
