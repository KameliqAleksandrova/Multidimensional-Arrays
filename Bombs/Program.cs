using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];          
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] elements = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
            string[] separators = { " ","," };
            int[] coordinate = Console.ReadLine().Split(separators,StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < coordinate.Length; i+=2)
            {
                int row = coordinate[i];
                int col = coordinate[i + 1];
                int bombAttack = matrix[row, col];
                if (matrix[row, col] >0 )
                {
                    if (IsInside(matrix, row - 1, col - 1) && matrix[row - 1, col - 1] > 0)
                    {
                        matrix[row - 1, col - 1] -= bombAttack;
                    }
                    if (IsInside(matrix, row - 1, col) && matrix[row - 1, col] > 0)
                    {
                        matrix[row - 1, col] -= bombAttack;
                    }
                    if (IsInside(matrix, row - 1, col + 1) && matrix[row - 1, col + 1] > 0)
                    {
                        matrix[row - 1, col + 1] -= bombAttack;
                    }
                    if (IsInside(matrix, row, col + 1) && matrix[row, col + 1] > 0)
                    {
                        matrix[row, col + 1] -= bombAttack;
                    }
                    if (IsInside(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] > 0)
                    {
                        matrix[row + 1, col + 1] -= bombAttack;
                    }
                    if (IsInside(matrix, row + 1, col) && matrix[row + 1, col] > 0)
                    {
                        matrix[row + 1, col] -= bombAttack;
                    }
                    if (IsInside(matrix, row + 1, col - 1) && matrix[row + 1, col - 1] > 0)
                    {
                        matrix[row + 1, col - 1] -= bombAttack;
                    }
                    if (IsInside(matrix, row, col - 1) && matrix[row, col - 1] > 0)
                    {
                        matrix[row, col - 1] -= bombAttack;
                    }
                    matrix[row, col] = 0;
                }
                else
                {
                    continue;
                }
            }
            int alive = 0;
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0) ; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) ; col++)
                {
                    if(matrix[row,col]>0)
                    {
                        alive++;
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {alive}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]+" ");
                }
                Console.WriteLine();
            }
        }
        private static bool IsInside(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
