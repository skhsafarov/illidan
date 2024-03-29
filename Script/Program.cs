using System;
using System.IO;

namespace Script
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
        static int GetFileNumber(string fileName)
        {
            string numberPart = new string(fileName.Where(char.IsDigit).ToArray());
            return int.Parse(numberPart);
        }

        public static void Foo()
        {
            // Получить все файлы в директории с расширением .png и отсортировать по имени файла по возрастанию (по алфавиту)
            var directory = new DirectoryInfo("D:\\Projects\\.NetProjects\\Illidan\\Client\\wwwroot\\images\\animals");
            var files = directory.GetFiles("*.png", SearchOption.AllDirectories);
            var sortedFiles = files.OrderBy(file => GetFileNumber(file.Name));


            for (int i = 0; i < sortedFiles.Count(); i++)
            {
                var file = sortedFiles.ElementAt(i);
                var newFileName = $"animal{i}.png";
                file.MoveTo(Path.Combine(file.DirectoryName, newFileName));
            }


            // Вывести все файлы
            foreach (var file in sortedFiles)
            {
                System.Console.WriteLine(file.Name);
            }
        }
    }
}