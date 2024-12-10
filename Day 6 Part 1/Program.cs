using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent_of_Code_Day_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("Day6.txt");

            string line;

            char[,] array = new char[131, 130];

            int[] StartPosition = new int[2];

            char Facing = '^';

            //  UP, DOWN, LEFT, RIGHT

            int rowCount = 0;
            while ((line = reader.ReadLine()) != null)
            {
                int columnCount = 0;

                foreach (char c in line)
                {
                    array[columnCount, rowCount] = c;

                    if (c == '^')
                    {
                        StartPosition[0] = columnCount;
                        StartPosition[1] = rowCount;
                    }

                    columnCount++;
                }
                
                rowCount++;
            }

            int[] CurrentPosition = StartPosition;

            array[CurrentPosition[0], CurrentPosition[1]] = 'X';

            Console.WriteLine(CurrentPosition[0] + "," + CurrentPosition[1]);

            while (true)
            {
                try
                {
                    int[] PotentialPosition = DetermineNextIndex(Facing, CurrentPosition, array);

                    if (array[PotentialPosition[0], PotentialPosition[1]] == '#')
                    {
                        // rotate

                        Facing = Rotate(Facing);
                    }
                    else
                    {
                        // step forward

                        CurrentPosition = PotentialPosition;
                            
                        PotentialPosition = DetermineNextIndex(Facing, CurrentPosition, array);

                        array[CurrentPosition[0], CurrentPosition[1]] = 'X';
                    }
                }
                catch
                {
                    break;
                }
            }

            int visited = 0;
            foreach (char c in array)
            {
                if (c == 'X')
                {
                    visited++;
                }
            }

            StreamWriter writer = File.CreateText("Day62.txt");

            for (int j = 0; j < 130; j++)
            {
                string writerLine = "";

                for (int i = 0; i < 131; i++)
                {
                    writerLine = writerLine + array[i, j];
                }

                writer.WriteLine(writerLine);
            }
            

            Console.ReadKey();
        }

        static int[] DetermineNextIndex(char facing, int[] oldCurrent, char[,] grid)
        {

            int[] current = new int[2];

            oldCurrent.CopyTo(current, 0);


            if (facing == '^')
            {
                current[1] = current[1] - 1;
            }
            else if (facing == 'v')
            {
                current[1] = current[1] + 1;
            }
            else if (facing == '>')
            {
                current[0] = current[0] + 1;
            }
            else if (facing == '<')
            {
                current[0] = current[0] - 1;
            }

            return current;
        }

        static char Rotate(char facing)
        {
            char nextFacing = facing;

            switch (facing)
            {
                case '^':
                    nextFacing = '>';
                    break;

                case '>':
                    nextFacing = 'v';
                    break;

                case 'v':
                    nextFacing = '<';
                    break;

                case '<':
                    nextFacing = '^';
                    break;
            }

            return nextFacing;
        }
    }
}
