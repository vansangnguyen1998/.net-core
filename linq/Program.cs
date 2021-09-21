using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            #region sqrNo
            var arr1 = new List<int>() { 3, 9, 2, 8, 6, 5 };
            var result = arr1.Where(a => a * a > 20).Select(x => new OutputLinq(x, x * x)).ToList();
            Console.WriteLine(result.ToString());
            #endregion

            #region Write a program to generate a Cartesian Product of three sets.

            char[] charset1 = { 'X', 'Y', 'Z' };
            int[] numset1 = { 1, 2, 3 };
            string[] colorset1 = { "Green", "Orange" };

            Console.Write("\nLINQ : Generate a cartesian product of three sets : ");
            Console.Write("\n----------------------------------------------------\n");

            var cartesianProduct = from letter in charset1
                                   from number in numset1
                                   from colour in colorset1
                                   select new { letter, number, colour };

            Console.Write("The Cartesian Product are : \n");
            foreach (var ProductList in cartesianProduct)
            {
                Console.WriteLine(ProductList);
            }

            #endregion

            #region count times number

            arr1 = new List<int> { 5, 9, 1, 5, 5, 9 };
            Console.Write("\nLINQ : Display the number and frequency of number from given array : \n");

            var n = from x in arr1
                    group x by x into y
                    select y;
            Console.WriteLine("\nThe number and the Frequency are : \n");
            foreach (var arrNo in n)
            {
                Console.WriteLine("Number " + arrNo.Key + " appears " + arrNo.Count() + " times");
            }
            Console.WriteLine("\n");

            #endregion

        }
    }

    class OutputLinq
    {
        public int Number { get; set; }
        public int SqrNo { get; set; }

        public OutputLinq(int number, int sqrNo)
        {
            Number = number;
            SqrNo = sqrNo;
        }
    }
}
