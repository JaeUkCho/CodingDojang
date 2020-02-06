using System;
using System.Collections.Generic;

namespace GeneratorNexon
{
    class Program
    {
        static int MAX = 5000;
        static void Main(string[] args)
        {
            int result = CalculateProcess();
            
            Console.WriteLine(result);
        }

        static int CalculateProcess()
        {
            List<int> resultList = new List<int>();
            
            for (int i = 1; i <= MAX; i++)
            {
                int generatorNumber = Generator(i);
                if (generatorNumber <= MAX && !resultList.Contains(generatorNumber))
                {
                    resultList.Add(Generator(i));
                }                
            }

            int result = 0;

            for (int i = 1; i <= MAX; i++)
            {
                if (!resultList.Contains(i))
                {
                    result += i;
                }                
            }           

            return result;
        }

        static int Generator(int number)
        {
            int result = 0;
            
            int originalNumber = number;

            while (number > 0)
            {
                result += number % 10;
                number /= 10;
            }

            return originalNumber + result;
        }
    }
}
