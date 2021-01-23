using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }
            int totalSum = int.MinValue;
            int totalRow = 0;
            int totalCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = 0;
                    sum += matrix[row, col];
                    sum += matrix[row, col + 1];
                    sum += matrix[row + 1, col];
                    sum += matrix[row + 1, col + 1];
                    if (sum > totalSum)
                    {
                        totalSum = sum;
                        totalRow = row;
                        totalCol = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[totalRow, totalCol]} {matrix[totalRow, totalCol + 1]}");
            Console.WriteLine($"{matrix[totalRow + 1, totalCol]} {matrix[totalRow + 1, totalCol + 1]}");
            Console.WriteLine(totalSum);
        }
    }
}
