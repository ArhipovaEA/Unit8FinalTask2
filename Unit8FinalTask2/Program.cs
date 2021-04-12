using System;
using System.IO;

namespace Unit8FinalTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            string PathCalk;
            double SizeAll = 0;
            int LenPath;
            do
            {
                Console.WriteLine("Укажите путь по которому необходимо произвести подсчет размера данных: ");
                PathCalk = Console.ReadLine();
                LenPath = PathCalk.Length;
            }
            while (LenPath < 3);

            CalkSize(PathCalk, ref SizeAll);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nРазмер указанного каталога:" + SizeAll);
            Console.ResetColor();
        }

        static double CalkSize(string PathForCalk, ref double SizeCalk)
        {
            if (Directory.Exists(PathForCalk))
            {
                Console.WriteLine("Обработка началась... " + PathForCalk);
                try
                {
                    DirectoryInfo di = new DirectoryInfo(PathForCalk);

                    FileInfo[] fileNames = di.GetFiles();

                    foreach (FileInfo f in fileNames )
                    {
                        Console.WriteLine("Файл {0} имеет размер {1}" , f, f.Length);
                        SizeCalk = SizeCalk + f.Length;
                    }

                    DirectoryInfo[] folderInfo = di.GetDirectories();
                    foreach (DirectoryInfo df in folderInfo)
                    {
                        CalkSize(df.FullName, ref SizeCalk);
                    }

                    return Math.Round((double)(SizeCalk / 1024 / 1024 / 1024), 1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка: " + ex.Message);
                    return 0;
                }

            }
            else
            {
                Console.WriteLine("Данная директория не существует - " + PathForCalk);
                return 0;
            }


        }
    }
}
