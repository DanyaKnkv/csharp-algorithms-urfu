namespace AlgorithmsPortfolio;

/// <summary>
/// Алгоритмы сортировки и поиска.
/// </summary>
public static class SortingAndSearch
{
    /// <summary>
    /// Быстрая сортировка.
    /// Средняя сложность: O(n log n).
    /// Худшая сложность: O(n^2).
    /// </summary>
    public static int[] QuickSort(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        int[] result = (int[])array.Clone();

        QuickSortRecursive(result, 0, result.Length - 1);

        return result;
    }

    private static void QuickSortRecursive(
        int[] array,
        int low,
        int high)
    {
        if (low >= high)
        {
            return;
        }

        int pivotIndex = Partition(array, low, high);

        QuickSortRecursive(array, low, pivotIndex - 1);
        QuickSortRecursive(array, pivotIndex + 1, high);
    }

    private static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] <= pivot)
            {
                i++;

                (array[i], array[j]) = (array[j], array[i]);
            }
        }

        (array[i + 1], array[high]) =
            (array[high], array[i + 1]);

        return i + 1;
    }

    /// <summary>
    /// Сортировка слиянием.
    /// Временная сложность: O(n log n).
    /// Дополнительная память: O(n).
    /// </summary>
    public static int[] MergeSort(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        int[] result = (int[])array.Clone();
        int[] temporary = new int[result.Length];

        MergeSortRecursive(
            result,
            temporary,
            0,
            result.Length - 1);

        return result;
    }

    private static void MergeSortRecursive(
        int[] array,
        int[] temporary,
        int left,
        int right)
    {
        if (left >= right)
        {
            return;
        }

        int middle = left + (right - left) / 2;

        MergeSortRecursive(array, temporary, left, middle);
        MergeSortRecursive(array, temporary, middle + 1, right);

        Merge(array, temporary, left, middle, right);
    }

    private static void Merge(
        int[] array,
        int[] temporary,
        int left,
        int middle,
        int right)
    {
        int i = left;
        int j = middle + 1;
        int k = left;

        while (i <= middle && j <= right)
        {
            if (array[i] <= array[j])
            {
                temporary[k] = array[i];
                i++;
            }
            else
            {
                temporary[k] = array[j];
                j++;
            }

            k++;
        }

        while (i <= middle)
        {
            temporary[k] = array[i];
            i++;
            k++;
        }

        while (j <= right)
        {
            temporary[k] = array[j];
            j++;
            k++;
        }

        Array.Copy(
            temporary,
            left,
            array,
            left,
            right - left + 1);
    }

    /// <summary>
    /// Бинарный поиск в отсортированном массиве.
    /// Временная сложность: O(log n).
    /// Возвращает индекс элемента или -1, если элемент не найден.
    /// </summary>
    public static int BinarySearch(int[] sortedArray, int target)
    {
        ArgumentNullException.ThrowIfNull(sortedArray);

        int left = 0;
        int right = sortedArray.Length - 1;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;

            if (sortedArray[middle] == target)
            {
                return middle;
            }

            if (sortedArray[middle] < target)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return -1;
    }
}