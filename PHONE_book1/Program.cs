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
        private string path = Directory.GetCurrentDirectory() + @"\PB.txt";
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
        public void SearchName(string name)
        {
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
        public void ShowNumber(string name)
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
        public void Print(string []args)
        {
            PhoneNumbers myNumber = new PhoneNumbers();
            if (args.Length != 0 && args.Length == 2)
            {
                myNumber.ReadFile();
                myNumber.SearchName(args[0] + " " + args[1]);
                myNumber.ShowNumber(args[0] + " " + args[1]);
            }
            else
            {
                if (args.Length != 0)
                {
                    myNumber.ReadFile();
                    myNumber.SearchName(args[0]);
                    myNumber.ShowNumber(args[0]);
                }
                else
                {
                    Console.WriteLine("Введите имя контакта:");
                    string name = Console.ReadLine();
                    myNumber.ReadFile();
                    myNumber.SearchName(name);
                    myNumber.ShowNumber(name);
                }
            }
        }
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Print(args);
        }
    }
}