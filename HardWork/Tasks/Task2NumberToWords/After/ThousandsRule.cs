using HardWork.Tasks.Task2NumberToWords.Models;

namespace HardWork.Tasks.Task2NumberToWords.After;

internal sealed class ThousandsRule : INumberWordRule
{
    public bool CanConvert(int value) => value is > 999 and < 1000000;

    public string Convert(NumberWordRequest request, NumberToWordsAfter converter)
    {
        var thousands = request.Value / 1000;
        var rest = request.Value % 1000;
        var prefix = converter.Convert(new NumberWordRequest(thousands, request.Separator)) + " thousand";
        return rest == 0 ? prefix : prefix + request.Separator + converter.Convert(new NumberWordRequest(rest, request.Separator));
    }
}
