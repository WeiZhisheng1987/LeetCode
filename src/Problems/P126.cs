using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
    /// <summary>
    /// https://leetcode.com/problems/word-ladder-ii/
    /// </summary>
    public class P126
    {
        public object Run()
        {
            var words = new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" };

            return FindLadders("hit", "cog", words);
        }

        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            var wordSet = new HashSet<string>(wordList);
            var currentWords = new Dictionary<string, IList<IList<string>>>();
            var paths = new List<IList<string>>();
            paths.Add(new List<string>() { beginWord });
            currentWords.Add(beginWord, paths);

            if (!wordSet.Contains(endWord))
            {
                return new List<IList<string>>();
            }

            return FindLadders(currentWords, endWord, wordSet);
        }

        private IList<IList<string>> FindLadders(Dictionary<string, IList<IList<string>>> currentWords, string endWord, HashSet<string> wordSet)
        {
            if (wordSet.Count == 0 || currentWords.Count == 0)
            {
                return new List<IList<string>>();
            }

            foreach (var kv in currentWords)
            {
                wordSet.Remove(kv.Key);
            }

            var set = new Dictionary<string, IList<IList<string>>>();
            var result = new List<IList<string>>();
            foreach (var kv in currentWords)
            {
                var word = kv.Key;
                var paths = kv.Value;
                for (var i = 0; i < word.Length; ++i)
                {
                    var chars = word.ToCharArray();
                    for (var c = 'a'; c <= 'z'; ++c)
                    {
                        chars[i] = c;
                        var s = new string(chars);

                        if (wordSet.Contains(s))
                        {
                            var newPaths = new List<IList<string>>();
                            foreach (var path in paths)
                            {
                                var newPath = new List<string>(path);
                                newPath.Add(s);
                                newPaths.Add(newPath);

                                if (s == endWord)
                                {
                                    result.Add(newPath);
                                }
                            }
                            if (set.ContainsKey(s))
                            {
                                foreach (var path in newPaths)
                                {
                                    set[s].Add(path);
                                }
                            }
                            else
                            {
                                set.Add(s, newPaths);
                            }
                        }
                    }
                }
            }

            if (result.Count == 0)
            {
                return FindLadders(set, endWord, wordSet);
            }
            else
            {
                return result;
            }
        }
    }
}
