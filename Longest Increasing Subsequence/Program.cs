using System;
using System.Linq;

namespace Longest_Increasing_Subsequence
{
    class Program
    {
        static void Main()
        {
            int n = 20;
            int[] array = {
                // Longest increasing subsequence is 21, 42, 65
                92, 93, 55, 6, 54, 41, 21, 42, 65, 44, 76, 31, 90, 73, 89, 72, 48, 52, 8, 76
            };

            OutputLis(array, n);
        }

        static void OutputLis(int[] array, int n)
        {
            // If the entire array were in decreasing order or all the same value,
            // then the longest increasing subsequence would be a single element.
            // So we'll start with the first element as our base case.

            // Track the longest overall LIS.
            int lisLength = 1;
            int lisStart = 0; // Inclusive
            int lisEnd = 1; // Exclusive

            // Tracking variable for the current LIS we are examining.
            int currLisLength = 1;
            int currLisStart = 0; // Inclusive
            int currLisEnd = 1; // Exclusive

            // Loop over the rest of the array
            for (int i = 1; i < n; i++)
            {
                // If the element is larger than the last element, it is part of our current LIS.
                if (array[i] > array[i - 1])
                {
                    currLisLength++;
                    currLisEnd = i + 1;
                }
                // If the i'th element is part of a new increasing subsequence, we need to evaluate
                // if the subsquence that just ended is larger than our previous largest subsequence
                else
                {
                    if (currLisLength > lisLength)
                    {
                        lisLength = currLisLength;
                        lisStart = currLisStart;
                        lisEnd = currLisEnd;
                    }

                    // Now that we've processed the subsequence that just ended,
                    // store the beginning of the new subsequence.
                    currLisLength = 1;
                    currLisStart = i;
                    currLisEnd = i + 1;
                }
            } // End of for loop.

            // After we've finished looping over the elements of the array,
            // we need one last check to evaluate the last subsequence.
            if (currLisLength > lisLength)
            {
                // ReSharper disable once RedundantAssignment
                lisLength = currLisLength;
                lisStart = currLisStart;
                lisEnd = currLisEnd;
            }

            // Now we can output the Longest Increasing Subsequence to the user.
            Console.WriteLine("Array: {0}", String.Join(", ", array));
            Console.WriteLine("Longest Increasing Subsequence: {0}", 
                String.Join(", ", array.Skip(lisStart).Take(lisEnd-lisStart).ToArray()));
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
        }
    }
}
