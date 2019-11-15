using System;
using System.Collections.Generic;
namespace Level1Space
{
    public static class Level1
    {
        public static string currentString;
        public static int countCurrentPosition = 2;
        public static int saveLastKeyValue = 0;
        public static List<string> saveStrings = new  List<string>();

        public static void Main(string[] args)
        {           
            Console.WriteLine(BastShoe("1 Привет"));
            Console.WriteLine(BastShoe("1 , Мир!"));
            Console.WriteLine(BastShoe("1 ++"));           
            Console.WriteLine(BastShoe("2 2"));           
            Console.WriteLine(BastShoe("4"));           
            Console.WriteLine(BastShoe("4"));           
            Console.WriteLine(BastShoe("1 *"));           
            Console.WriteLine(BastShoe("4"));           
            Console.WriteLine(BastShoe("4"));           
            Console.WriteLine(BastShoe("4"));           
            Console.WriteLine(BastShoe("3 6"));           
            Console.WriteLine(BastShoe("2 100"));           
            
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
                    currentString += Add(stringAfterKey);
                    saveStrings.Add(currentString);
                    saveLastKeyValue = 1;
                    result = currentString;
                    break;
                case 2:
                    currentString = Delete(stringAfterKey);
                    saveStrings.Add(currentString);
                    saveLastKeyValue = 2;
                    result = currentString;
                    break;
                case 3:                     
                    result = GiveOut(stringAfterKey);
                    break;
                case 4:
                    if (saveLastKeyValue == 1 || saveLastKeyValue == 2)
                    {
                        for (int i = 0; i < saveStrings.Count - 1; i++)
                        {
                            saveStrings.Remove(saveStrings[i]);
                        }
                    }
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
            if (position > 1)
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

