using System;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = input[0];
            int cols = input[1];
            char[,] matrix = new char[rows, cols];
            string snake = Console.ReadLine();
            int i = snake.Length;
            int counter = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = snake[counter];
                    counter++;
                    if (counter == i)
                    {
                        counter = 0;
                    }
                }
                if (row<rows-1)
                {
                    row++;
                }
                else
                {
                    break;
                }
                for (int nextCol = cols - 1; nextCol >= 0; nextCol--)
                {
                    matrix[row, nextCol] = snake[counter];
                    counter++;
                    if (counter == i)
                    {
                        counter = 0;
                    }
                }
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
