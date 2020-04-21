// GettingArray.cs
// Лабораторная работа №1.
// Студент группы 485, Дмитриев Никита Дмитриевич. 2020 год

using System;
using System.Linq;
using System.IO;

namespace _1lab2020
{
    class GettingArray
    {
        internal const int MIN_SIZE = 4;

        internal static void GetArrFromConsole()
        {
            int size = 0;
            while (size < MIN_SIZE)
            {
                Console.WriteLine($"{Menu.NL} Enter array's size( >= {MIN_SIZE}):");
                string str = Console.ReadLine();
                while(!CanBeParsed(str))
                {
                    str = Console.ReadLine();
                }
                int.TryParse(str, out size);
            }

            int[] arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(" Enter " + (i+1) + " element:");
                string str = Console.ReadLine();
                while (!CanBeParsed(str))
                {
                    str = Console.ReadLine();
                }
                int.TryParse(str, out arr[i]);
            }

            string outputText = Algorithm.GetAnswer(arr);
            Menu.SaveMenu(outputText);
        }

        internal static void RandomizeArr()
        {
            int size = 0;
            while (size < MIN_SIZE)
            {
                Console.WriteLine($"{Menu.NL} Enter array's size( >= {MIN_SIZE}):");
                string str = Console.ReadLine();
                while (!CanBeParsed(str))
                {
                    str = Console.ReadLine();
                }
                int.TryParse(str, out size);
            }

            int[] arr = new int[size];

            Random rand = new Random();
            
            for(int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(-100, 100);
            }

            string outputText = Algorithm.GetAnswer(arr);
            Menu.SaveMenu(outputText);
        }

        internal static void GetArrFromFile()
        {
            Console.WriteLine(Menu.NL + " Enter the path:");
            string path = Console.ReadLine();
            int userChoice = ValidPath(path);

            while (userChoice == (int)FileErrorMenuCases.NewPath)
            {
                Console.WriteLine(Menu.NL + " Enter the path:");
                path = Console.ReadLine();
                userChoice = ValidPath(path);
            }

            if (userChoice == (int)FileErrorMenuCases.Back)
            {
                Menu.MainMenu();
            }

            if (userChoice != (int)FileErrorMenuCases.Exit && userChoice != (int)FileErrorMenuCases.Back)
            {
                
                string allText = File.ReadAllText(path);

                for (int i = 0; i < allText.Length - 1; i++)
                {
                    if (allText[i] == ' ' && allText[i + 1] == ' ')
                    {
                        allText = allText.Remove(i, 1);
                        i--;
                    }
                }

                int size = (int)Char.GetNumericValue(allText[0]);

                if (allText[1] != ' ')
                {
                    char tempCh = allText[0];
                    int indexCounter = 1;
                    string sizeStr = "";

                    while (tempCh != ' ')
                    {
                        sizeStr += tempCh;
                        tempCh = allText[indexCounter];
                        indexCounter++;
                    }

                    size = Convert.ToInt32(sizeStr);
                }
                int[] arr = new int[size];

                int sizeIndex = 0;
                while (allText[sizeIndex] != ' ')
                {
                    sizeIndex++;
                }
                allText = allText.Remove(0, sizeIndex); 
                //Удаление первого числа из массива, т к это размер

                ParseStringToArr(arr, allText);

                string outputText = Algorithm.GetAnswer(arr);
                Menu.SaveMenu(outputText);
            }
        }

        static void ParseStringToArr(int[] arr, string allText)
        {
            allText = allText.Trim();
            allText += " ";

            int counter = 0;

            for (int i = 0; i < allText.Length; i++)
            {
                string tempStr = "";

                while (allText[i] != ' ')
                {
                    tempStr += allText[i];
                    i++;
                }
                arr[counter] = Convert.ToInt32(tempStr);
                counter++;
            }
        }

        static bool AllTextFit(string path)
        {
            string strWithSpaces = File.ReadAllText(path);
            strWithSpaces = strWithSpaces.Trim();

            string spacelessStr = strWithSpaces.Replace(" ", String.Empty);

            int elementsAmount = 0;
            //Т к все элементы разделены пробелами, можно посчитать количество пробелов и узнать количество элементов

            for (int i = 0; i < strWithSpaces.Length; i++)
            {
                if(strWithSpaces[i] == ' ')
                {
                    elementsAmount++;
                    if(strWithSpaces[i] == ' ' && strWithSpaces[i+1] == ' ')
                    {
                        elementsAmount--;
                    }
                }
            }
            
            int size = (int)Char.GetNumericValue(strWithSpaces[0]);

            char tempCh = strWithSpaces[0];
            int indexCounter = 1;
            string sizeStr = "";

            while (tempCh != ' ')
            {
                sizeStr += tempCh;
                tempCh = strWithSpaces[indexCounter];
                indexCounter++;
            }

            size = Convert.ToInt32(sizeStr);

            if (elementsAmount != size)
            {
                Console.WriteLine(Menu.NL + " Array size doesn't match with amount of array elements.");
                return false;
            }

            if (size < MIN_SIZE)
            {
                Console.WriteLine(Menu.NL + " Too small array. It's size shoud be more than 3.");
                return false;
            }

            int[] arr = new int[size+1];
            try
            {
                ParseStringToArr(arr, strWithSpaces);
            }
            catch
            {
                Console.WriteLine(Menu.NL + " One of the elements is too big.");
                return false;
            }

            return true;
        }

        static bool CanBeParsed(string input)
        {
            try
            {
                Int32.TryParse(input, out int numb);
                if(input.Replace(" ", String.Empty) != "0" && numb == 0)
                {
                    Console.WriteLine(Menu.NL + " Bad input. Try again.");
                    return false;
                }
            } catch
            {
                Console.WriteLine(Menu.NL + " Bad input. Try again.");
                return false;
            }
            return true;
        }

        static int ValidPath(string path)
        {
            if (path.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                Console.WriteLine(Menu.NL + " Bad input. The path is incorrect OR the file is not available.");
                return Menu.FileErrorMenu();
            }

            try
            {
                FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);                
                stream.Close();
                if (AllTextFit(path))
                {
                    return (int)FileErrorMenuCases.ProblemSolved;
                }
                else
                {
                    Console.WriteLine(Menu.NL + " Invalid file text.");
                    return Menu.FileErrorMenu();
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
    }
}