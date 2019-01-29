using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Problems
{
    /// <summary>
    /// https://leetcode.com/problems/minimum-area-rectangle/
    /// </summary>
    public class P939
    {
        public object Run()
        {
            return null;
        }

        public int MinAreaRect(int[][] points)
        {
            var map = new Dictionary<int, HashSet<int>>();
            var area = int.MaxValue;

            foreach (var point in points)
            {
                if (!map.ContainsKey(point[0]))
                {
                    map[point[0]] = new HashSet<int>();
                }
                map[point[0]].Add(point[1]);
            }

            for (var i = 0; i < points.Length; ++i)
            {
                for (var j = i + 1; j < points.Length; ++j)
                {
                    if (points[i][0] == points[j][0] || points[i][1] == points[j][1])
                    {
                        continue;
                    }
                    if (map[points[i][0]].Contains(points[j][1]) && map[points[j][0]].Contains(points[i][1]))
                    {
                        area = Math.Min(area, Math.Abs((points[i][0] - points[j][0]) * (points[i][1] - points[j][1])));
                    }

                }
            }

            return area == int.MaxValue ? 0 : area;
        }
    }
}
