using HardWork.Tasks.Task2NumberToWords.Models;

namespace HardWork.Tasks.Task2NumberToWords.Before;

public sealed class NumberToWordsBefore
{
    public string Convert(NumberWordRequest request)
    {
        var value = request.Value;
        var separator = request.Separator;

        if (value < 0)
        {
            return "minus " + Convert(new NumberWordRequest(Math.Abs(value), separator));
        }

        if (value < 20)
        {
            return GetWord(value);
        }

        if (value < 100)
        {
            var tens = value / 10 * 10;
            var units = value % 10;

            if (units == 0)
            {
                return GetWord(tens);
            }

            return GetWord(tens) + separator + GetWord(units);
        }

        if (value < 1000)
        {
            var hundreds = value / 100;
            var rest = value % 100;

            if (rest == 0)
            {
                return GetWord(hundreds) + " hundred";
            }

            return GetWord(hundreds) + " hundred" + separator + Convert(new NumberWordRequest(rest, separator));
        }

        if (value < 1000000)
        {
            var thousands = value / 1000;
            var rest = value % 1000;

            if (rest == 0)
            {
                return Convert(new NumberWordRequest(thousands, separator)) + " thousand";
            }

            return Convert(new NumberWordRequest(thousands, separator)) +
                   " thousand" +
                   separator +
                   Convert(new NumberWordRequest(rest, separator));
        }

        return "too big";
    }

    private static string GetWord(int value)
    {
        switch (value)
        {
            case 0: return "zero";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            case 9: return "nine";
            case 10: return "ten";
            case 11: return "eleven";
            case 12: return "twelve";
            case 13: return "thirteen";
            case 14: return "fourteen";
            case 15: return "fifteen";
            case 16: return "sixteen";
            case 17: return "seventeen";
            case 18: return "eighteen";
            case 19: return "nineteen";
            case 20: return "twenty";
            case 30: return "thirty";
            case 40: return "forty";
            case 50: return "fifty";
            case 60: return "sixty";
            case 70: return "seventy";
            case 80: return "eighty";
            case 90: return "ninety";
            default: return "";
        }
    }
}
