namespace SoftwareDesign.sd1_15;

public class SD115
{
    /// <remarks>
    /// Тройка Хоара { arr != null; QuickSort(arr); { arr отсортирован по возрастанию }
    ///
    /// Предусловие: массив arr существует.
    ///
    /// Постусловие: для любых соседних элементов выполняется arr[x] <= arr[x + 1].
    ///
    /// Инвариант выполнения цикла:
    /// перед каждой итерацией элементы слева от i не больше pivot, а элементы справа от j не меньше pivot.
    ///
    /// Перед циклом:
    /// i указывает на начало сортируемой части, а j — на конец.
    ///
    /// Инвариант:
    /// указатель i движется вправо, пока элементы меньше pivot.
    /// Указатель j движется влево, пока элементы больше pivot.
    /// Если i <= j, элементы arr[i] и arr[j] меняются местами.
    ///
    /// Завершение цикла:
    /// цикл заканчивается, когда i > j.
    /// В левой части находятся элементы, не превышающие pivot, а в правой — элементы, не меньшие pivot.
    ///
    /// </remarks>
    public static void QuickSort(int[] arr)
    {
        QuickSort(arr, 0, arr.Length - 1);
    }

    private static void QuickSort(int[] arr, int left, int right)
    {
        while (true)
        {
            if (left >= right) return;

            var i = left;
            var j = right;
            var pivot = arr[left + (right - left) / 2];

            while (i <= j)
            {
                while (arr[i] < pivot) i++;

                while (arr[j] > pivot) j--;

                if (i > j) continue;
                (arr[i], arr[j]) = (arr[j], arr[i]);

                i++;
                j--;
            }

            if (left < j) QuickSort(arr, left, j);

            if (i < right)
            {
                left = i;
                continue;
            }

            break;
        }
    }
}