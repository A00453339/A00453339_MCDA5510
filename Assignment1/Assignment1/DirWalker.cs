using System;
using System.IO;

namespace Assignment1
{
  

    public class DirWalker
    {
        public bool firstline = true;
        public SimpleCSVParser fw2 = new SimpleCSVParser();
        public void walk(String path)
        {

            string[] list = Directory.GetDirectories(path);


            if (list == null) return;

            foreach (string dirpath in list)
               // foreach (String f : list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                    //Console.WriteLine("Dir:" + dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path);
            Console.WriteLine(path);
            //SimpleCSVParser fw = new SimpleCSVParser();
            foreach (string filepath in fileList)
            {

                //Console.WriteLine("File:" + filepath);
                fw2.parse(filepath, firstline);
                firstline = false;
            }
        }

        //public static void Main(String[] args)
        //{
        //    DirWalker fw = new DirWalker();
        //   fw.walk(@"/");
        //}

    }
}
