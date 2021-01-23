using System;
using System.Linq;

namespace Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] jagged = new int[size][];
            for (int row = 0; row < size; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagged[row] = numbers;
            }
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] command = input.Split();
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                if (row < 0 || row >= size || col < 0 || col >= jagged[row].Length)
                {
                    Console.WriteLine($"Invalid coordinates");
                }
                else if (command[0] == "Add")
                {
                    jagged[row][col] += value;
                }
                else if (command[0] == "Subtract")
                {
                    jagged[row][col] -= value;
                }
                input = Console.ReadLine();
            }
            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
