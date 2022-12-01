using System.Collections;

namespace AdventOfCode;

public class Parser
{
     public static List<int> ParseListToInt(List<string> lines)
        {
            List<int> intLines = new List<int>();
            foreach (var line in lines)
            {
                intLines.Add(int.Parse(line));
            }

            return intLines;
        }

        public static List<long> ParseListToLong(List<string> lines)
        {
            List<long> intLines = new List<long>();
            foreach (var line in lines)
            {
                intLines.Add(int.Parse(line));
            }

            return intLines;
        }

        public static List<(string, int)> ParseListToTuple(List<string> lines)
        {
            List<(string, int)> parsedLines = new List<(string, int)>();
            foreach (var line in lines)
            {
                var splitLines = line.Split();
                var valueTuple = (splitLines[0], int.Parse(splitLines[1]));

                parsedLines.Add(valueTuple);
            }

            return parsedLines;
        }


        public static List<BitArray> ParseListToBitArray(List<string> lines, int size)
        {
            var parsedList = new List<BitArray>();

            foreach (var line in lines)
            {
                BitArray bitArray = new BitArray(size);
                for (int i = 0, k = size - 1; i < size; i++, k--)
                {
                    bitArray[i] = line[k].Equals('1');
                }

                parsedList.Add(bitArray);
            }

            return parsedList;
        }

        public static int[,] ParseTo2DInt(List<string> lines)
        {
            var parsed2D = new int[lines.Count, lines[0].Length];

            for (var i = 0; i < lines.Count; i++)
            {
                for (var j = 0; j < lines[i].Length; j++)
                {
                    parsed2D[i, j] = int.Parse(lines[i][j].ToString());
                }
            }

            return parsed2D;
        }

        public static int[,] ParseTo2D(List<string> lines)
        {
            int xMax = 0, yMax = 0;
            foreach (var line in lines)
            {
                var sLines = line.Split(",");

                if (int.Parse(sLines[1]) > xMax) xMax = int.Parse(sLines[1]);
                if (int.Parse(sLines[0]) > yMax) yMax = int.Parse(sLines[0]);
            }

            var parsed2D = new int[xMax + 1, yMax + 1];

            for (var i = 0; i < yMax; i++)
            {
                for (var j = 0; j < xMax; j++)
                {
                    parsed2D[j, i] = 0;
                }
            }

            foreach (var line in lines)
            {
                var sLines = line.Split(",");
                parsed2D[int.Parse(sLines[1]), int.Parse(sLines[0])] = 1;
            }

            return parsed2D;
        }

        public static Dictionary<string, string> ParseToDictionary(List<string> lines)
        {
            var dict = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                var a = line.Split("-");
                var key = a[0].Trim();
                var b = a[1].Split();
                var value = b[1].Trim();

                dict.Add(key, value);
            }

            return dict;
        }

        public static List<string> ParseToBinaryString(List<string> lines)
        {
            Dictionary<char, string> hexCharacterToBinary = new Dictionary<char, string>
            {
                {'0', "0000"},
                {'1', "0001"},
                {'2', "0010"},
                {'3', "0011"},
                {'4', "0100"},
                {'5', "0101"},
                {'6', "0110"},
                {'7', "0111"},
                {'8', "1000"},
                {'9', "1001"},
                {'A', "1010"},
                {'B', "1011"},
                {'C', "1100"},
                {'D', "1101"},
                {'E', "1110"},
                {'F', "1111"}
            };


            var binaryStrings = new List<string>();
            foreach (var line in lines)
            {
                var binaryString = "";
                foreach (var _char in line)
                {
                    binaryString += hexCharacterToBinary[_char];
                }

                binaryStrings.Add(binaryString);
            }

            return binaryStrings;
        }
}