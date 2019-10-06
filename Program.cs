using System;
using System.Collections.Generic;
using System.Linq;

namespace DIS_Assignment2
{

    class Program
    {
        public static void Main(string[] args)
        {
            int target = 5;
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            Console.WriteLine("Intersection of two arrays is: ");
            int[] intersect = Intersect(nums1, nums2);
            DisplayArray(intersect);
            Console.WriteLine("\n");

            int[] A = { 5, 7, 3, 9, 4, 9, 8, 8, 1 };
            Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
            Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

            int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
            int[,] flipAndInvertedImage = FlipAndInvertImage(image);
            Console.WriteLine("The resulting flipped and inverted image is:\n");
            Display2DArray(flipAndInvertedImage);
            Console.Write("\n");

            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
            int minMeetingRooms = MinMeetingRooms(intervals);
            Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);

            int[] arr = { -4, -1, 0, 3, 10 };
            int[] sortedSquares = SortedSquares(arr);
            Console.WriteLine("Squares of the array in sorted order is:");
            DisplayArray(sortedSquares);
            Console.WriteLine("\n");

            string s = "abca";
            if (ValidPalindrome(s))
            {
                Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
            }
            else
            {
                Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
            }
        }

        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }

        public static void Display2DArray(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }

        // ===================================================================================//
        // Question 1 to find the index of the target number in the array.
        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }

            return 0;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
            }

            return new int[] { };
        }

        public static int LargestUniqueNumber(int[] A)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }

            return 0;
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }
        // ===========================================================================================//

        // Question 5 //
        public static int[,] FlipAndInvertImage(int[,] A)
        {
            try
            {
                //initializing a multi dimentional array
                int[,] answer5 = new int[3, 3];
                //looping through array to invert and flip
                for (int i = 0; i < 3; i++)
                {
                    int inv = 2;
                    for (int j = 0; j < 3; j++)
                    {
                        //flipping zero's to ones and placing it in the inverted position
                        if (A[i, j] == 0)
                        {
                            answer5[i, inv] = 1;
                            inv--;
                        }
                        else
                        {
                            answer5[i, inv] = 0;
                            inv--;
                        }
                    }
                }
                //return answer after data transformation
                return answer5;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }

            return new int[,] { };
        }

        // ====================================================================================================//
        
        /// Question6: The MinMeetingRooms method determines how few meeting rooms will be required based on a meeting schedule.
        public static int MinMeetingRooms(int[,] intervals)
        {
            int max = 0;
            int Use = 0;
            List<int> startime = new List<int>();
            List<int> endtime = new List<int>();
            int start = 0;
            int end = 0;

            try
            {
                //for all start and end times.
                for (int i = 0; i < intervals.GetLength(0); i++)
                {
                    startime.Add(intervals[i, 0]);
                    endtime.Add(intervals[i, 1]);
                }
                //sorting start and end times
                startime.Sort();
                endtime.Sort();

                //Loop through start and end times lists 
                while (start < startime.Count && end < startime.Count)
                {
                    if (startime[start] <= endtime[end])
                    {
                        Use++;

                        //if use is greater than max then overwrite maximum
                        if (Use > max)
                        {
                            max = Use;
                        }

                        //increment starting times 
                        start++;
                    }

                    else
                    {
                        //decrease number in use
                        Use--;

                        //increment ending times
                        end++;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MinMeetingRooms()");
            }

            //return final maximum number of required rooms
            return max;
        }
        // ==================================================================================================//
        

        
        // Question 7 Sorted Squares array
        public static int[] SortedSquares(int[] A)
        {
            //array for holding the output
            int[] sortedAR = new int[A.Length];
            int positive = 0;
            
            try
            {
                //Loop for finding the index of the first positive number in the array
                foreach (int a in A)
                {
                    positive++;

                    //breaking the loop when 1st +ve number is found
                    if (a >= 0)
                    {
                        break;
                    }
                }

                //variable to hold current position in the output array
                int outputIndex = 0;
                int negative = positive - 1;
                

                //Starting the array from the middle
                while (negative >= 0 && positive < A.Length)
                {
                    if (A[negative] * A[negative] < A[positive] * A[positive])
                    {
                        //Adding to array if negative has a bigger square value
                        sortedAR[outputIndex] = A[negative] * A[negative];
                        negative--;
                    }
                    else
                    {
                        //Adding to array if positive has a bigger square value
                        sortedAR[outputIndex] = A[positive] * A[positive];
                        positive++;
                    }
                    outputIndex++;
                }

                //populating remaining negative values 
                while (negative >= 0)
                {
                    sortedAR[outputIndex++] = A[negative] * A[negative];
                    negative--;
                }
                //adding remaining positive values to array
                while (positive < A.Length)
                {
                    sortedAR[outputIndex++] = A[positive] * A[positive];
                    positive++;
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing SortedSquares()");
            }

            //returning final array
            return sortedAR;
        }
        // ========================================================================================================//
        
        /// The ValidPalindrome method determines whether a string can be a palindrome by removing either 0 or 1 characters.
        
        // Question 8: Valud Palindrome //
        public static bool ValidPalindrome(string s)
        {
            try
            {
                // Checking for whether the string is already a Palindrome or not
                if (isPalindrome(s))
                {
                    return true;
                }

                //By removing each character checking for being a Palidrome
                for (int i = 0; i < s.Length; i++)
                {
                    //if string without character[i] is a palindrome, return true
                    if (isPalindrome(s.Remove(i, 1)))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome()");
            }

            return false;
        }

        public static bool isPalindrome(string s)
        {
            //converting string to array of 
            char[] stringReversed = s.ToCharArray();

            //reversing char array
            Array.Reverse(stringReversed);

            //if reversed string == orignal string, return true
            if (new String(stringReversed) == s)
            {
                return true;
            }

            //otherwise, return false
            return false;
        }
    }

}
