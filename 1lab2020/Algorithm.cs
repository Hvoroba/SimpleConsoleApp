// Algorithm.cs
// Лабораторная работа №1.
// Студент группы 485, Дмитриев Никита Дмитриевич. 2020 год

using System;
using System.Linq;

namespace _1lab2020
{
    public class Algorithm
    {
        internal static string GetAnswer(int[] arr)
        {
            int maxIndex = FindMaxIndex(arr);
            int negNumbAmount = 0;
            for (int i = 0; i < maxIndex; i++)
            {
                if (arr[i] < 0)
                {
                    negNumbAmount++;
                }
            }

            if(arr.Max() < 0) 
            {
                negNumbAmount = 0;
            }
            //т к по заданию необходимо определить  число отрицательных элементов
            // расположенных перед наибольшим ПОЛОЖИТЕЛЬНЫМ элементом

            string outputText = ""; //Here will be an array and an answer

            outputText += "Your array:" + Menu.NL;
            for (int i = 0; i < arr.Length; i++)
            {
                outputText += arr[i].ToString() + " ";
            }
            
            if (negNumbAmount == 1)
            {
                outputText += Menu.NL + "There is " + negNumbAmount + " negative element before the largest positive number.";
            }
            else
            {
                outputText += Menu.NL + "There are " + negNumbAmount + " negative elements before the largest positive number.";
            }
            outputText += Menu.NL + "Max element = " + arr.Max().ToString();

            Console.WriteLine();
            Console.WriteLine(outputText);

            return outputText;
        }

        public static int FindMaxIndex(int[] arr)
        {
            int max = arr[0];
            int maxIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= max)
                {
                    max = arr[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }
    }
}
