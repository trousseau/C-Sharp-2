using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string filepath = @"C:\UCSD\C# 2\Labs\Lab5\Lab5\Documents";
            DocumentStatistics ds = new DocumentStatistics();
            ProcessFiles(filepath, ds);
            SerializeStats(filepath, ds);

            Console.ReadLine();
        }

        private static void ProcessFiles(string filepath, DocumentStatistics stats)
        {
            string[] files = { };
            StringBuilder sb = new StringBuilder();
            try
            {
                files = Directory.GetFiles(filepath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (var file in files)
            {
                Console.WriteLine(file);
                stats.Documents.Add(file);
                stats.DocumentCount++;

                try
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        if (!reader.EndOfStream)
                        {
                            sb.Append(reader.ReadLine());
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            string pattern = " ";
            string result = sb.ToString().ToLower();

            //remove all non-alphanumeric characters
            result = Regex.Replace(result, "[^a-zA-Z0-9 -]", "");

            string[] wordsList = Regex.Split(result, pattern);

            foreach (var word in wordsList)
            {
                if (stats.WordCounts.ContainsKey(word))
                {
                    stats.WordCounts[word]++;
                }
                else
                {
                    stats.WordCounts.Add(word, 1);
                }
            }
        }

        private static void SerializeStats(string filepath, DocumentStatistics stats)        {
            string filename = filepath + @"\stats.json";
            try
            {
                using (var stm = new FileStream(filename, FileMode.CreateNew))
                {
                    var serializer = new DataContractJsonSerializer((typeof(DocumentStatistics)));
                    serializer.WriteObject(stm, stats);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}