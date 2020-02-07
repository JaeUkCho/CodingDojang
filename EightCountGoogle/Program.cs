using System;

namespace EightCountGoogle
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
            int count = 0;

            for (int i = 1; i <= 10000; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if (j % 10 == 8)
                    {
                        count++;
                    }
                    
                    j /= 10;                    
                }
            }           

            return count;
        }             
    }
}
