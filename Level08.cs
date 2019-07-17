using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
       
        static void Main(string[] args)
        {
            HowManyTimes("123", "1102353");
            Console.ReadKey();
        }

        public static int HowManyTimes(string s, string s_generic)
        {            
            char[] inputStringToChar = s.ToCharArray();
            char[] genericStringToChar = s_generic.ToCharArray();
            int counter = 0;
            Dictionary<int, List<int>> list = new Dictionary<int, List<int>>();            
            foreach (char i in inputStringToChar)
            {
                List<int> test = new List<int>();
                for (int j = 0; j < genericStringToChar.Length; j++)
                {                    
                    if (i.Equals(genericStringToChar[j]))
                    {
                        test.Add(j);
                    }
                }
                list.Add(counter, test);
                counter++;
            }

            foreach (KeyValuePair<int, List<int>> kvp in list)
            {
                //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, String.Join(", ", kvp.Value));
            }



            return 0;
           
        }
    }
}
