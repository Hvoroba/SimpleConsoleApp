// Program.cs
// Лабораторная работа №1.
// Студент группы 485, Дмитриев Никита Дмитриевич. 2020 год

using System;

namespace _1lab2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Hello, wanderer. This surely usefull program counts all negative elements before the largest positive number.");

            bool keepGoing = true;
            while (keepGoing)
            {
                keepGoing = Menu.MainMenu();
            }
        }
    }
}
