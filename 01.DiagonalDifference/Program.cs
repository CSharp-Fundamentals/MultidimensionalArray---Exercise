using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int firstDiagonal = 0;
            int secondDiagonal = 0;

            for (int row = 0; row < n; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            for (int i = 0; i < n; i++)
            {
                firstDiagonal+=matrix[i, i];
            }

            int colSum = n - 1;
            for (int row = 0; row < n; row++)
            {
                secondDiagonal += matrix[row, colSum];
                colSum--;
            }
            Console.WriteLine(Math.Abs(firstDiagonal-secondDiagonal));
        }
    }
}
