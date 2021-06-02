using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(double.Parse)
                    .ToArray();

                jaggedArray[row] = currentRow;
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    MultiplyEachElementInBothArrays(jaggedArray, row);
                }

                else
                {
                    DivideEachElementInBothArrays(jaggedArray, row);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    foreach (double[] currentRow in jaggedArray)
                    {
                        Console.WriteLine(string.Join(" ", currentRow));
                    }
                    break;
                }

                string[] tokens = command.Split().ToArray();
                string cmd = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (cmd == "Add" && row >= 0 && row <= rows - 1 && col >= 0 && col <= jaggedArray[row].Length - 1)
                {
                    jaggedArray[row][col] += value;
                }
                else if (cmd == "Subtract" && row >= 0 && row <= rows - 1 && col >= 0 && col <= jaggedArray[row].Length - 1)
                {
                    jaggedArray[row][col] -= value;
                }
            }
        }


        private static void DivideEachElementInBothArrays(double[][] jaggedArray, int row)
        {
            for (int i = 0; i < jaggedArray[row].Length; i++)
            {
                jaggedArray[row][i] /= 2;
            }

            for (int i = 0; i < jaggedArray[row + 1].Length; i++)
            {
                jaggedArray[row + 1][i] /= 2;
            }
        }

        private static void MultiplyEachElementInBothArrays(double[][] jaggedArray, int row)
        {
            for (int i = 0; i < jaggedArray[row].Length; i++)
            {
                jaggedArray[row][i] *= 2;
            }

            for (int j = 0; j < jaggedArray[row + 1].Length; j++)
            {
                jaggedArray[row + 1][j] *= 2;
            }
        }
    }
}
