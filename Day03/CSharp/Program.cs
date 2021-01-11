using System;
using System.Collections.Generic;

namespace CSharp
{
    class Program
    {
        // Create a dirty big 2D Array (not the most memory efficient, but simple as a first approach)
        // See Go version for improved implementation
        static int[,] CreateCourse(List<string> input) {
            int[,] course = new int[input.Count, input[0].Length * 100];
            for (int i = 0; i < input.Count; i++) {
                for (int j = 0; j < input[i].Length; j++) {
                    int value = input[i][j] is '.' ? 0 : 1;
                    for (int k = j; k < course.GetLength(1); k += input[i].Length) {
                        course[i,k] = value;
                    }
                }
            }
            return course;
        }

        static int CalculateForRoute(int[,] course, int rowStep, int colStep) {
            int trees = 0;
            int r = 0; // row
            int c = 0; // column

            while(r < course.GetLength(0)) {
                trees += course[r, c];
                r += rowStep;
                c += colStep;
            }

            return trees;
        }

        static void Main(string[] args)
        {
            string line;

            var input = new List<string>{};

            System.IO.StreamReader file = new System.IO.StreamReader("../input.txt");  
            while((line = file.ReadLine()) != null) {
                input.Add(line);
            }
            file.Close(); 

            List<int> runs = new List<int>();

            int[,] course = CreateCourse(input);
            int result = CalculateForRoute(course, 1, 3);
            runs.Add(result);
            Console.WriteLine("Part 1: Trees encountered: {0}\n", result);

            runs.Add(CalculateForRoute(course, 1, 1));
            runs.Add(CalculateForRoute(course, 1, 5));
            runs.Add(CalculateForRoute(course, 1, 7));
            runs.Add(CalculateForRoute(course, 2, 1));

            long product = 1;

            foreach(int i in runs) {
                product *= i;
            }

            Console.WriteLine("Part 2: Trees encountered: {0}\n", product);
        }
    }
}
