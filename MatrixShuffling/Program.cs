using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] symbol = Console.ReadLine().Split().ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = symbol[col];
                }
            }
           
            while (true)
            {
                string command = Console.ReadLine();
                if(command=="END")
                {
                    break;
                }
                else
                {
                    string[] commandInfo = command.Split();
                    if (commandInfo[0] != "swap" || commandInfo.Length != 5)
                    {
                        Console.WriteLine($"Invalid input!");
                    }
                    else
                    {
                        int rowOne = int.Parse(commandInfo[1]);
                        int colOne = int.Parse(commandInfo[2]);
                        int rowTwo = int.Parse(commandInfo[3]);
                        int colTwo = int.Parse(commandInfo[4]);
                        if (rowOne >= rows ||colOne >= cols ||rowTwo >= rows ||colTwo >= cols)
                        {
                            Console.WriteLine($"Invalid input!");
                        }
                        else
                        {
                            string swapOne = matrix[rowOne, colOne];
                            string swapOTwo = matrix[rowTwo, colTwo];
                            matrix[rowOne, colOne] = swapOTwo;
                            matrix[rowTwo, colTwo] = swapOne;
                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {                              
                                for (int col = 0; col < matrix.GetLength(1); col++)
                                {
                                    Console.Write(matrix[row,col]+" ");
                                }
                                Console.WriteLine();
                            }
                        }   
                    }
                }
            }
        }
    }
}
