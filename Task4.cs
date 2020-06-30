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
				
				/*int result = CountAmountOfMoves(whiteMice, blackMice);
				Console.WriteLine(result);
				*/
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
		
        static int CountAmountOfMoves(int whiteMiceAmount, int blackMiceAmount)
        {
            int counterOfMoves = 0;
            bool isCountFinished = false;
            int indexOfEmptyCell = whiteMiceAmount;            
            char[] field = new char[whiteMiceAmount + blackMiceAmount + 1];

            for (int j = 0; j < field.Length; j++)
            {
                if (j < indexOfEmptyCell)
                    field[j] = 'Б';
                else if (j == indexOfEmptyCell)
                    field[j] = ' ';
                else
                    field[j] = 'Ч';
            }

            while (isCountFinished != true)
            {
                if (indexOfEmptyCell >= 2 && field[indexOfEmptyCell - 2] == 'Б' && field[indexOfEmptyCell - 1] == 'Ч')
                {
                    field[indexOfEmptyCell - 2] = ' ';
                    field[indexOfEmptyCell] = 'Б';
                    indexOfEmptyCell -= 2;
                }
                else if (indexOfEmptyCell < field.Length - 2 && field[indexOfEmptyCell + 2] == 'Ч' && field[indexOfEmptyCell + 1] == 'Б')
                {
                    field[indexOfEmptyCell + 2] = ' ';
                    field[indexOfEmptyCell] = 'Ч';
                    indexOfEmptyCell += 2;
                }
                else if (indexOfEmptyCell != 0 && indexOfEmptyCell != field.Length - 1 && field[indexOfEmptyCell - 1] == 'Б' && field[indexOfEmptyCell + 1] == 'Ч')
                {
                    if (indexOfEmptyCell - 2 > -1 && field[indexOfEmptyCell - 2] == 'Ч')
                    {
                        field[indexOfEmptyCell] = 'Ч';
                        field[indexOfEmptyCell + 1] = ' ';
                        indexOfEmptyCell += 1;
                    }
                    else
                    {
                        field[indexOfEmptyCell] = 'Б';
                        field[indexOfEmptyCell - 1] = ' ';
                        indexOfEmptyCell -= 1;
                    }
                }
                else if (indexOfEmptyCell != 0 && field[indexOfEmptyCell - 1] == 'Б')
                {
                    field[indexOfEmptyCell] = 'Б';
                    field[indexOfEmptyCell - 1] = ' ';
                    indexOfEmptyCell -= 1;
                }
                else if (indexOfEmptyCell != field.Length - 1 && field[indexOfEmptyCell + 1] == 'Ч')
                {
                    field[indexOfEmptyCell] = 'Ч';
                    field[indexOfEmptyCell + 1] = ' ';
                    indexOfEmptyCell += 1;
                }
                else
                {
                    isCountFinished = true;
                    continue;
                }
                /*Array.ForEach(array, x => Console.Write(x));
                Console.WriteLine();*/
                counterOfMoves++;
            }
            return counterOfMoves;
        }
    }
}
