using System;
using System.IO;

namespace Task3
{
    class Task3
    {
        static void Main(string[] args) 
        {
            string[] parametersArray = new string[3];
            int firstNumber = 0;
            int secondNumber = 0;
            int sum = 0;
            long result = 0;
            string pathToFile = "";

            if (args.Length == 1)
			{
                pathToFile = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + args[0];
			}
			
            try
            {
                using (StreamReader sr = new StreamReader(pathToFile))
                {
                    parametersArray = sr.ReadLine().Split(' ');                
                }

                firstNumber = int.Parse(parametersArray[0]);
                secondNumber = int.Parse(parametersArray[1]);
                sum = int.Parse(parametersArray[2]);

                result = findMaxProduct(sum, firstNumber, secondNumber);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static long findMaxProduct(int sum, int firstNumber, int secondNumber)
        {
            long firstResult = 0;
            long secondResult = 0;

            if (sum - firstNumber > 0)
			{
                firstResult = firstNumber * findMaxProduct(sum - firstNumber, firstNumber, secondNumber);
			}
            else if (sum - firstNumber == 0)
			{
                firstResult = firstNumber;
			}
			
            if (sum - secondNumber > 0)
			{
                secondResult = secondNumber * findMaxProduct(sum - secondNumber, firstNumber, secondNumber);
            }
			else if (sum - secondNumber == 0)
			{
                secondResult = secondNumber;
			}
			
            return Math.Max(firstResult, secondResult);
        }
    }
}
