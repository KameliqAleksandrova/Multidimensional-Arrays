using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commandLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[size, size];
            int startRow = 0;
            int startCol = 0;
            int endRow = 0;
            int endCol = 0;
            int everyCoal = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char [] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    if (matrix[row, col] == 'e')
                    {
                        endRow = row;
                        endCol = col;
                    }
                    if (matrix[row, col] == 'c')
                    {
                        everyCoal++;
                    }
                }
            }          
            int sumOfCoal = 0;
            for (int i = 0; i < commandLine.Length; i++)
            {
                string move = commandLine[i];
                switch (move)
                {
                    case "left":
                        if (IsInside(matrix, startRow, startCol - 1))
                        {
                            startCol = startCol - 1;
                            switch (matrix[startRow, startCol])
                            {
                                case '*':
                                    continue;
                                case 'e':
                                    Console.WriteLine($"Game over! ({startRow}, {startCol})");
                                    return;
                                case 'c':
                                    sumOfCoal++;
                                    if (sumOfCoal == everyCoal)
                                    {
                                        Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                        return;
                                    }
                                    else
                                    {
                                        matrix[startRow, startCol] = '*';
                                    }
                                    break;
                            }
                        }
                        break;
                    case "right":
                        if (IsInside(matrix, startRow, startCol + 1))
                        {
                            startCol = startCol + 1;
                            switch (matrix[startRow, startCol])
                            {
                                case '*':
                                    continue;
                                case 'e':
                                    Console.WriteLine($"Game over! ({startRow}, {startCol})");
                                    return;
                                case'c':
                                    sumOfCoal++;
                                    if (sumOfCoal == everyCoal)
                                    {
                                        Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                        return;
                                    }
                                    else
                                    {
                                        matrix[startRow, startCol] = '*';
                                    }
                                    break;
                            }
                        }
                        break;
                    case "up":
                        if (IsInside(matrix, startRow-1, startCol ))
                        {
                            startRow = startRow - 1;
                            switch (matrix[startRow, startCol])
                            {
                                case '*':
                                    continue;
                                case 'e':
                                    Console.WriteLine($"Game over! ({startRow}, {startCol})");
                                    return;
                                case 'c':
                                    sumOfCoal++;
                                    if (sumOfCoal == everyCoal)
                                    {
                                        Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                        return;
                                    }
                                    else
                                    {
                                        matrix[startRow, startCol] = '*';
                                    }
                                    break;
                            }
                        }
                        break;
                    case "down":
                        if (IsInside(matrix, startRow+1, startCol ))
                        {
                            startRow = startRow + 1;
                            switch (matrix[startRow, startCol])
                            {
                                case '*':
                                    continue;
                                case 'e':
                                    Console.WriteLine($"Game over! ({startRow}, {startCol})");
                                    return;
                                case 'c':
                                    sumOfCoal++;
                                    if (sumOfCoal == everyCoal)
                                    {
                                        Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                        return;
                                    }
                                    else
                                    {
                                        matrix[startRow, startCol] = '*';
                                    }
                                    break;
                            }
                        }
                        break;
                }

            }
            Console.WriteLine($"{everyCoal-sumOfCoal} coals left. ({startRow}, {startCol})");
        }
        private static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
