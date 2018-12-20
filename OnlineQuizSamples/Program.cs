using System;
using System.Linq;

namespace OnlineQuizSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //IsPESEL();

            MathOp();
        }

        public static void IsPESEL()
        {
            var myInput = Console.ReadLine().Trim();
            Console.WriteLine(myInput);

            if (string.IsNullOrEmpty(myInput))
            {
                return;
            }

            var count = Convert.ToInt16(myInput);

            while (count > 0)
            {
                myInput = Console.ReadLine().Trim();
                if (myInput.Length != 11)
                {
                    Console.WriteLine("N");
                }
                else
                {
                    var sum = myInput[0].ToInt() + myInput[10].ToInt() +
                        myInput[4].ToInt() + myInput[8].ToInt() +
                        (myInput[1].ToInt() + myInput[9].ToInt() + myInput[5].ToInt()) * 3 +
                        (myInput[2].ToInt() + myInput[6].ToInt()) * 7 +
                        (myInput[3].ToInt() + myInput[7].ToInt()) * 9;
                    if (sum % 10 == 0)
                        Console.WriteLine("Y");
                    else
                        Console.WriteLine("N");
                }
                count--;
            }
        }

        public static void MathOp()
        {
            while (true)
            {
                var myInput = System.Console.ReadLine().Trim();
                System.Console.WriteLine(myInput);

                var subStr = myInput.Split(' ');
                int result = 0;
                if (subStr.Length == 3)
                {
                    var op = subStr[0];
                    if (string.IsNullOrEmpty(subStr[0]) ||
                        string.IsNullOrEmpty(subStr[1]))
                    {
                        continue;
                    }
                    switch (op)
                    {
                        case "+":
                            result = subStr[1].ToInt() + subStr[2].ToInt();
                            break;
                        case "-":
                            result = subStr[1].ToInt() - subStr[2].ToInt();
                            break;
                        case "*":
                            result = subStr[1].ToInt() * subStr[2].ToInt();
                            break;
                        case "/":
                            result = subStr[1].ToInt() / subStr[2].ToInt();
                            break;
                        case "%":
                            result = subStr[1].ToInt() % subStr[2].ToInt();
                            break;
                    }
                    Console.WriteLine(result);
                }
            }
        }

        public static int[][] SumSubsets(int[] arr, int num)
        {
            int[][] final = new int[100][];
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (num == arr[i] + arr[j])
                    {
                        final[count] = new int[2];
                        final[count][0] = arr[i];
                        final[count][1] = arr[j];
                        count++;
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (num == arr[i])
                {
                    final[count] = new int[1];
                    final[count][0] = arr[i];
                    count++;
                }
            }
            return final.Take(count).ToArray();
        }
    }
}
