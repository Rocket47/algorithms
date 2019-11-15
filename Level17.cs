using System;
using System.Collections.Generic;
namespace Level1Space
{
    public static class Level1
    {
        public static string currentString;
        public static int countCurrentPosition = 2;
        public static bool undoWas = false;
        public static List<string> saveStrings = new List<string>();

        public static void Main(string[] args)
        {
            BastShoe("1 Привет");
            BastShoe("1 , Мир!");
            BastShoe("1 ++");
            BastShoe("2 2");
            BastShoe("4");
            BastShoe("4");
            BastShoe("1 *");
            BastShoe("4");
            BastShoe("4");
            BastShoe("4");
            BastShoe("3 6");
            BastShoe("2 100");

            Console.ReadKey();
        }

        public static string BastShoe(string command)
        {
            int key = 0;
            string stringAfterKey = "";
            string result = "";
            if (command.Length > 1)
            {
                key = Convert.ToInt32(command.Substring(0, command.IndexOf(" ")));
                stringAfterKey = command.Substring(command.IndexOf(" ")).TrimStart(' ');
            }
            else
            {
                key = Convert.ToInt32(command);
            }
            switch (key)
            {               
                case 1:
                    if (undoWas)
                    {
                        for (int i = 0; i < saveStrings.Count - 1; i++)
                        {
                            saveStrings.Remove(saveStrings[i]);
                        }
                        countCurrentPosition = 1;
                    }
                    currentString += Add(stringAfterKey);
                    saveStrings.Add(currentString);                    
                    result = currentString;                        
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("Выбрана команда Add c ключом " + stringAfterKey);                    
                    Console.WriteLine("Результат работы команды: " + result);
                    Console.WriteLine("///////////////////////////////////////////////");
                    Console.WriteLine("Вывожу текущий лист ожидания...");
                    int counter = 0;
                    foreach (string i in saveStrings)
                    {                        
                        Console.WriteLine(counter + "." + " " + i);
                        counter++;
                    }
                    Console.WriteLine("///////////////////////////////////////////////");
                    break;
                case 2:
                    if (undoWas)
                    {
                        for (int i = 0; i < saveStrings.Count - 1; i++)
                        {
                            saveStrings.Remove(saveStrings[i]);
                        }
                    }
                    currentString = Delete(stringAfterKey);
                    saveStrings.Add(currentString);                    
                    result = currentString;                    
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("Выбрана команда Delete с ключом" + stringAfterKey);
                    Console.WriteLine("Результат работы команды: " + result);
                    Console.WriteLine("///////////////////////////////////////////////");
                    Console.WriteLine("Вывожу текущий лист ожидания...");
                    int counter1 = 0;
                    foreach (string i in saveStrings)
                    {
                        Console.WriteLine(counter1 + "." + " " + i);
                        counter1++;
                    }
                    Console.WriteLine("///////////////////////////////////////////////");
                    break;
                case 3:
                    result = GiveOut(stringAfterKey);
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("Выбрана команда GetOut с ключом" + stringAfterKey);
                    Console.WriteLine("Результат работы команды: " + result);
                    Console.WriteLine("///////////////////////////////////////////////");
                    Console.WriteLine("Вывожу текущий лист ожидания...");
                    int counter2 = 0;
                    foreach (string i in saveStrings)
                    {
                        Console.WriteLine(counter2 + "." + " " + i);
                        counter2++;
                    }
                    Console.WriteLine("///////////////////////////////////////////////");
                    break;
                case 4:
                    undoWas = true;                    
                    currentString = Undo();
                    result = currentString;
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("Выбрана команда Undo");
                    Console.WriteLine("Результат работы команды: " + result);
                    Console.WriteLine("///////////////////////////////////////////////");
                    Console.WriteLine("Вывожу текущий лист ожидания...");
                    int counter3 = 0;
                    foreach (string i in saveStrings)
                    {
                        Console.WriteLine(counter3 + "." + " " + i);
                        counter3++;
                    }
                    Console.WriteLine("///////////////////////////////////////////////");
                    break;
                case 5:
                    currentString = Redo();
                    result = currentString;
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("Выбрана команда Redo");
                    Console.WriteLine("Результат работы команды: " + result);
                    Console.WriteLine("///////////////////////////////////////////////");
                    Console.WriteLine("Вывожу текущий лист ожидания...");
                    int counter4 = 0;
                    foreach (string i in saveStrings)
                    {
                        Console.WriteLine(counter4 + "." + " " + i);
                        counter4++;
                    }
                    Console.WriteLine("///////////////////////////////////////////////");
                    break;
            }
            return result;
        }

        public static string Add(string mStringAfterKey)
        {
            string result = "";
            result += mStringAfterKey;
            return result;
        }

        public static string Delete(string mStringAfterKey)
        {
            int countElementsForDeleting = Convert.ToInt32(mStringAfterKey);
            if (countElementsForDeleting < currentString.Length - 1)
            {
                currentString = currentString.Remove(currentString.Length - 2, countElementsForDeleting);
            } 
            else if (countElementsForDeleting >= currentString.Length)
            {
                currentString = "";
            }
            return currentString;
        }

        public static string GiveOut(string mIndex)
        {
            string result = "";
            int index = Convert.ToInt32(mIndex);
            if (index < currentString.Length)
            {
                result = currentString[index].ToString();
            }
            return result;
        }

        public static string Undo()
        {
            string result = "";
            int position = saveStrings.Count - countCurrentPosition;
            if (countCurrentPosition >= 1)
            {
                result = saveStrings[position];
                countCurrentPosition--;
            }
            else
            {
                result = saveStrings[0];
            }
            return result;
        }
        public static string Redo()
        {
            string result = "";
            result = saveStrings[countCurrentPosition++];

            return result;
        }
    }
}

