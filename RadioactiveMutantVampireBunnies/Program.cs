using System;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            char[,] matrix = new char[rows, cols];
            int startRow = 0;
            int startCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'P')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
            string commandLine = Console.ReadLine();
            for (int i = 0; i < commandLine.Length; i++)
            {
                char command = commandLine[i];
                switch (command)
                {
                    case 'L':
                        if (IsInside(matrix, startRow, startCol - 1))
                        {
                            matrix[startRow, startCol] = '.';
                            startCol = startCol - 1;
                            switch (matrix[startRow, startCol])
                            {
                                case '.':
                                    IsBunny(matrix);
                                    break;
                                case 'B':
                                    IsBunny(matrix);
                                    Print(matrix);
                                    Console.WriteLine($"dead: {startRow} {startCol}");
                                    return;
                            }
                        }
                        else
                        {
                            IsBunny(matrix);
                            Print(matrix);
                            Console.WriteLine($"won: {startRow} {startCol}");
                            return;
                        }
                        break;
                    case 'R':
                        if (IsInside(matrix, startRow, startCol + 1))
                        {
                            matrix[startRow, startCol] = '.';
                            startCol = startCol + 1;
                            switch (matrix[startRow, startCol])
                            {
                                case '.':
                                    IsBunny(matrix);
                                    break;
                                case 'B':
                                    IsBunny(matrix);
                                    Print(matrix);
                                    Console.WriteLine($"dead: {startRow} {startCol}");
                                    return;
                            }
                        }
                        else
                        {
                            IsBunny(matrix);
                            Print(matrix);
                            Console.WriteLine($"won: {startRow} {startCol}");
                            return;
                        }
                        break;
                    case 'U':
                        if (IsInside(matrix, startRow - 1, startCol))
                        {
                            matrix[startRow, startCol] = '.';
                            startRow = startRow - 1;
                            switch (matrix[startRow, startCol])
                            {
                                case '.':
                                    IsBunny(matrix);
                                    break;
                                case 'B':
                                    IsBunny(matrix);
                                    Print(matrix);
                                    Console.WriteLine($"dead: {startRow} {startCol}");
                                    return;
                            }
                        }
                        else
                        {
                            IsBunny(matrix);
                            Print(matrix);
                            Console.WriteLine($"won: {startRow} {startCol}");
                            return;
                        }
                        break;
                    case 'D':
                        if (IsInside(matrix, startRow + 1, startCol))
                        {
                            matrix[startRow, startCol] = '.';
                            startRow = startRow + 1;
                            switch (matrix[startRow, startCol])
                            {
                                case '.':
                                    IsBunny(matrix);
                                    break;
                                case 'B':
                                    IsBunny(matrix);
                                    Print(matrix);
                                    Console.WriteLine($"dead: {startRow} {startCol}");
                                    return;
                            }
                        }
                        else
                        {
                            IsBunny(matrix);
                            Print(matrix);
                            Console.WriteLine($"won: {startRow} {startCol}");
                            return;
                        }
                        break;
                }

            }
        }

        private static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void IsBunny(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (IsInside(matrix, row - 1, col) && matrix[row - 1, col] == '.')
                        {
                            matrix[row - 1, col] = 'b';
                        }
                        if (IsInside(matrix, row, col + 1) && matrix[row, col + 1] == '.')
                        {
                            matrix[row, col + 1] = 'b';
                        }
                        if (IsInside(matrix, row + 1, col) && matrix[row + 1, col] == '.')
                        {
                            matrix[row + 1, col] = 'b';
                        }
                        if (IsInside(matrix, row, col - 1) && matrix[row, col - 1] == '.')
                        {
                            matrix[row, col - 1] = 'b';
                        }
                    }
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'b')
                    {
                        matrix[row, col] = 'B';
                    }
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
