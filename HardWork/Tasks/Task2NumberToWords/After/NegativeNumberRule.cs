using HardWork.Tasks.Task2NumberToWords.Models;

namespace HardWork.Tasks.Task2NumberToWords.After;

internal sealed class NegativeNumberRule : INumberWordRule
{
    public bool CanConvert(int value) => value < 0;

    public string Convert(NumberWordRequest request, NumberToWordsAfter converter) =>
        "minus " + converter.Convert(new NumberWordRequest(Math.Abs(request.Value), request.Separator));
}
