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
            int[] intersect = Intersect(nums1, nums2);
            Console.WriteLine("Intersection of two arrays is: ");
            DisplayArray(intersect);
            Console.WriteLine("\n");

            int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
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
            Console.Write("\n");

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

        //Custom method to search and insert target in the nums array
        public static int SearchInsert(int[] nums, int target)
        {
            //Declaring index for using it in return method
            int index = 0;

            //Using try block to validate the input
            try
            {
                //Declaring boolean variable
                Boolean found = false;

                //Declaring i variable to iterate the array
                int i;

                //Using for loop to find the element in the array
                for (i = 0; i < nums.Length; i++)
                {
                    //if the element is found in the array
                    if (nums[i] == target || nums[i] > target)
                    {
                        found = true;
                        index = i;
                        break;
                    }
                }//End of for loop
                //If the element is not found in the array
                if (!found)
                {
                    return nums.Length;//Returning the lenghth of the array as the position to insert
                }
                //It's a return method
                return index;

            }//End of try block

            //Using catch block to show exception message
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            } //End of catch block

            return index;
        }//End of the custom method SearchInsert()

        // Function prints Intersection of arr1[] and arr2[]
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            //Using try block to validate user input
            try
            {
                int i = 0, j = 0; // declaring variables to use in the while loop

                while (i < nums1.Length && j < nums2.Length)//Defining range for iteration
                {
                    if (nums1[i] < nums2[j])
                        i++;

                    else if (nums2[j] < nums1[i])
                        j++;

                    else
                    {
                        Console.Write(nums2[j++] + " ,");
                        i++;
                    }//End of else
                }//End of while loop
            }//End of try block

            //Using catch block to give exception message
            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
            }//End of catch block

            return new int[] { };//Returns teh resulting array
        }

        //Method to print largest unique number in a given array
        public static int LargestUniqueNumber(int[] A)
        {
            int max = 0;//declaring a variable to use in the condition

            //Using try block to validate user input
            try
            {
                //Using IEnumerable to make sure the element occurs only once in the array. 
                //This statement will remove elements that appears more than once in the array
                //Source for the code: https://bit.ly/2nsrRi0

                var singles = A.GroupBy(x => x).Where(g => !g.Skip(1).Any()).SelectMany(g => g);

                //Using IF condition to check the IEnumberable is not empty.
                //Source for the code: https://bit.ly/2ob7Xbs
                if (singles.Count() != 0)
                {
                    max = singles.Max(); //Dictionary to find the largest element in the resulting array
                }
                //Using else to return -1 if the resulting array of unique elements is empty.
                else
                    return -1;

            }//End of try block
            //Using catch block to show exception if error encountered
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }//End of catch block

            return max; //Its a return method!
        }//End of the Largest Unique Number method

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                //constraint checks 
                // set keyboard characters and word to lower case
                keyboard = keyboard.ToLower();
                word = word.ToLower();

                //verify that keyboard has 26 character and the word length is allowed
                if (keyboard.Length != 26 || word.Length < 1 || word.Length > 10000)
                {
                    return -1;
                }
                //initialize a blank ditionary to hold all the keyboard values
                Dictionary<int, int> kb = new Dictionary<int, int>();
                foreach (char a in keyboard)
                {
                    //adding each keyboard character to dictionary and its corresponding index number
                    if (!kb.ContainsKey(a))
                        kb[a] = keyboard.IndexOf(a);
                }

                //initializing time counter as ans
                int ans = 0;

                // setting the intial previous position for iterating through keyboard
                char prev = keyboard[0];

                // iterating through word and geting the absolute value of the length between index positions
                foreach (char curr in word.ToCharArray())
                {
                    ans += Math.Abs(kb.GetValueOrDefault(curr) - kb.GetValueOrDefault(prev));
                    prev = curr;
                }
                //return length of time
                return ans;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }

        public static int[,] FlipAndInvertImage(int[,] A)
        {
            try
            {
                //initialize a blan 3x3 multi dimentional array
                int[,] ans = new int[3, 3];
                //loop through array to invert and flip
                for (int i = 0; i < 3; i++)
                {
                    //initilize integer representing last position in an array row
                    int inv = 2;
                    for (int j = 0; j < 3; j++)
                    {
                        //flipping zero's to ones and placing it in the inverted position
                        if (A[i, j] == 0)
                        {
                            ans[i, inv] = 1;
                            inv--;
                        }
                        else
                        {
                            ans[i, inv] = 0;
                            inv--;
                        }
                    }
                }
                //return answer after data transformation
                return ans;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }

            return new int[,] { };
        }


        /// <summary>
        /// The MinMeetingRooms method determines how few meeting rooms will be required based on a meeting schedule.
        /// </summary>
        public static int MinMeetingRooms(int[,] intervals)
        {
            //declaring variables
            List<int> startTimes = new List<int>();
            List<int> endTimes = new List<int>();
            int maximum = 0;
            int inUse = 0;
            int startLoop = 0;
            int endLoop = 0;
            try
            {
                //creating lists of all start and end times.
                for (int i = 0; i < intervals.GetLength(0); i++)
                {
                    startTimes.Add(intervals[i, 0]);
                    endTimes.Add(intervals[i, 1]);
                }
                //sorting start and end time lists
                startTimes.Sort();
                endTimes.Sort();

                //looping through start and end times lists at the same time
                while (startLoop < startTimes.Count && endLoop < startTimes.Count)
                {
                    //if current entry is a start time
                    if (startTimes[startLoop] <= endTimes[endLoop])
                    {
                        //increment number of rooms in use
                        inUse++;

                        //if current in use is greater than max, overwrite maximum
                        if (inUse > maximum)
                        {
                            maximum = inUse;
                        }

                        //increment starting times iterator
                        startLoop++;
                    }

                    //if current entry is a end time
                    else
                    {
                        //decrease number in use
                        inUse--;

                        //increment ending times iterator
                        endLoop++;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MinMeetingRooms()");
            }

            //return maximum number of required rooms int
            return maximum;
        }

        /// <summary>
        /// The SortedSquares method takes an array of integers sorted in ascencing order, and returns a sorted array of their squares.
        /// It squares the positive numbers in ascending order, and the negative numbers in descending order. This prevents the use of a second loop required to sort the numbers
        /// </summary>

        public static int[] SortedSquares(int[] A)
        {
            //initalizing an array to hold the output
            int[] output = new int[A.Length];

            //creating a variable to hold the position of the iterator for positive numbers
            int pos = 0;
            try
            {

                //finding the index of the first positive number in the array
                foreach (int a in A)
                {
                    //incrementing the positive iterator each loop
                    pos++;

                    //breaking loop when first positive number is found
                    if (a >= 0)
                    {
                        break;
                    }
                }
                //integer to hold negative iterator
                int neg = pos - 1;
                //index to hold current position in output array
                int outputIndex = 0;

                //looping through array from the middle. Going up and down from zero.
                while (neg >= 0 && pos < A.Length)
                {
                    //determining if the left or right size number has the biggest square
                    if (A[neg] * A[neg] < A[pos] * A[pos])
                    {
                        //if negative has the bigger square add to array
                        output[outputIndex] = A[neg] * A[neg];
                        neg--;
                    }
                    else
                    {
                        //if positive has the bigger square add to array
                        output[outputIndex] = A[pos] * A[pos];
                        pos++;
                    }
                    outputIndex++;
                }
                //adding remaining negative values to array
                while (neg >= 0)
                {
                    output[outputIndex++] = A[neg] * A[neg];
                    neg--;
                }
                //adding remaining positive values to array
                while (pos < A.Length)
                {
                    output[outputIndex++] = A[pos] * A[pos];
                    pos++;
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing SortedSquares()");
            }

            //returning final array
            return output;
        }

        /// <summary>
        /// The ValidPalindrome method determines whether a string can be a palindrome by removing either 0 or 1 characters.
        /// </summary>
        public static bool ValidPalindrome(string s)
        {
            try
            {
                //checking if string is already a palindrome
                //if so, returning true
                if (isPalindrome(s))
                {
                    return true;
                }
                //checking if palindrome by removing each character
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

            //if not a palindrome, and can't be made into a palindrome by removing a character, return false.
            return false;
        }

        /// <summary>
        /// The isPalindrome method takes a string, and returns a boolean indicating whether it is a palindrome or not
        /// </summary>
        public static bool isPalindrome(string s)
        {
            //converting string to char array
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
