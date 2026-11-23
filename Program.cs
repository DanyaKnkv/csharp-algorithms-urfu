using AlgorithmsPortfolio;

Console.WriteLine("=== C# Algorithms Portfolio ===");

// ------------------------------------
// 1. Сортировка и бинарный поиск
// ------------------------------------

int[] numbers = { 34, 7, 23, 32, 5, 62, 15 };

Console.WriteLine("\nИсходный массив:");
Console.WriteLine(string.Join(", ", numbers));

int[] quickSorted = SortingAndSearch.QuickSort(numbers);

Console.WriteLine("\nQuickSort:");
Console.WriteLine(string.Join(", ", quickSorted));

int[] mergeSorted = SortingAndSearch.MergeSort(numbers);

Console.WriteLine("\nMergeSort:");
Console.WriteLine(string.Join(", ", mergeSorted));

int target = 23;

int index = SortingAndSearch.BinarySearch(
    mergeSorted,
    target);

Console.WriteLine(
    $"\nБинарный поиск числа {target}: индекс {index}");

// ------------------------------------
// 2. Обход графа в ширину и глубину
// ------------------------------------

var graph = new Dictionary<int, List<int>>
{
    { 0, new List<int> { 1, 2 } },
    { 1, new List<int> { 0, 3, 4 } },
    { 2, new List<int> { 0, 4 } },
    { 3, new List<int> { 1, 5 } },
    { 4, new List<int> { 1, 2, 5 } },
    { 5, new List<int> { 3, 4 } }
};

Console.WriteLine("\n=== Обход графа ===");

List<int> bfs = GraphAlgorithms.BreadthFirstSearch(
    graph,
    0);

Console.WriteLine("BFS:");
Console.WriteLine(string.Join(" -> ", bfs));

List<int> dfs = GraphAlgorithms.DepthFirstSearch(
    graph,
    0);

Console.WriteLine("\nDFS:");
Console.WriteLine(string.Join(" -> ", dfs));

// ------------------------------------
// 3. Алгоритм Дейкстры
// ------------------------------------

var weightedGraph =
    new Dictionary<int, List<(int Neighbor, int Weight)>>
{
    {
        0,
        new List<(int, int)>
        {
            (1, 4),
            (2, 1)
        }
    },
    {
        1,
        new List<(int, int)>
        {
            (0, 4),
            (2, 2),
            (3, 1)
        }
    },
    {
        2,
        new List<(int, int)>
        {
            (0, 1),
            (1, 2),
            (3, 5),
            (4, 8)
        }
    },
    {
        3,
        new List<(int, int)>
        {
            (1, 1),
            (2, 5),
            (4, 3)
        }
    },
    {
        4,
        new List<(int, int)>
        {
            (2, 8),
            (3, 3)
        }
    }
};

Console.WriteLine("\n=== Алгоритм Дейкстры ===");

Dictionary<int, int> shortestPaths =
    GraphAlgorithms.Dijkstra(weightedGraph, 0);

foreach (var pair in shortestPaths.OrderBy(pair => pair.Key))
{
    string distanceText = pair.Value == int.MaxValue
        ? "нет пути"
        : pair.Value.ToString();

    Console.WriteLine(
        $"Расстояние от вершины 0 до {pair.Key}: {distanceText}");
}

Console.WriteLine("\nРабота программы завершена.");