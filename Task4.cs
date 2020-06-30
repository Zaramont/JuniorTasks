using System;
using System.IO;

namespace Task4
{
    class Task4
    {
        static void Main(string[] args) 
        {
			string pathToFile = "";
			int whiteMice = 0;
			int blackMice = 0;
			
            if (args.Length == 1)
			{
                pathToFile = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + args[0];
			}
			
            try
            {
                using (StreamReader sr = new StreamReader(pathToFile))
                {
                    string currentLine = sr.ReadLine();
                    whiteMice = int.Parse(currentLine.Split(' ')[0]);
                    blackMice = int.Parse(currentLine.Split(' ')[1]);
				}
				int result = FindAmountOfMoves(whiteMice, blackMice);
				Console.WriteLine(result);
				
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static int FindAmountOfMoves(int whiteMiceAmount, int blackMiceAmount) 
        {
            return whiteMiceAmount * blackMiceAmount + whiteMiceAmount + blackMiceAmount;
        }	      
    }
}
