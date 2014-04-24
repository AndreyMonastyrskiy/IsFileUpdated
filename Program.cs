using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ISConsUpdated
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            string prewline = "";

            // Read config file and parse it
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"config.txt");
            while ((line = file.ReadLine()) != null)
            {

                switch (prewline)
                { 
                    case "!":
                    System.Console.WriteLine(line);
                    break;

                    case "$":
                    PrintConsDate(line,file.ReadLine());
                    break;

                    case "_":
                    System.Console.WriteLine();
                    break;
                }
                prewline = line;
            }
            file.Close();
            //--------------------------------------------------------------------
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        static void PrintConsDate(string LastRecPatch, string ConsName)
        {
            if (File.Exists(LastRecPatch))
            {
                FileInfo FConsInfo = new FileInfo(@LastRecPatch);
                Console.Write(ConsName);
                Console.ForegroundColor = ConsoleColor.Green;
                if (DateTime.Now.Date > FConsInfo.LastWriteTime.Date) Console.ForegroundColor = ConsoleColor.Yellow;
                if ((DateTime.Now.Date.AddDays(-7)) > FConsInfo.LastWriteTime.Date) Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(FConsInfo.LastWriteTime.ToString());
                Console.ResetColor();
            }
            else
            {
                Console.Write(ConsName);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет файла LAST_REC.txt");
                Console.ResetColor();
            }
        }
    }
}
