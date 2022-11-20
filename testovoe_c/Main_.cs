using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;


namespace testovoe_c
{
    class Main_
    {
        class CustomBigIntegerComparer : IComparer<BigInteger>
        {
            public int Compare(BigInteger x, BigInteger y)
            {
                if (x > y) return -1;
                if (x < y) return 1;
                return 0;
            }
        }

        static public List<BigInteger> GetCurrentList(string[] files)
        {
            var result = new List<BigInteger>();
            var curentNumbers = new Dictionary<BigInteger, bool>();

            string line;
            StreamReader file_stream;
            BigInteger number;
            Console.WriteLine("Найденные файлы:");
            foreach (string file in files)
            {
                file_stream = new StreamReader(file);
                Console.WriteLine('\t' + file);

                while ((line = file_stream.ReadLine()) != null)
                {
                    
                    number = BigInteger.Parse(line);
                    // В C# остаток от отрицательных чисел тоже отрицательный
                    if (((number> 0 ) && (number % 4 != 3)) || ((number < 0) && (4 +number - (number / 4)*4) != 3))
                        continue;
                    curentNumbers[number] = !curentNumbers.ContainsKey(number);
                }
                file_stream.Close();
            }
            foreach (var Number in curentNumbers.Keys)
                if (curentNumbers[Number]) 
                    result.Add(Number);
            
            return result;
        }
            
        static void Main(string[] args)
        {
            
            // 1
            Console.Write("Введите директорию:\n>");
            string path = Console.ReadLine();
            path = path + (path[path.Length - 1] == '/' ? "" : "/");

            //+bonus Генерация тестовых данных
            Gen.Generate_test(path,1000);

            if (!Directory.Exists(path))
                throw new Exception("Директория не существует!");

            string[] files = Directory.GetFiles(path, "*.txt");

            // 2
            List<BigInteger> numbers = GetCurrentList(files);

            // 3
            var res = numbers.OrderBy(p => p, new CustomBigIntegerComparer());

            //4
            StreamWriter sw = new StreamWriter(path+ "result.txt");
            foreach (var n in res)
                sw.WriteLine(n);
            sw.Close();
        }
    }
}
