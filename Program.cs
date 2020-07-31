using System;
using System.Collections.Generic;
using System.IO;

namespace Findologic4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben Sie den Shopkey ein: ");
            string Shopkeysuche = Console.ReadLine();

            Console.WriteLine(string.Join("", readRecord(Shopkeysuche, "logging.csv", 1)));
        }
        public static string[] readRecord(string searchTerm, string filepath, int positionOfSearchTerm)
        {
            positionOfSearchTerm--;
            string[] recordNotFound = { "Record not found" };


            try
            {
                string[] lines = System.IO.File.ReadAllLines(filepath);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split("\t");
                    if (recordMatches(searchTerm, fields, positionOfSearchTerm))
                    {
                        Console.WriteLine("Record found");
                        return fields;
                    }
                }

                return recordNotFound;
            }
            catch(Exception ex)
            {
                return recordNotFound;
            }

        }

        public static bool recordMatches(string searchTerm, string[] record, int positionOfSearchTerm)
        {
            if (record[positionOfSearchTerm].Equals(searchTerm))
            {
                return true;
            }
            return false;
        }    
    }
}
