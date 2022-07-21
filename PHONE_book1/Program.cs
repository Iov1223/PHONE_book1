using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace PHONE_book1
{
    class PhoneNumbers
    {
        public string name = "";
        private string path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName + @"\PB.txt";
        public string phoneNuber = "";
        private StreamReader my_stream_reader = null;
        private int count_of_string = 0, count = 0;
        private string[] Arr_of_string = new string[0];
        public void ReadFile()
        {
            my_stream_reader = File.OpenText(path);
            count_of_string = System.IO.File.ReadAllLines(path).Length;
            Arr_of_string = new string[count_of_string];
            for (int i = 0; i < count_of_string; i++)
            {
                Arr_of_string[i] = my_stream_reader.ReadLine();
            }
        }
        public void SearchName()
        {
            Console.WriteLine("Введите имя контакта:");
            name = Console.ReadLine();
            for (int i = 0; i < count_of_string; i++)
            {
                if (Arr_of_string[i].Contains(name))
                {
                    for (int j = 0; j < Arr_of_string[i].Length; j++)
                    {
                        if (Arr_of_string[i][j] != ':')
                            count++;
                        else
                            break;
                    }
                    for (int k = count + 2; k < Arr_of_string[i].Length; k++)
                    {
                        phoneNuber += Arr_of_string[i][k];
                    }
                }

            }
        }
        public void ShowNumber()
        {
            if (phoneNuber != "")
            {
                Console.WriteLine("Телефонный номер контакта {0}: {1}", name, phoneNuber);
            }
            else
            {
                Console.WriteLine("Контакта {0} не существует.", name);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PhoneNumbers myNumber = new PhoneNumbers();
            myNumber.ReadFile();
            myNumber.SearchName();
            myNumber.ShowNumber();
        }
    }
}