using System;
using System.Linq;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string command = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = command[col];
                }
            }
            int bigMove = 0;
            int rowBigKing = 0;
            int colBigKing = 0;
            int kingCount = 0;
            if (size < 3)
            {
                Console.WriteLine(0);
                return;
            }
            while (true)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        int sumCurrentMove = 0;
                        if (matrix[row, col] == 'K')
                        {
                            char symbol = 'K';

                            if (IsInside(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
                            {
                                sumCurrentMove++;
                            }
                            if (IsInside(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
                            {
                                sumCurrentMove++;
                            }
                            if (IsInside(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
                            {
                                sumCurrentMove++;
                            }
                            if (IsInside(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
                            {
                                sumCurrentMove++;
                            }

                            if (IsInside(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
                            {
                                sumCurrentMove++;
                            }
                            if (IsInside(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
                            {
                                sumCurrentMove++;
                            }
                            if (IsInside(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
                            {
                                sumCurrentMove++;
                            }
                            if (IsInside(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
                            {
                                sumCurrentMove++;
                            }
                        }
                        if (sumCurrentMove > bigMove)
                        {
                            bigMove = sumCurrentMove;
                            rowBigKing = row;
                            colBigKing = col;
                        }
                    }
                }
                if (bigMove > 0)
                {
                    matrix[rowBigKing, colBigKing] = '0';
                    kingCount++;
                    bigMove = 0;
                }
                else
                {
                    Console.WriteLine(kingCount);
                    break;
                }
            }
        }

        private static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
