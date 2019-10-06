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
            int value = 0;

            //Input validation using try block
            try
            {
                Boolean begin = false;

                //variable to parse the array
                int i;

                //For loop for location the value in the array
                for (i = 0; i < nums.Length; i++)
                {
                    //if the element is found in the array
                    if (nums[i] == target || nums[i] > target)
                    {
                        begin = true;
                        value = i;
                        break;
                    }
                }//Loop Ends

                //If not found in the array
                if (!begin)
                {
                    return nums.Length;
                    //Returning the current array's length where the target value can be inserted
                }

                return value;

            }//Ending try block

            //to show exception message
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            } //Ending catch block

            return value;
        }//End of the method SearchInsert()
        // ===================================================================================================//

        // Question 2 :Function displays Intersection of arr1[] and arr2[]
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            //validating user input
            try
            {
                int i = 0, j = 0; // declaring variables for using in the while loop

                //Defining range 
                while (i < nums1.Length && j < nums2.Length)
                {
                    if (nums1[i] < nums2[j])
                        i++;

                    else if (nums2[j] < nums1[i])
                        j++;

                    else
                    {
                        Console.Write(nums2[j++] + ",");
                        i++;
                    }
                }//while loop ends
            }//Ending try block

            //Using catch block to give exception message
            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
            }//End of catch block

            return new int[] { };//Returing the resulting interacted array
        }
        // ===========================================================================================//

        //Question 3: Method to print largest unique number in a given array
        public static int LargestUniqueNumber(int[] A)
        {
            int maxValue = 0;

            //Using try block to validate user input
            try
            {
                // Using reference from code https://bit.ly/2nsrRi0 to check the element occurs once in the array.
                var singles = A.GroupBy(x => x).Where(g => !g.Skip(1).Any()).SelectMany(g => g);

                //Using IF condition to check the whether it is not empty.
                if (singles.Count() != 0)
                {
                    maxValue = singles.Max(); //To find the largest element in the resulting array
                }
                else
                    return -1;

            }//Ending try block

            //Using catch block to show exception if error encountered
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }//Ending catch block

            return maxValue;

        }//End ofmethod
        // ===========================================================================================//

        // Question 4 //
        public static int CalculateTime(string keyboard, string word)
        {
            //Checking for constriants  
            try
            {
                // setting keyboard and word characters to lower case.
                keyboard = keyboard.ToLower();
                word = word.ToLower();

                //verifying for keyboard has 26 characters and the word length is allowed
                if (keyboard.Length != 26 || word.Length < 1 || word.Length > 10000)
                {
                    return -1;
                }
                //Using a blank ditionary to hold all the keyboard values
                Dictionary<int, int> key = new Dictionary<int, int>();
                foreach (char a in keyboard)
                {
                    //adding each keyboard character to dictionary and its corresponding index number
                    if (!key.ContainsKey(a))
                        key[a] = keyboard.IndexOf(a);
                }

                //initializing the time counter
                int totaltime = 0;

                // intial previous position for parseing through keyboard
                char prev = keyboard[0];

                // iterating through word and getting the absolute value of the length between index positions
                foreach (char curr in word.ToCharArray())
                {
                    totaltime += Math.Abs(key.GetValueOrDefault(curr) - key.GetValueOrDefault(prev));
                    prev = curr;
                }
                //return length of time
                return totaltime;
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
