using System;
using System.Linq;

namespace _03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = ParseArray();
            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];
            int maxSum = int.MinValue;
            int[,] maxMatrix = new int[3, 3];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = ParseArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            for (int row = 0; row < rows-2; row++)
            {
                for (int col = 0; col < cols-2; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        maxMatrix = new int[3, 3] {
                        { matrix[row, col] , matrix[row, col + 1] , matrix[row, col + 2]},
                        {  matrix[row + 1, col] , matrix[row + 1, col + 1] , matrix[row + 1, col + 2]},
                       { matrix[row + 2, col] , matrix[row + 2, col + 1] , matrix[row + 2, col + 2] }
                        };
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(maxMatrix[row, col]+ " ");
                }
                Console.WriteLine();
            }
        }

        private static int[] ParseArray()
        => Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}
