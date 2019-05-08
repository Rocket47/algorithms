import java.util.*;

public class Level1
{
    public static int squirrel(int N)
    {
        int valueFactorial = 1;
        for (int i = 1; i  <= N; i++) {
            valueFactorial = valueFactorial * i;
        }
        while (valueFactorial >= 10) {
            valueFactorial /= 10;
        }
        return valueFactorial;
    }
}