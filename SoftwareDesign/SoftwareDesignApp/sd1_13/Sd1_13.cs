namespace SoftwareDesign.sd1_13;

public class Sd113
{
    /*
     * Сначала доказываем правильность функций Max и Abs
     * Общая запись тройка Хоара для функции MaxPlusAbs
     * true ; y = Max(Abs(a), Abs(b)); y == Max(|a|, |b|)
     */
    public static long MaxPlusAbs(int a, int b)
    {
        return Max(Abs(a), Abs(b));
    }
    
    /*
     * true; y = Max(a, b); y = max(a, b)
     * if a >= b then y == a
     * if a < b then y == b
     */
    private static long Max(long a, long b)
    {
        return a >= b ? a : b;
    }

    /*
     * true; y = Abs(x); y == |x|
     * if x >= 0 then |x| == x
     * if x < 0 then |x| == -x
     */
    private static long Abs(int x)
    {
        return x >= 0 ? x : -(long)x;
    }
}