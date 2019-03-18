using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Collections;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            string direktorij = @"C:\";


            DirectoryInfo dirInfo = new DirectoryInfo(direktorij);


            System.IO.DirectoryInfo[] dirInfos = dirInfo.GetDirectories("*.*");

            foreach (System.IO.DirectoryInfo d in dirInfos)
            {
                Console.WriteLine("  "+d.Name);
            }


            Console.SetCursorPosition(1, 1);
            Console.Write(">");
            
            int cekanjeTreperenje = 100;
            Console.CursorVisible = false;
            int pokazivacY = 0;
            while (true)
            {
                System.Threading.Thread.Sleep(cekanjeTreperenje);
                Console.SetCursorPosition(1, pokazivacY);
                Console.Write(" ");
                System.Threading.Thread.Sleep(cekanjeTreperenje);
                Console.SetCursorPosition(1, pokazivacY);
                Console.Write(">");



                int br = 0;
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pritisnutaTipka = Console.ReadKey(true);
                    if (pritisnutaTipka.Key == ConsoleKey.DownArrow)
                    {
                        pokazivacY++;

                    }



                    if (pritisnutaTipka.Key == ConsoleKey.Enter)
                    {
                        br = 0;
                        dirInfos = dirInfo.GetDirectories("*.*");
                        foreach (System.IO.DirectoryInfo d in dirInfos)
                        {

                            if (br == pokazivacY)
                            {
                                direktorij = d.FullName;
                                Console.Clear();
                                Console.WriteLine(direktorij);
                                dirInfo = new DirectoryInfo(direktorij);
                                break;
                            }
                            br++;
                        }

                        break;
                    }


                }

            }


            
                var datoteke = dirInfo.GetFiles();
                long velicina = 0;
                int brojRedova = datoteke.Length + 6;


                Console.WriteLine("+------------------+-------------+---------+------------------------------------------+");
                Console.WriteLine("| Veličina       B |          KB |      MB | Nazivi datoteka                          |");
                Console.WriteLine("+------------------+-------------+---------+------------------------------------------+");
                foreach (FileInfo d in datoteke)
                {
                    velicina += d.Length;
                    Console.WriteLine("|{0, 15} B | {1, 8} KB | {2, 4} MB | {3,40} |",
                        d.Length,
                        d.Length / 1024,
                        d.Length / (1024 * 1024),
                        d.FullName);
                }
                Console.WriteLine("+------------------+-------------+---------+------------------------------------------+");
                Console.WriteLine("|{0, 15} B | {1, 8} KB | {2, 4} MB |                                          |",
                    velicina,
                    velicina / 1024,
                    velicina / (1024 * 1024));
                Console.WriteLine("+------------------+-------------+---------+------------------------------------------+");


            Console.ReadLine();


        }
    }
}
