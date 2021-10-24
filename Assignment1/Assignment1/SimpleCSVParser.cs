using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Assignment1
{
    public class SimpleCSVParser
    {


        //       public static void Main(String[] args)
        //       {
        //           SimpleCSVParser parser = new SimpleCSVParser();
        //           parser.parse(@"/Users/dpenny/Projects/Assignment1/Assignment1/sampleFile.csv");
        //       }

        public void parse(String fileName,bool firstline)
        {
            try
            {
                int invalid_cnt=0;
                int valid_cnt=0;
                using (var stream = File.Open(@"C:\Users\Gagandeep\OneDrive\Documents\GitHub\MCDA5510_Assignments\Test.csv", FileMode.Append))
                using (var writer = new StreamWriter(stream))
                using (var stream2 = File.Open(@"C:\Users\Gagandeep\OneDrive\Documents\GitHub\MCDA5510_Assignments\log.txt", FileMode.Append))
                using (var writer2 = new StreamWriter(stream2))
                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                            //Process row
                        string[] fields = parser.ReadFields();
                        if (firstline)
                        {
                            int flag = 0;
                            foreach (string field in fields)
                            {
                                //Console.WriteLine(field);
                                if (field == "")
                                {
                                    flag = 1;
                                }
                            }
                            if (flag == 1)
                            {
                                invalid_cnt++;
                                string invalid_str = string.Join(",", fields);
                                string log_str = "File " + fileName + "has invalid record" + invalid_str;
                                writer2.WriteLine(log_str);
                            }
                            else 
                            {
                                if (fields[0] != "First Name")
                                {
                                    valid_cnt++;
                                }
                                string valid_str = string.Join(",", fields);
                                writer.WriteLine(valid_str);
                            }
                        }
                        else
                        {
                            firstline=true;
                            continue;
                        }
                    }
                    writer2.WriteLine("Number of valid records in file "+fileName+ ": "+valid_cnt);
                    writer2.WriteLine("Number of valid records in file " + fileName + ": " + invalid_cnt);

                }
                }
            
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }

        }
    }
}
