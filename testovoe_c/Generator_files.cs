using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;


namespace testovoe_c
{
    class Gen
    {
        public static void Generate_test(string path,int range)
        {
            // 1
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            Random rnd = new Random();


            Console.Write("Введите число документов которое хотите сгенерировать:\n>");
            int files_count = int.Parse(Console.ReadLine());//rnd.Next(100);
            
            for (int i = 1 ; i<=files_count ; i++)
            {
                if (i%10==0)
                    Console.WriteLine(String.Format("Сгенерированно:{0}/{1}", i, files_count));
                
                StreamWriter sw = new StreamWriter(path + i.ToString() + ".txt");
                for (int count = rnd.Next(100,1000); count>0 ; count--)
                {
                    sw.WriteLine(rnd.Next(-range, range).ToString());
                }
                sw.Close();
            }
            Console.WriteLine("Файлы успешно сгенерированны!");
        }
        

    }
}
