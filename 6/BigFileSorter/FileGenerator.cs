using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BigFileSorter
{
    // The simplest possible implementation that creates a file of approximate size
    // I'm rather interested in a second part of this task :)
    public class FileGenerator
    {
        const byte NumberOfLetters = 26;
        const int character_a = 65;
        const int character_A = 97;
        const int character_Space = 32;
        const byte maxStringLength = 100;
        const int bytesInMegabyte = 1024 * 1024;

        private Random _random = new Random();

        private string _previousString = "Empty string";

        public void GenerateFile(string filePath, long fileSizeMB)
        {
            // approximate number of records
            long recordsCount = fileSizeMB * bytesInMegabyte / (sizeof(char) * maxStringLength);

            using (StreamWriter file = new StreamWriter(filePath))
            {
                for (int i = 0; i < recordsCount; i++)
                {
                    file.WriteLine(GetLine());
                }
            }
        }

        private string GetLine()
        {
            var allowedSymbols = string.Join(string.Empty, Enumerable.Range(character_a, NumberOfLetters).Select(c => (char)c));
            allowedSymbols += string.Join(string.Empty, Enumerable.Range(character_A, NumberOfLetters).Select(c => (char)c));
            allowedSymbols += (char)character_Space;

            int stringPartLength = _random.Next(maxStringLength);

            int numberPart = _random.Next();
            var stringPart = new StringBuilder(stringPartLength);

            // from time to time we should have duplicates
            if (stringPartLength > maxStringLength / 2)
            {
                for (int i = 0; i < stringPartLength; i++)
                {
                    stringPart.Append(allowedSymbols[_random.Next(allowedSymbols.Length)]);
                }
            }
            else
            {
                stringPart = stringPart.Append(_previousString);
            }

            _previousString = stringPart.ToString();

            return string.Format("{0}.{1}", numberPart, stringPart);
        }
    }
}

