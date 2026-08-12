using HardWork.Tasks.Task2NumberToWords.Models;

namespace HardWork.Tasks.Task2NumberToWords.After;

internal interface INumberWordRule
{
    bool CanConvert(int value);

    string Convert(NumberWordRequest request, NumberToWordsAfter converter);
}
