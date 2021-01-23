using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            int sumFirstDiagonal = 0;
            int sumSecondDoagonal= 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumFirstDiagonal += matrix[row, row];
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(col==size-1-row)
                    {
                        sumSecondDoagonal += matrix[row, col];
                    }
                }
                
            }

            int result = Math.Abs(sumFirstDiagonal - sumSecondDoagonal);
            Console.WriteLine(result);
        }
    }
}
