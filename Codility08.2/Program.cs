/*
A non-empty array A consisting of N integers is given.

The leader of this array is the value that occurs in more than half of the elements of A.

An equi leader is an index S such that 0 ≤ S < N − 1 and two sequences A[0], A[1], ..., A[S] and A[S + 1], A[S + 2], ..., A[N − 1] have leaders of the same value.

For example, given array A such that:

    A[0] = 4
    A[1] = 3
    A[2] = 4
    A[3] = 4
    A[4] = 4
    A[5] = 2
we can find two equi leaders:

0, because sequences: (4) and (3, 4, 4, 4, 2) have the same leader, whose value is 4.
2, because sequences: (4, 3, 4) and (4, 4, 2) have the same leader, whose value is 4.
The goal is to count the number of equi leaders.

Write a function:

class Solution { public int solution(int[] A); }

that, given a non-empty array A consisting of N integers, returns the number of equi leaders.

For example, given:

    A[0] = 4
    A[1] = 3
    A[2] = 4
    A[3] = 4
    A[4] = 4
    A[5] = 2
the function should return 2, as explained above.

Write an efficient algorithm for the following assumptions:

N is an integer within the range [1..100,000];
each element of array A is an integer within the range [−1,000,000,000..1,000,000,000].
*/

using System;

namespace Codility08._2
{
    class Solution
    {
        public int solution(int[] A)
        {
            int s = 0;
            int val = 0;
            int size = 0;
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (size == 0)
                {
                    size++;
                    val = A[i];
                }
                else if (val != A[i])
                    size--;
                else
                    size++;
            }
            for (int j = 0; j < A.Length; j++)
                if (A[j] == val)
                    count++;
            if (count > A.Length / 2)
            {
                int leader = val;
                int leftCount = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    if (leader == A[i])
                        leftCount++;
                    if (leftCount > (i + 1) / 2)
                    {
                        int rightCount = count - leftCount;
                        if (rightCount > (A.Length - i - 1) / 2)
                            s++;
                    }
                }
            }
            return s;
        }
    }

    class Program
    {
        static void Main()
        {
            Solution sol = new Solution();
            //int[] A = { 4, 3, 4, 4, 4, 2 };
            //int[] A = { 4, 4, 2, 5, 3, 4, 4, 4 };
            Random r = new Random();
            int[] A = new int[300];
            for (int i = 0; i < 50; i++)
                A[i] = r.Next();
            for (int i = 50; i < 250; i++)
                A[i] = -1000000000;
            for (int i = 250; i < 300; i++)
                A[i] = r.Next();
            int s = sol.solution(A);
            Console.WriteLine("Solution: " + s);
            //Console.WriteLine("Solution: " + string.Join(", ", s));
        }
    }
}
