using Lib;
using System;
using System.Collections.Generic;

namespace lab2_7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Set> sets = new List<Set>();
            PrintHelp();
            while (Run(sets));
        }
        static bool Run(List<Set> sets)
        {
            string[] commands = Console.ReadLine().Split(" ");
            switch (commands[0])
            {
                case "new":
                    sets.Add(new Set());
                    break;
                case "add":
                    AddElement(sets, commands);
                    break;
                case "remove":
                    RemoveElement(sets, commands);
                    break;
                case "compare":
                    Compare(sets, commands);
                    break;
                case "dif":
                    Difference(sets, commands);
                    break;
                case "help":
                    PrintHelp();
                    break;
                case "print":
                    Print(sets, commands);
                    break;
                case "stop":
                    return false;
                default:
                    Console.WriteLine("Комманда не распознана");
                    break;
            }

            return true;
        }

        private static void Print(List<Set> sets, string[] commands)
        {
            if(commands.Length == 1)
            {
                foreach (var item in sets)
                {
                    Console.WriteLine(item);
                }
            }else if(commands.Length == 2)
            {
                Console.Write(sets[Convert.ToInt32(commands[1])]);
            }
            else
            {
                throw new Exception("Invalid command");
            }
        }

        private static void PrintHelp()
        {
            Console.WriteLine(
                "Список комманд:\n" +
                "new - создать новое пустое множество\n" +
                "add setNumber value - добавить в множество с индексом setNumber value\n" +
                "remove setNumber value - удалить из множества с индексом setNumber value\n" +
                "compare setA setB - сравнить мощности множеств с индексами а и b\n" +
                "dif etA setB - разность множеств с индексами а и b\n" +
                "print - печать всех множеств\n" +
                "print setNumber - печать множества с индексом setNumber\n" +
                "help - напечатать списко комманд\n" +
                "stop - закрыть программу");
        }

        private static void Difference(List<Set> sets, string[] commands)
        {
            if (commands.Length < 3)
            {
                throw new Exception("Invalid command");
            }
            Set a = sets[Convert.ToInt32(commands[1])];
            Set b = sets[Convert.ToInt32(commands[2])];
            sets.Add(a - b);
            Console.WriteLine(sets[sets.Count - 1]);
        }

        private static void Compare(List<Set> sets, string[] commands)
        {
            if (commands.Length < 3)
            {
                throw new Exception("Invalid command");
            }
            Set a = sets[Convert.ToInt32(commands[1])];
            Set b = sets[Convert.ToInt32(commands[2])];
            if (a > b)
            {
                Console.WriteLine("a > b");
            }else if(a == b)
            {
                Console.WriteLine("a == b");
            }
            else
            {
                Console.WriteLine("a < b");
            }
        }

        private static void RemoveElement(List<Set> sets, string[] commands)
        {
            if (commands.Length < 3)
            {
                throw new Exception("Invalid command");
            }
            int setNumber = Convert.ToInt32(commands[1]);
            int value = Convert.ToInt32(commands[2]);
            sets[setNumber] -= value;
        }

        private static void AddElement(List<Set> sets, string[] commands)
        {
            if (commands.Length < 3)
            {
                throw new Exception("Invalid command");
            }
            int setNumber = Convert.ToInt32(commands[1]);
            int value = Convert.ToInt32(commands[2]);
            sets[setNumber] += value;
        }
    }
}
