using HardWork.Tasks.Task2NumberToWords.Models;

namespace HardWork.Tasks.Task2NumberToWords.After;

internal sealed class HundredsRule : INumberWordRule
{
    public bool CanConvert(int value) => value is > 99 and < 1000;

    public string Convert(NumberWordRequest request, NumberToWordsAfter converter)
    {
        var hundreds = request.Value / 100;
        var rest = request.Value % 100;
        var prefix = converter.Convert(new NumberWordRequest(hundreds, request.Separator)) + " hundred";
        return rest == 0 ? prefix : prefix + request.Separator + converter.Convert(new NumberWordRequest(rest, request.Separator));
    }
}
