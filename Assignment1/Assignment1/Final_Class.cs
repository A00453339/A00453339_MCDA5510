using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Assignment1
{
    class Final_Class
    {
        public static void Main(String[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            DirWalker fw = new DirWalker();
            fw.walk(@"C:\Users\Gagandeep\OneDrive\Documents\GitHub\MCDA5510_Assignments\Sample Data\Sample Data\2017");
            watch.Stop();
            using (var stream2 = File.Open(@"C:\Users\Gagandeep\OneDrive\Documents\GitHub\MCDA5510_Assignments\log.txt", FileMode.Append))
            using (var writer2 = new StreamWriter(stream2))
            {
                writer2.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            }             
        }
    }

}
