using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(BastShoe("2 2"));
            Console.ReadKey();
        }

        public static string BastShoe(string command)
        {
            int key = 0;
            string stringAfterKey;
            string result = "";
            key = Convert.ToInt32(command.Substring(0, command.IndexOf(" ")));
            stringAfterKey = command.Substring(command.IndexOf(" ")).TrimStart(' ');
            switch (key)
            {
                case 1:
                   result += Add(stringAfterKey);
                   break;
                case 2:
                    result = Delete(stringAfterKey);
                    break;
                case 3:
                    result = GiveOut();
                    break;
                case 4:
                    result = Undo();
                    break;
                case 5:
                    result = Redo();
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
            string result = "hello";
            int countElementsForDeleting = Convert.ToInt32(mStringAfterKey);
            result = result.Remove(result.Length - 2, countElementsForDeleting);
            return result;
        }

        public static string GiveOut()
        {
            return null;
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

