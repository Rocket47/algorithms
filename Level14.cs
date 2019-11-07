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

            // вычислим сумму скидки, если покупать по 3 товара
            if (price.Length > 2)
            {
                int counterGoods = price.Length / 3;
                for (int i = 2; i < price.Length; i += 3)
                {
                    maximumDiscountThreeGood += price[i];
                }
                int min = price[0];                
                for (int j = 0; j < counterGoods; j++)
                {
                    for (int k = 0; k < price.Length; k++)
                    {
                        if (min > price[k])
                        {
                            min = price[k];
                        }
                    }
                    maximumDiscountAfterDivision += min;
                } 
                
            }
            //**********************           
            
            return maximumDiscountAfterDivision;
        }
    }
}

