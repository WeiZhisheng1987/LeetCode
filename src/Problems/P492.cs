using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Problems
{
    /// <summary>
    /// https://leetcode.com/problems/construct-the-rectangle/
    /// </summary>
    public class P492
    {
        public int[] ConstructRectangle(int area)
        {
            var length = (int)Math.Sqrt(area);

            while (area % length != 0)
            {
                length++;
            }
            return new int[] { length, area / length };
        }
    }
}
