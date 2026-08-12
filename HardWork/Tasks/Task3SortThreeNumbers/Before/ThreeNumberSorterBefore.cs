using HardWork.Tasks.Task3SortThreeNumbers.Models;

namespace HardWork.Tasks.Task3SortThreeNumbers.Before;

public sealed class ThreeNumberSorterBefore
{
    public IReadOnlyList<int> SortDescending(SortRequest request)
    {
        var first = request.First;
        var second = request.Second;
        var third = request.Third;

        if (first == second && first == third)
        {
            return [first, second, third];
        }

        if (first >= second && first >= third)
        {
            if (second >= third)
            {
                return [first, second, third];
            }

            return [first, third, second];
        }
        else if (second >= first && second >= third)
        {
            if (first >= third)
            {
                return [second, first, third];
            }

            return [second, third, first];
        }
        else if (third >= first && third >= second)
        {
            if (first >= second)
            {
                return [third, first, second];
            }

            return [third, second, first];
        }

        return [first, second, third];
    }
}
