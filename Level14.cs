using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {      
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
                int counterGoods = price.Length / 3;
                maximumDiscountThreeGood = getDiscountThreeGood(counterGoods, price);
                maximumDiscountAfterDivision = getDiscountAfterDivision(counterGoods, price);
                finalDiscount = maximumDiscountAfterDivision >= maximumDiscountThreeGood ?  maximumDiscountAfterDivision : maximumDiscountThreeGood;                
            }
            return finalDiscount;
        }

        public static int getDiscountThreeGood(int counterGoods, int[] price)
        {
            int j = 0;
            int discountThreeGood = 0;
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
                discountThreeGood += min;
                j = j + 3;
            }
            return discountThreeGood;
        }

        public static int getDiscountAfterDivision(int counterGoods, int[] price)
        {
            int counter = 0;
            int discountAfterDivision = 0;
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

            while (counter < counterGoods)
            {
                discountAfterDivision += price[counter];
                counter++;
            }
            return discountAfterDivision;
        }
    }
}

