using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {

        public static void Main(string[] args)
        {
            int result = MaximumDiscount(3, new int[] { 400, 350, 300, 250, 200, 150, 100 });
            Console.WriteLine($"Maximum discount is {result}");
            Console.ReadKey();
        }

        public static int MaximumDiscount(int N, int[] price)
        {
            int maximumDiscountThreeGood = 0;
            int maximumDiscountAfterDivision = 0;
            int finalDiscount = 0;            
            if (price.Length == 3)
            {
                int min = price[0];
                for (int i = 1; i < price.Length; i++)
                {
                    if (min > price[i])
                    {
                        min = price[i];
                    }
                }
                finalDiscount = min;
            }          

            if (price.Length > 3)
            {
                int j = 0;
                int minValue = price[0];
                int counter = 0;               
                int counterGoods = price.Length / 3;
                for (int i = 0; i < counterGoods; i++)
                {
                    int min = price[j];                                        
                    for (int k = 0; k < 3; k++)
                    {
                        int tmp = k;
                        if (min > price[tmp + j])
                        {
                            min = price[tmp + j];
                        }                        
                    }
                    maximumDiscountThreeGood += min;
                    j = i + 3;
                }
                                       
                for (int m = 0; m < price.Length - 1; m++)
                {
                    for (int l = m + 1; l < price.Length - 1; l++)
                    {
                        if (price[m] > price[l + 1])
                        {
                            int saveValue = price[m];
                            price[m] = price[l + 1];
                            price[l + 1] = saveValue;
                        }
                    }
                }
                
                foreach (int test in price)
                {
                    Console.Write(test + " ");
                }
               while (counter < counterGoods)
                {
                    maximumDiscountAfterDivision += price[counter];
                    counter++;
                }

                if (maximumDiscountAfterDivision > maximumDiscountThreeGood)
                {
                    finalDiscount = maximumDiscountAfterDivision;
                }
                else
                {
                    finalDiscount = maximumDiscountThreeGood;
                }
            }
            return finalDiscount;
        }
    }
}

