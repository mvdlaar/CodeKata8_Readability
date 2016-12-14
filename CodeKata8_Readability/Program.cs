using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// This is a possible solution to the problem in CodeKata 08 (http://codekata.com/kata/kata08-conflicting-objectives/)
/// This has been "optimized" for readability
/// The runtime is about 9 minutes for the given wordlist
/// </summary>
namespace CodeKata8_Readability
{
    class Program
    {
        private const string WordlistFileName = "wordlist.txt";
        private const int BiggerWordLength = 6;

        static void Main(string[] args)
        {
            List<string> resultList = new List<string>();

            string currentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            string path = currentDirectory + @"\" + WordlistFileName;

            using (StreamReader wordListStreamReader = File.OpenText(path))
            {
                List<string> wordListWords = new List<string>();
                string wordListLine = "";
                while ((wordListLine = wordListStreamReader.ReadLine()) != null)
                {
                    wordListWords.Add(wordListLine.ToLower());
                }

                wordListWords.Sort();

                foreach (string word in wordListWords)
                {
                    if (word.Length == BiggerWordLength)
                    {
                        for (int counter = 1; counter < BiggerWordLength - 1; counter++)
                        {
                            string leftWordPart = word.Substring(0, counter);
                            string rightWordPart = word.Substring(counter);

                            bool leftWordPartFound = wordListWords.Contains(leftWordPart);
                            bool rightWordPartFound = wordListWords.Contains(rightWordPart);

                            bool compositionFound = leftWordPartFound && rightWordPartFound;

                            if (compositionFound)
                            {
                                StringBuilder resultBuilder = new StringBuilder();
                                resultBuilder.Append(leftWordPart);
                                resultBuilder.Append(" + ");
                                resultBuilder.Append(rightWordPart);
                                resultBuilder.Append(" => ");
                                resultBuilder.Append(word);
                                resultList.Add(resultBuilder.ToString());
                            }
                        }
                    }
                }

                foreach (string result in resultList)
                {
                    Console.WriteLine(result);
                }

                Console.ReadKey();
            }
        }
    }
}
