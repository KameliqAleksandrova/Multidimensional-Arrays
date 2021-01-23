using System;
using System.Linq;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            char[,] matrix = new char[rows, cols];
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char symbol = matrix[row, col];
                    if (matrix[row, col + 1] == symbol && matrix[row + 1, col] == symbol && matrix[row + 1, col + 1] == symbol)
                    {
                        sum++;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
