import java.util.*;

public class Level1 {
    public static int odometer(int[] oksana) {
        int countLast = 0;
        int countMemb = 0;
        int sum = 0;
        int saveSum = 0;
        for (int i = 0; i < oksana.length; i++) {
            if (i % 2 != 0) {
                countLast = oksana[i];
                if (countLast != 0) {
                    countLast = countLast - countMemb;
                    countMemb = countLast;
                }
                saveSum = sum;
                sum = oksana[i-1] * countLast;
                sum = saveSum + sum;
            }
        }
        return sum;
    }
}