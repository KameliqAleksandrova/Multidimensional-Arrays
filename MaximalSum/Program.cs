using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[,] matrix = new int[rows, cols];
            int total = int.MinValue;
            int totalRow = 0;
            int totalCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = 0;
                    sum += matrix[row, col];
                    sum += matrix[row, col + 1];
                    sum += matrix[row, col + 2];
                    sum += matrix[row + 1, col];
                    sum += matrix[row + 1, col + 1];
                    sum += matrix[row + 1, col + 2];
                    sum += matrix[row + 2, col];
                    sum += matrix[row + 2, col + 1];
                    sum += matrix[row + 2, col + 2];
                    if (sum > total)
                    {
                        total= sum;
                        totalRow = row;
                        totalCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {total}");
            Console.WriteLine($"{matrix[totalRow, totalCol]} {matrix[totalRow, totalCol + 1]} {matrix[totalRow, totalCol + 2]}");
            Console.WriteLine($"{matrix[totalRow + 1, totalCol]} {matrix[totalRow + 1, totalCol + 1]} {matrix[totalRow + 1, totalCol + 2]}");
            Console.WriteLine($"{matrix[totalRow+2, totalCol]} {matrix[totalRow+2, totalCol + 1]} {matrix[totalRow+2, totalCol + 2]}");
        }
    }
}
