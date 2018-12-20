using System;

namespace OnlineQuizSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            IsPESEL();
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
    }
}
