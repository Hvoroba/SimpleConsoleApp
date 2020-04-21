// SavingFile.cs
// Лабораторная работа №1.
// Студент группы 485, Дмитриев Никита Дмитриевич. 2020 год

using System;
using System.Linq;
using System.IO;

namespace _1lab2020
{
    class SavingFile
    {
        internal static void SaveResult(string outputText, int stuffToSave)
        {
            Console.WriteLine(Menu.NL + " Enter the path:");
            string path = Console.ReadLine();
            int userChoice = CanBeSaved(path, outputText);

            while(userChoice == (int)FileErrorMenuCases.NewPath)
            {
                Console.WriteLine(Menu.NL + " Enter the path:");
                path = Console.ReadLine();
                userChoice = CanBeSaved(path, outputText);
            }

            if (userChoice == (int)FileErrorMenuCases.Back)
            {
                Menu.SaveMenu(outputText);
            }


            if (userChoice != (int)FileErrorMenuCases.Exit && userChoice != (int)FileErrorMenuCases.Back)
            {
                if(stuffToSave == (int)StuffToSave.OnlyArray)
                {
                    outputText = TransformText(outputText); //Transform all answer back to source array
                }
                StreamWriter sw = new StreamWriter(path, false);
                sw.Write(outputText);
                sw.Close();

                Console.WriteLine("userchoise = " + userChoice);
                Console.WriteLine(Menu.NL + " Success!");
                Menu.MainMenu();
            }
        }

        static int CanBeSaved(string path, string outputText)
        {
            if(path.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                Console.WriteLine("Bad input. The path is incorrect OR the file is not available. Try again:");
                return Menu.FileErrorMenu();
            }

            try
            {
                FileStream stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
                {
                    stream.Close();
                    if(new FileInfo(path).Length != 0) {
                        int menuChoice = Menu.SecondarySaveMenu();
                        switch (menuChoice)
                        {
                            case (int)SecondarySaveMenuCases.Yes:
                                return (int)FileErrorMenuCases.ProblemSolved;
                            case (int)SecondarySaveMenuCases.No:
                                return (int)FileErrorMenuCases.NewPath;
                            case (int)SecondarySaveMenuCases.Back:
                                return (int)FileErrorMenuCases.Back;
                            case (int)SecondarySaveMenuCases.Exit:
                                return (int)FileErrorMenuCases.Exit;
                            default:
                                break;
                        }
                    }
                    return (int)FileErrorMenuCases.ProblemSolved;
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Name is reserved.");
                return Menu.FileErrorMenu();
            }
            catch (IOException)
            {
                Console.WriteLine("Bad input. The path is incorrect OR the file is not available.");
                return Menu.FileErrorMenu();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Bad input. The path is incorrect OR the file is not available.");
                return Menu.FileErrorMenu();
            }
        }

        static string TransformText(string outputText)
        {
            outputText = outputText.Replace("Your array:", String.Empty);
            outputText = outputText.Replace(Menu.NL, String.Empty);

            for (int i = 0; i < outputText.Length; i++)
            {
                if(outputText[i] == 'T')
                {
                    i--; 
                    outputText = outputText.Remove(i, outputText.Length - i); //Removes all symbols starting with letter 'T'
                }
            }

            string size = outputText.Split(' ').Length.ToString();
            size += " ";
            outputText = outputText.Insert(0, size);
            Console.WriteLine("text " + outputText);
            return outputText;
        }
    }
}
