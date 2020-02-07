using System;

namespace OilerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = CalculatorProcess();

            Console.WriteLine(result);
        }

        static int CalculatorProcess()
        {
            int result = 0;

            for (int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    result += i;
                }
            }

            return result;
        }
    }
}
