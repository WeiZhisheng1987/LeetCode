using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Problems
{
    /// <summary>
    /// https://leetcode.com/problems/masking-personal-information/
    /// </summary>
    public class P831
    {
        public string MaskPII(string S)
        {
            if (string.IsNullOrEmpty(S) || S.Length > 40)
            {
                return "";
            }

            if (S.IndexOf('@') >= 0)
            {
                return MaskEmail(S);
            }

            return MaskPhoneNumber(S);
        }

        private string MaskEmail(string s)
        {
            var lowerCase = s.ToLower();
            var index = s.IndexOf('@');
            return lowerCase[0] + new string('*', 5) + lowerCase[index - 1] + lowerCase.Substring(index);
        }

        private string MaskPhoneNumber(string s)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var c in s)
            {
                if(c >= '0' && c<= '9')
                {
                    builder.Append(c);
                }
            }

            if (builder.Length > 10)
            {
                return "+" + new string('*', builder.Length-10) + "-***-***-" + builder.ToString().Substring(builder.Length-4);
            }
            else
            {
                return "***-***-" + builder.ToString().Substring(builder.Length - 4);
            }
        }
    }
}
