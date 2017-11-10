using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankExerciseUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int n = 6;//Convert.ToInt32(Console.ReadLine());
            int k = 3; //Convert.ToInt32(Console.ReadLine());
            string s = "092282"; // Console.ReadLine();
            string result = richieRich(s, n, k);
            Console.WriteLine(result);
        }

        static int IsNumericString(string input, int t)
        {
            int.TryParse(input, out t);
            return t;
        }

        static string richieRich(string input, int length, int noOfDigitsToChange)
        {
            int mid = length / 2;
            int mid2 = mid;
            int k = noOfDigitsToChange;
            int i, num1, num2, t = 0;
            int max = Convert.ToInt32(Math.Pow(10, 5));
            char[] output = input.ToCharArray();

            if ((length <= 0 || length >= max) || (k <= 0 || k >= max) || !(Convert.ToBoolean(IsNumericString(input, t))))
                return "-1";

            if (length % 2 == 0)
            {
                mid2 = mid - 1;
            }

            for (i = 0; i < mid;)
            {
                num1 = input[mid + i] - '0';
                num2 = input[mid2 - i] - '0';
                if (num1 != num2)
                {
                    if (num1 < num2)
                        output[mid + i] = num2.ToString()[0];
                    else if (num1 > num2)
                        output[mid2 - i] = num1.ToString()[0];
                    k--;
                }

                i++;

                if (k <= 0)
                    break;
            }

            //Now check if resultant string is Palindrom
            string result = new string(output);
            if (isPalindrom(result))
                return result ;
            else
                return "-1";

        }

        static bool isPalindrom(string input)
        {
            int i;
            int j = input.Length;
            for (i = 0; i < input.Length / 2; i++)
            {
                if (input[i] != input[j - 1])
                    break;
                j--;
            }
            if (i >= j)
                return true;
            else
                return false;
        }

    }
}
