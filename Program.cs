using System;
using System.IO;

namespace _8._6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Url();
        }

        public static void Url()
        {
            Console.WriteLine("Пропишите путь до файла как в примере: C:/Users/user/Desktop/example.bin");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(filePath);
                    //DirectoryInfo root = dir.Root;
                    var folders = dir.GetDirectories();

                    WriteFileInfo(dir);
                    WriteFolderInfo(folders);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
            }

        }


        public static void WriteFolderInfo(DirectoryInfo[] folders)
        {
            Console.WriteLine();
            Console.WriteLine("Папки: ");
            Console.WriteLine();

            foreach (var folder in folders)
            {
                try
                {
                    Console.WriteLine(folder.Name + $" - {DirectoryExtension.DirSize(folder)}байт");
                }
                catch (Exception e)
                {
                    Console.WriteLine(folder.Name + $" - Не удалось рассчитать размер: {e.Message}");
                }
            }
        }

        public static void WriteFileInfo(DirectoryInfo rootFolder)
        {
            Console.WriteLine();
            Console.WriteLine("Файлы: ");
            Console.WriteLine();

            foreach (var file in rootFolder.GetFiles())
            {
                Console.WriteLine(file.Name + $" - {file.Length} байт");
            }
        }
    }

    public static class DirectoryExtension
    {
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            FileInfo[] fis = d.GetFiles();
            foreach(FileInfo fi in fis)
            {
                size += fi.Length;
            }

            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }
        
    }
}
