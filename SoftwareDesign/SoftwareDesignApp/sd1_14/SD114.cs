namespace SoftwareDesign.sd1_14;

public class SD114
{
    /// <remarks>
    /// Тройка Хоара:
    /// { arr.Length > 0; x == FindMax(arr); x == max(arr) }, где x - результат выполнения функции
    ///
    /// Инвариант цикла:
    /// Перед каждой итерацией max содержит максимальный элемент среди уже просмотренных элементов arr[0..i-1].
    ///
    /// Перед циклом i = 1 и max = arr[0], max содержит максимальное значение из arr
    ///
    /// Сохранение инварианта:
    /// If arr[i] > max, max заменяется на arr[i] и является максимальным, if arr[i] меньше или равно max то значение не изменяется, max содержится максимум из arr[0..i]
    ///
    /// Завершение цикла: i = arr.Length. Все элементы просмотрены, max = max(arr).
    /// Вывод - x == max(arr)   
    /// </remarks>
    public static int FindMax(int[] arr)
    {
        var max = arr[0];

        for (var i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        return max;
    }
}