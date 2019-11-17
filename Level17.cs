using System;
using System.Collections.Generic;
namespace Level1Space
{
    public static class Level1
    {
        public static string currentString;
        public static int countCurrentPosition = 0;
        public static bool undoWas = false;
        public static List<string> saveStrings = new List<string>();

        public static void Main(string[] args)
        {
            string input = "";
            while (!input.Equals("Exit"))
            {
                input = Console.ReadLine();
                Console.WriteLine(BastShoe(input));

                Console.WriteLine("*****************************");
                foreach(string i in saveStrings)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static string BastShoe(string command)
        {
            int key;
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
                    currentString += Add(stringAfterKey);
                    saveStrings.Add(currentString);
                    result = currentString;                   
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
                    break;
                case 3:
                    result = GiveOut(stringAfterKey);                   
                    break;
                case 4:
                    undoWas = true;
                    currentString = Undo();
                    result = currentString;                    
                    break;
                case 5:
                    currentString = Redo();
                    result = currentString;                   
                    break;
            }
            return result;
        }

        public static string Add(string mStringAfterKey)
        {
            countCurrentPosition++;
            if (undoWas)
            {
                for (int i = 0; i <= saveStrings.Count + 2; i++)
                {
                    saveStrings.Remove(saveStrings[0]);
                }
                countCurrentPosition = 1;
            }
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
            countCurrentPosition--;
            if (countCurrentPosition == saveStrings.Count - 1)
            {
                countCurrentPosition--;
            }
            if (countCurrentPosition < saveStrings.Count && countCurrentPosition > 0)
            {
                result = saveStrings[countCurrentPosition];
            }             
            else if (countCurrentPosition <= 0)
            {
                result = saveStrings[0];
                countCurrentPosition = 0;
            }
            return result;
        }
        public static string Redo()
        {
            string result = "";
            countCurrentPosition++;
            if (countCurrentPosition < saveStrings.Count && countCurrentPosition > 0)
            {
                result = saveStrings[countCurrentPosition];
            }
            else if (countCurrentPosition >= saveStrings.Count - 1)
            {
                result = saveStrings[saveStrings.Count - 1];
                countCurrentPosition = saveStrings.Count - 1;
            }

            return result;
        }
    }
}

