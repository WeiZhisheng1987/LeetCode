using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Problems
{
    /// <summary>
    /// https://leetcode.com/problems/keyboard-row
    /// </summary>
    public class P500
    {
        public object Run()
        {
            var array = new string[] { "Hello", "Alaska", "Dad", "Peace" };
            return FindWords(array);
        }

        public string[] FindWords(string[] words)
        {
            var firstRow = new HashSet<char>() { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
            var secondRow = new HashSet<char>() { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };
            var thirdRow = new HashSet<char>() { 'z', 'x', 'c', 'v', 'b', 'n', 'm' };

            var result = new List<string>();
            foreach (var word in words)
            {
                if (word.Length == 0)
                {
                    result.Add(word);
                }

                var firstChar = ToLowercase(word[0]);
                HashSet<char> set = null;
                set = firstRow.Contains(firstChar) ? firstRow : secondRow.Contains(firstChar) ? secondRow : thirdRow.Contains(firstChar) ? thirdRow : null;

                if(set == null)
                {
                    continue;
                }

                foreach(var c in word)
                {
                    if(!set.Contains(ToLowercase(c)))
                    {
                        set = null;
                        break;
                    }
                }
                if (set != null)
                {
                    result.Add(word);
                }
            }
            return result.ToArray();
        }

        public char ToLowercase(char c)
        {
            return Char.ToLower(c);
        }
    }
}
