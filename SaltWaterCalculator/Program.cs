using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SaltWaterCalculator
{
    class Program
    {
         static void Main(string[] args)
        {
            List<SaltWater> inputList = inputProcess();

            string result = calculateProcess(inputList);

            Console.WriteLine(result);     
        }

        static string calculateProcess(List<SaltWater> paramList)
        {
            double saltAmount = 0;
            double totalAmount = 0;           

            for (int i = 0; i < paramList.Count; i++)
            {
                double salt = paramList[i].Amount * paramList[i].Percentage / 100;
                
                saltAmount += salt;
                totalAmount += paramList[i].Amount;           
            }   

            double resultPercent = Math.Round(saltAmount / totalAmount * 100, 2);
            double resultAmount = Math.Round(totalAmount, 2);

            return $"{resultPercent}% {resultAmount}g";
        }

        static List<SaltWater> inputProcess()
        {
            Console.WriteLine("Please the percentage concentration of salt water and the amount of salt water.(ex. 12.245% 21.258g)");

            List<SaltWater> inputList = new List<SaltWater>();

            for (int i = 0; i < 10; i++)
            {
                double percentage;
                double amount;
               
                while (true)
                {
                    string inputString = Console.ReadLine();

                    if (inputString == "end")
                    {
                        return inputList;                        
                    }

                    Regex regexInput = new Regex(@"(\d+(?:\.\d+)?)%\s(\d+(?:\.\d+)?)g");
                    Match matchInput = regexInput.Match(inputString);
                    
                    if (matchInput.Success)
                    {
                        if (double.TryParse(matchInput.Groups[1].Value, out percentage) && double.TryParse(matchInput.Groups[2].Value, out amount))
                        {
                            break;                            
                        }
                        else
                        {
                            Console.WriteLine("Cannot convert Double");
                        }                        
                    }
                    else
                    {
                        Console.WriteLine("Please enter according to the form. (ex. 12.245% 21.258g)");
                    }
                }

                SaltWater saltWater = new SaltWater(percentage, amount);                

                inputList.Add(saltWater);
            }

            return inputList; 
        }
    }

    public class SaltWater
    {
        public double Percentage { get; set; }
        public double Amount { get; set; }

        public SaltWater(double percentage, double amount)
        {
            Percentage = percentage;
            Amount = amount;
        }
    }
}
