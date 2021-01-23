using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            double[][] jagged = new double[size][];
            for (int row = 0; row < size; row++)
            {
                double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
                jagged[row] = numbers;
            }
            for (int row = 0; row < size-1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] = jagged[row][col] * 2;
                        jagged[row+1][col] = jagged[row+1][col] * 2;

                    }
                }
                else
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] = jagged[row][col] / 2;
                        
                    }
                    for (int col = 0; col < jagged[row+1].Length; col++)
                    {
                       
                        jagged[row + 1][col] = jagged[row + 1][col] / 2;

                    }
                }
            }
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                if (row < 0 || row >= size || col < 0 || col >= jagged[row].Length)
                {
                    input = Console.ReadLine();
                }
                else
                {
                    if (command[0] == "Add")
                    {
                        jagged[row][col] += value;
                    }
                    else if (command[0] == "Subtract")
                    {
                        jagged[row][col] -= value;
                    }
                    input = Console.ReadLine();
                }
               
            }
            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
