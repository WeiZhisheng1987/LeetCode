using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Problems
{
    /// <summary>
    /// https://leetcode.com/problems/word-ladder/
    /// </summary>
    public class P127
    {
        public object Run()
        {
            var words = new List<string>() { "hot", "dot", "dog", "lot", "log" };

            return LadderLength("hit", "cog", words);
        }

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (beginWord == endWord)
            {
                return 0;
            }

            var wordSet = new HashSet<string>(wordList);
            var currentWords = new HashSet<string>() { beginWord };

            if (!wordSet.Contains(endWord))
            {
                return 0;
            }

            return LadderLength(currentWords, endWord, wordSet, 1);
        }

        private int LadderLength(HashSet<string> currentWords, string endWord, HashSet<string> wordSet, int level)
        {
            if (wordSet.Count == 0 || currentWords.Count == 0)
            {
                return 0;
            }

            foreach (var word in currentWords)
            {
                wordSet.Remove(word);
            }

            var set = new HashSet<string>();
            foreach (var word in currentWords)
            {
                for (var i=0; i<word.Length; ++i)
                {
                    var chars = word.ToCharArray();
                    for (var c = 'a'; c <= 'z'; ++c)
                    {
                        chars[i] = c;
                        var s = new string(chars);

                        if (wordSet.Contains(s) && s == endWord)
                        {
                            return level + 1;
                        }

                        if (wordSet.Contains(s))
                        {
                            set.Add(s);
                        }
                    }
                }
            }

            return LadderLength(set, endWord, wordSet, level+1);
        }
    }
}
