using System;
using System.IO;

namespace Task2
{
    class Task2
    {
        static void Main(string[] args)
        {
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
                    int numberOfWheels = int.Parse(currentLine.Split(' ')[0]);
                    int totalWheelsResource = int.Parse(currentLine.Split(' ')[1]);
                    double totalWheelsWearRate = 0.0;
					double maxPathLength = 0.0;

                    for(; 0 < numberOfWheels; numberOfWheels--)
                    {
                        currentLine = sr.ReadLine();
                        int wheelWearRate = int.Parse(currentLine);
                        totalWheelsWearRate += 1.0 / wheelWearRate;
                    }

                    maxPathLength = totalWheelsResource / totalWheelsWearRate;
                    Console.WriteLine(String.Format("{0:0.000}", maxPathLength));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
