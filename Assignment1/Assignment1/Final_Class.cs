using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Assignment1
{
    class Final_Class
    {
        public static void Main(String[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            DirWalker fw1 = new DirWalker();
            fw1.walk(@"C:\Users\Gagandeep\OneDrive\Documents\GitHub\MCDA5510_Assignments\Sample Data\Sample Data\");
            //SimpleCSVParser obj = new SimpleCSVParser();
            using (var stream2 = File.Open(@"C:\Users\Gagandeep\Documents\A00453339_MCDA5510\Assignment1\Logs\log.txt", FileMode.Append))
            using (var writer2 = new StreamWriter(stream2))
            {
                writer2.WriteLine("Total number of valid records:" + fw1.fw2.valid_list.Sum());
                writer2.WriteLine("Total number of invalid records:" + fw1.fw2.invalid_list.Sum());
                watch.Stop();
                writer2.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            }
        }
    }

}
