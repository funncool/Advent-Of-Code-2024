using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent_Of_Code_Day_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("Day4.txt");

            string line;

            char[,] array = new char[141, 140];

            int horizontal = 0;
            while ((line = reader.ReadLine()) != null)
            {
                char[] temp = line.ToArray();

                int count = 0;
                foreach (char c in temp)
                {
                    array[count, horizontal] = c;

                    count++;
                }

                horizontal++;
            }

            int XMASCount = 0;

            for (int i = 0; i < 141; i++)
            {
                for (int j = 0; j < 140; j++)
                {
                    try
                    {
                        //Up
                        string up = string.Concat(array[i, j], array[i + 1, j], array[i, j + 2], array[i, + 3]);

                        if (up == "XMAS")
                        {
                            XMASCount++;
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        //Down
                        string down = string.Concat(array[i, j], array[i, j - 1], array[i, j - 2], array[i, j - 3]);

                        if (down == "XMAS")
                        {
                            XMASCount++;
                        }
                    }
                    catch { }

                    try 
                    {
                        //Left
                        string left = string.Concat(array[i, j], array[i - 1, j], array[i - 2, j], array[i - 3, j]);

                        if (left == "XMAS")
                        {
                            XMASCount++;
                        }
                    }
                    catch { }

                    try
                    {
                        //Right 
                        string right = string.Concat(array[i, j], array[i + 1, j], array[i + 2, j], array[i + 3, j]);

                        if (right == "XMAS")
                        {
                            XMASCount++;
                        }
                    }
                    catch { }

                    try
                    {
                        //NE
                        string NE = string.Concat(array[i, j], array[i + 1, j + 1], array[i + 2, j + 2], array[i + 3, j + 3]);

                        if (NE == "XMAS")
                        {
                            XMASCount++;
                        }
                    } catch { }

                    try
                    {
                        //SE
                        string SE = string.Concat(array[i, j], array[i + 1, j - 1], array[i + 2, j - 2], array[i + 3, j - 3]);

                        if (SE == "XMAS")
                        {
                            XMASCount++;
                        }
                    } catch { }

                    try
                    {
                        //SW
                        string SW = string.Concat(array[i, j], array[i - 1, j - 1], array[i - 2, j - 2], array[i - 3, j - 3]);

                        if (SW == "XMAS")
                        {
                            XMASCount++;
                        }
                    } catch {}

                    try
                    {
                        //NW
                        string NW = string.Concat(array[i, j], array[i - 1, j + 1], array[i - 2, j + 2], array[i - 3, j + 3]);

                        if (NW == "XMAS")
                        {
                            XMASCount++;
                        }
                    }
                    catch { }
                    
                }
            }

            Console.WriteLine(XMASCount);
            Console.ReadKey();

            // X M A S
            // Forward, Backwards, Up, Down, NE, SE, SW, NW

        }
    }
}
