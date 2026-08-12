using HardWork.Tasks.Task3SortThreeNumbers.Models;

namespace HardWork.Tasks.Task3SortThreeNumbers.After;

public sealed class ThreeNumberSorterAfter
{
    public IReadOnlyList<int> SortDescending(SortRequest request) =>
        new[] { request.First, request.Second, request.Third }
            .OrderDescending()
            .ToArray();
}
