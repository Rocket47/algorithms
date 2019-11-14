using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static string currentString;
        public static List<string> saveStrings = new List<string>();

        public static void Main(string[] args)
        {
            BastShoe("1 Hello");
            Console.WriteLine(BastShoe("2 2"));
            Console.WriteLine(BastShoe("3 22"));
            Console.ReadKey();
        }

        public static string BastShoe(string command)
        {
            int key = 0;
            string stringAfterKey;            
            key = Convert.ToInt32(command.Substring(0, command.IndexOf(" ")));
            stringAfterKey = command.Substring(command.IndexOf(" ")).TrimStart(' ');            
            switch (key)
            {
                case 1:
                    currentString += Add(stringAfterKey);
                    saveStrings.Add(currentString);
                    break;
                case 2:
                    currentString = Delete(stringAfterKey);
                    saveStrings.Add(currentString);
                    break;
                case 3:
                    currentString = GiveOut(stringAfterKey);                   
                    break;
                case 4:
                    currentString = Undo();
                    break;
                case 5:
                    currentString = Redo();
                    break;
            }
            return currentString;
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
            currentString = currentString.Remove(currentString.Length - 2, countElementsForDeleting);
            return currentString;
        }

        public static string GiveOut(string mIndex)
        {
            string result = "";
            int index = Convert.ToInt32(mIndex);
            if (index < mIndex.Length)
            {
                result = currentString[index].ToString();
            }            
            return result;
        }

        public static string Undo()
        {
            return null;
        }

        public static string Redo()
        {
            return null;
        }
    }
}

