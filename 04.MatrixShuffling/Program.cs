using System;
using System.Linq;

namespace _04.MatrixShuffling
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
            string[,] matrix = new string[rows,cols];

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string cmd = tokens[0];

                if (cmd == "END")
                {
                    break;
                }
                else if(cmd=="swap" && tokens.Length == 5)
                {
                    int rowOne = int.Parse(tokens[1]);
                    int colOne = int.Parse(tokens[2]);
                    int rowTwo = int.Parse(tokens[3]);
                    int colTwo = int.Parse(tokens[4]);

                    if (rowOne >= 0 && rowOne <= rows - 1 && colOne >= 0 && colOne <= cols - 1
                        && rowTwo >= 0 && rowTwo <= rows - 1 && colTwo >= 0 && colTwo <= cols - 1)
                    {
                        string temp = matrix[rowOne, colOne];
                        matrix[rowOne, colOne] = matrix[rowTwo, colTwo];
                        matrix[rowTwo, colTwo] = temp;

                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
