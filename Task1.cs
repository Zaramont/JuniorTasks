using System;
using System.IO;

namespace Task1
{
    class Task1
    {
        static void Main(string[] args)
        {
            double a = 1;
            double b = 1.2;
            double c = -20;
            double d = 0;
            double e = 123.456;
            string pathToFile = "";

            if (args.Length == 1)
			{
                pathToFile = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + args[0];
			}
			
            try
            {
                using (StreamReader sr = new StreamReader(pathToFile))
                {
                    string currentLine = sr.ReadLine();
                    int numberOfValues = int.Parse(currentLine);

                    while(numberOfValues > 0)
                    {
                        currentLine = sr.ReadLine();
                        double x = double.Parse(currentLine);
                        double result = a * Math.Pow(x, 4) + b * Math.Pow(x, 3) + c * Math.Pow(x, 2) + d * x + e;
                        Console.WriteLine(String.Format("{0:0.000}", result));
						numberOfValues--;
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
