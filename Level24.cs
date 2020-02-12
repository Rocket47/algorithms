using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static void Main(string[] args)
        {
            Keymaker(7);
            Console.ReadKey();
        }
        public static string Keymaker(int k)
        {
            string result = "";
            Dictionary<int, bool> ListDoors = new Dictionary<int, bool>();
            for (int i = 1; i <= k; i++)
            {
                ListDoors.Add(i, false);
            }
            Console.WriteLine("Intiialize program...");
            ShowDictionary(ListDoors);
            Console.WriteLine("------------------------");
            Console.WriteLine("Started to initialize step by step...");
            Console.WriteLine("************************");
            for (int j = 1; j <= k; j++)
            {
                if (j == 1)
                {
                    Console.WriteLine("Performing 1st step...");
                    Console.WriteLine("************************");
                    for (int FirstStep = 1; FirstStep <= k; FirstStep++)
                    {
                        ListDoors[FirstStep] = true;
                    }
                    ShowDictionary(ListDoors);
                    Console.WriteLine("------------------------");
                }
                if (j == 2)
                {
                    Console.WriteLine("Performing 2nd step...");
                    Console.WriteLine("************************");
                    for (int SecondStep = 2; SecondStep <= k; SecondStep += 2)
                    {                       
                            ListDoors[SecondStep] = false;                        
                    }
                    ShowDictionary(ListDoors);
                    Console.WriteLine("------------------------");
                }
                if (j == 3)
                {
                    Console.WriteLine("Performing 3rd step...");
                    Console.WriteLine("************************");
                    for (int ThirdStep = 3; ThirdStep <= k; ThirdStep += 3)
                    {
                        if (ListDoors[ThirdStep] == true)
                        {
                            ListDoors[ThirdStep] = false;
                        }
                        else
                        {
                            ListDoors[ThirdStep] = true;
                        }                       
                    }
                    ShowDictionary(ListDoors);
                    Console.WriteLine("------------------------");
                }
                if (j >= 4)
                {
                    Console.WriteLine("Performing " + j + " step...");
                    Console.WriteLine("************************");
                    ListDoors[j] = ListDoors[j] == true ? false : true;
                    ShowDictionary(ListDoors);
                    Console.WriteLine("------------------------");
                }
                result = GenerateResultString(ListDoors, k);
                Console.WriteLine("Print result string...");
                Console.WriteLine(result);
            }
            return result;
        }

        public static void ShowDictionary(Dictionary<int, bool> Dictionary)
        {
            foreach (KeyValuePair<int, bool> kvp in Dictionary)
            {
                Console.WriteLine("Door = {0}, Status = {1}", kvp.Key, kvp.Value);
            }
        }

        public static string GenerateResultString(Dictionary<int, bool> mListDoors, int CountDoors)
        {
            string mResult = "";
            string mIndexDoor = "";
            for (int i = 1; i <= CountDoors; i++)
            {
                mIndexDoor = mListDoors[i] == true ? "1" : "0";
                mResult += mIndexDoor;
            }
            return mResult;
        }
    }
}
    
