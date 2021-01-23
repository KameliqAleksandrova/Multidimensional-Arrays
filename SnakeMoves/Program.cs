using System;
using System.Linq;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            char[,] matrix = new char[rows, cols];
            string command = Console.ReadLine();
            int currentSymbol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = command[currentSymbol];
                        currentSymbol++;
                        if (currentSymbol == command.Length)
                        {
                            currentSymbol = 0;
                        }
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1)-1; col >=0; col--)
                    {
                        matrix[row, col] = command[currentSymbol];
                        currentSymbol++;
                        if (currentSymbol == command.Length)
                        {
                            currentSymbol = 0;
                        }
                    }

                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
