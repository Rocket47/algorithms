using HardWork.Tasks.Task2NumberToWords.Models;

namespace HardWork.Tasks.Task2NumberToWords.After;

public sealed class NumberToWordsAfter
{
    private static readonly IReadOnlyDictionary<int, string> Words =
        new Dictionary<int, string>
        {
            [0] = "zero",
            [1] = "one",
            [2] = "two",
            [3] = "three",
            [4] = "four",
            [5] = "five",
            [6] = "six",
            [7] = "seven",
            [8] = "eight",
            [9] = "nine",
            [10] = "ten",
            [11] = "eleven",
            [12] = "twelve",
            [13] = "thirteen",
            [14] = "fourteen",
            [15] = "fifteen",
            [16] = "sixteen",
            [17] = "seventeen",
            [18] = "eighteen",
            [19] = "nineteen",
            [20] = "twenty",
            [30] = "thirty",
            [40] = "forty",
            [50] = "fifty",
            [60] = "sixty",
            [70] = "seventy",
            [80] = "eighty",
            [90] = "ninety"
        };

    private readonly IReadOnlyList<INumberWordRule> _rules =
    [
        new NegativeNumberRule(),
        new DirectWordRule(Words),
        new TensRule(Words),
        new HundredsRule(),
        new ThousandsRule()
    ];

    public string Convert(NumberWordRequest request)
    {
        var rule = _rules.FirstOrDefault(candidate => candidate.CanConvert(request.Value));
        return rule?.Convert(request, this) ?? "too big";
    }
}
