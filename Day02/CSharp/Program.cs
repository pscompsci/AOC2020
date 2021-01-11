using System;

namespace CSharp
{
    class Program
    {
        static int[] getLimits(string input)
        {
            int[] result = new int[2];
            string[] parts = input.Split(' ');
            parts = parts[0].Split('-');
            result[0] = Int32.Parse(parts[0]);
            result[1] = Int32.Parse(parts[1]);
            return result;
        }

        static char getLetter(string input)
        {
            return input.Split(' ')[1].ToCharArray()[0];
        }

        static bool isValidPart1(string line)
        {
            int count = 0;
            string[] parts = line.Split(':');
            int[] limits = getLimits(parts[0]);
            char letter = getLetter(parts[0]);
            for(int i = 0; i < parts[1].Length; i++) {
                if (parts[1][i] == letter) count++;
            }
            if (limits[0] <= count && count <= limits[1]) return true;
            return false;
        }

        static bool isValidPart2(string line)
        {
            int count = 0;
            string[] parts = line.Split(':');
            int[] positions = getLimits(parts[0]);
            char letter = getLetter(parts[0]);

            if (parts[1][positions[0]] == letter) count++;
            if (parts[1][positions[1]] == letter) count++;

            if (count == 1) return true;
            return false;
        }

        static void Main(string[] args)
        {
            int totalLines = 0;
            int p1Counter = 0;
            int p2Counter = 0;  
            string line;  

            System.IO.StreamReader file = new System.IO.StreamReader("../input.txt");  
            while((line = file.ReadLine()) != null)  
            {  
                totalLines++;

                // Part 1
                if (isValidPart1(line)) p1Counter++;  

                // Part 2
                if (isValidPart2(line)) p2Counter++;
            }  
            
            file.Close();  
            System.Console.WriteLine("There were {0} lines, with {1} valid passwords in part 1.", totalLines, p1Counter); 
            System.Console.WriteLine("There were {0} lines, with {1} valid passwords in part 2.", totalLines, p2Counter); 
        }
    }
}
