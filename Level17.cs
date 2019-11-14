using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static void Main(string[] args)
        {
            BastShoe("3 hello");
        }

        public static string BastShoe(string command)
        {
            int key = 0;
            string result = "";
            key = Convert.ToInt32(command.Substring(0, command.IndexOf(" ")));

            switch (key)
            {
                case 1:
                   result = Add();
                   break;
                case 2:
                    result = Delete();
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

        public static string Add()
        {
            return null;
        }

        public static string Delete()
        {
            return null;
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

