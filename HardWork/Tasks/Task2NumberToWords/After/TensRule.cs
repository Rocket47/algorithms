using HardWork.Tasks.Task2NumberToWords.Models;

namespace HardWork.Tasks.Task2NumberToWords.After;

internal sealed class TensRule : INumberWordRule
{
    private readonly IReadOnlyDictionary<int, string> _words;

    public TensRule(IReadOnlyDictionary<int, string> words)
    {
        _words = words;
    }

    public bool CanConvert(int value) => value is > 19 and < 100;

    public string Convert(NumberWordRequest request, NumberToWordsAfter converter)
    {
        var tens = request.Value / 10 * 10;
        var units = request.Value % 10;
        return _words[tens] + request.Separator + _words[units];
    }
}
