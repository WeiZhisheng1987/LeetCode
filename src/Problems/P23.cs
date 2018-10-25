using System;
using System.Collections.Generic;

namespace LeetCode.Problems
{
    /// <summary>
    /// https://leetcode.com/problems/merge-k-sorted-lists/
    /// </summary>
    public class P23
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
            {
                return null;
            }

            var header = new ListNode(0);
            var cursor = header;
            var headers = new List<ListNode>();

            Array.Sort(lists, (i1, i2) => i1 == null ? 1 : (i2 == null ? -1 : i1.val - i2.val));

            while (lists[0] != null)
            {
                cursor.next = lists[0];
                cursor = cursor.next;

                var node = lists[0].next;
                var index = 1;
                while(index<lists.Length && (node==null || (lists[index]!=null && lists[index].val<node.val)))
                {
                    lists[index - 1] = lists[index];
                    index++;
                }
                lists[index - 1] = node;
            }

            return header.next;
        }
    }
}
