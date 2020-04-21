// Menu.cs
// Лабораторная работа №1.
// Студент группы 485, Дмитриев Никита Дмитриевич. 2020 год

using System;

namespace _1lab2020
{
    internal enum MainMenuCases : Int32 {
        FromConsole = 1,
        Random,
        FromFile,
        Exit
    }

    internal enum SaveMenuCases
    {
        SaveArray = 1,
        SaveResult,
        Restart,
        Exit
    }

    internal enum SecondarySaveMenuCases
    {
        Yes = 1,
        No,
        Back,
        Exit
    }

    internal enum FileErrorMenuCases
    {
        NewPath = 1,
        Back,
        Exit,
        ProblemSolved
    }

    internal enum StuffToSave
    {
        OnlyArray = 1,
        AllResult
    }

    public class Menu
    {
        internal static string NL = Environment.NewLine;

        internal static bool MainMenu()
        {
            Console.WriteLine(NL + " 1. Enter array from console");
            Console.WriteLine(" 2. Randomize array");
            Console.WriteLine(" 3. Enter array from the file");
            Console.WriteLine(" 4. Exit");

            string str = Console.ReadLine();
            Int32.TryParse(str, out int menuChoice);

            while (menuChoice < (int)MainMenuCases.FromConsole || menuChoice > (int)MainMenuCases.Exit)
            {
                Console.WriteLine("Bad input. Only from 1 to 4");
                str = Console.ReadLine();
                Int32.TryParse(str, out menuChoice);
            }

            switch (menuChoice)
            {
                case (int)MainMenuCases.FromConsole:
                    GettingArray.GetArrFromConsole();
                    break;
                case (int)MainMenuCases.Random:
                    GettingArray.RandomizeArr();
                    break;
                case (int)MainMenuCases.FromFile:
                    GettingArray.GetArrFromFile();
                    break;
                case (int)MainMenuCases.Exit:
                    return false;
                default:
                    return false;
            }
            return false;
        }

        internal static void SaveMenu(string outputText)
        {
            Console.WriteLine(NL + " 1. Save source array into the file");
            Console.WriteLine(" 2. Save result into the file");
            Console.WriteLine(" 3. Restart the program");
            Console.WriteLine(" 4. Exit");

            string str = Console.ReadLine();
            Int32.TryParse(str, out int menuChoice);

            while (menuChoice < (int)SaveMenuCases.SaveArray || menuChoice > (int)SaveMenuCases.Exit)
            {
                Console.WriteLine(" Bad input. Only from 1 to 4");
                str = Console.ReadLine();
                Int32.TryParse(str, out menuChoice);
            }

            switch (menuChoice)
            {
                case (int)SaveMenuCases.SaveArray:
                    SavingFile.SaveResult(outputText, (int)StuffToSave.OnlyArray);
                    break;
                case (int)SaveMenuCases.SaveResult:
                    SavingFile.SaveResult(outputText, (int)StuffToSave.AllResult);
                    break;
                case (int)SaveMenuCases.Restart:
                    MainMenu();
                    break;
                case (int)SaveMenuCases.Exit:
                    break;
                default:
                    break;
            }
        }

        internal static int SecondarySaveMenu()
        {
            Console.WriteLine(NL + " The file isn't empty. Overwrite it?");
            Console.WriteLine(" 1. Yes");
            Console.WriteLine(" 2. No");
            Console.WriteLine(" 3. Back");
            Console.WriteLine(" 4. Exit");

            string str = Console.ReadLine();
            Int32.TryParse(str, out int menuChoice);

            while (menuChoice < (int)SecondarySaveMenuCases.Yes || menuChoice > (int)SecondarySaveMenuCases.Exit)
            {
                Console.WriteLine(" Bad input. Only from 1 to 4");
                str = Console.ReadLine();
                Int32.TryParse(str, out menuChoice);
            }

            return menuChoice;
        }

        internal static int FileErrorMenu()
        {
            Console.WriteLine(NL + " 1. Enter new path");
            Console.WriteLine(" 2. Back");
            Console.WriteLine(" 3. Exit");

            string str = Console.ReadLine();
            Int32.TryParse(str, out int menuChoice);

            while (menuChoice < (int)FileErrorMenuCases.NewPath || menuChoice > (int)FileErrorMenuCases.Exit)
            {
                Console.WriteLine(" Bad input. Only from 1 to 3");
                str = Console.ReadLine();
                Int32.TryParse(str, out menuChoice);
            }

            return menuChoice;
        }
    }
}
