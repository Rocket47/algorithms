using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static bool LineAnalysis(string line)
        {
            int savePosition = 0;
            bool result = true;
            List<char> arrCombination = new List<char>();
            char[] convertedStringToCharArr = line.ToCharArray();
            if (convertedStringToCharArr[0] == '*')
            {
                arrCombination.Add('*');
            }
            for (int i = 1; i < convertedStringToCharArr.Length; i++)
            {
                if (convertedStringToCharArr[i] != '*')
                {
                    arrCombination.Add(convertedStringToCharArr[i]);
                }
                else
                {
                    savePosition = i;
                    break;
                }
            }
            Console.WriteLine("Единый шаблон для анализа получен: ");
            foreach (char test in arrCombination)
            {
                Console.Write(test + "");
            }

            int counter = arrCombination.Count;

            if (convertedStringToCharArr[convertedStringToCharArr.Length - 1] != '*')
            {
                result = false;
            }
            List<char> arrCombinationNext = new List<char>();
            arrCombinationNext.Add('*');
            for (int j = savePosition + 1; j < convertedStringToCharArr.Length; j++)
            {
                if (convertedStringToCharArr[j] != '*')
                {
                    arrCombinationNext.Add(convertedStringToCharArr[j]);
                }
                else
                {
                    savePosition = j;
                    Console.WriteLine("\n" + "Cледующий шаблон для сравнения:");
                    foreach (char test2 in arrCombinationNext)
                    {
                        Console.Write(test2 + "");
                    }

                    if (arrCombination.Count != arrCombinationNext.Count)
                    {
                        result = false;
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < arrCombination.Count; i++)
                        {
                            if (arrCombination[i] != arrCombinationNext[i])
                            {
                                result = false;
                                break;
                            }
                        }
                    }
                    arrCombinationNext.Clear();
                    arrCombinationNext.Add('*');
                    continue;
                }
            }
            return result;
        }
    }
}


