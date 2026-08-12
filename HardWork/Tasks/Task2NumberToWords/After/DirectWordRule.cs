using HardWork.Tasks.Task2NumberToWords.Models;

namespace HardWork.Tasks.Task2NumberToWords.After;

internal sealed class DirectWordRule : INumberWordRule
{
    private readonly IReadOnlyDictionary<int, string> _words;

    public DirectWordRule(IReadOnlyDictionary<int, string> words)
    {
        _words = words;
    }

    public bool CanConvert(int value) => _words.ContainsKey(value);

    public string Convert(NumberWordRequest request, NumberToWordsAfter converter) =>
        _words[request.Value];
}
