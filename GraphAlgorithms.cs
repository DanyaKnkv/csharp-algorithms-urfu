namespace AlgorithmsPortfolio;

/// <summary>
/// Алгоритмы работы с графами.
/// </summary>
public static class GraphAlgorithms
{
    /// <summary>
    /// Поиск в ширину (BFS).
    /// Временная сложность: O(V + E).
    /// </summary>
    public static List<int> BreadthFirstSearch(
        Dictionary<int, List<int>> graph,
        int start)
    {
        if (!graph.ContainsKey(start))
        {
            throw new ArgumentException(
                "Начальная вершина отсутствует в графе.");
        }

        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        var result = new List<int>();

        visited.Add(start);
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int vertex = queue.Dequeue();
            result.Add(vertex);

            foreach (int neighbor in graph[vertex])
            {
                if (!graph.ContainsKey(neighbor))
                {
                    continue;
                }

                if (visited.Add(neighbor))
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Поиск в глубину (DFS).
    /// Временная сложность: O(V + E).
    /// </summary>
    public static List<int> DepthFirstSearch(
        Dictionary<int, List<int>> graph,
        int start)
    {
        if (!graph.ContainsKey(start))
        {
            throw new ArgumentException(
                "Начальная вершина отсутствует в графе.");
        }

        var visited = new HashSet<int>();
        var result = new List<int>();

        void Visit(int vertex)
        {
            visited.Add(vertex);
            result.Add(vertex);

            foreach (int neighbor in graph[vertex])
            {
                if (graph.ContainsKey(neighbor) &&
                    !visited.Contains(neighbor))
                {
                    Visit(neighbor);
                }
            }
        }

        Visit(start);

        return result;
    }

    /// <summary>
    /// Алгоритм Дейкстры для поиска кратчайших путей.
    /// Временная сложность: O((V + E) log V).
    /// Все веса рёбер должны быть неотрицательными.
    /// </summary>
    public static Dictionary<int, int> Dijkstra(
        Dictionary<int, List<(int Neighbor, int Weight)>> graph,
        int start)
    {
        if (!graph.ContainsKey(start))
        {
            throw new ArgumentException(
                "Начальная вершина отсутствует в графе.");
        }

        // Проверяем веса и наличие всех соседних вершин.
        foreach (var edges in graph.Values)
        {
            foreach (var edge in edges)
            {
                if (edge.Weight < 0)
                {
                    throw new ArgumentException(
                        "Алгоритм Дейкстры не поддерживает отрицательные веса.");
                }

                if (!graph.ContainsKey(edge.Neighbor))
                {
                    throw new ArgumentException(
                        "Вершина-сосед отсутствует в графе.");
                }
            }
        }

        var distances = graph.Keys.ToDictionary(
            vertex => vertex,
            _ => int.MaxValue);

        var priorityQueue = new PriorityQueue<int, int>();

        distances[start] = 0;
        priorityQueue.Enqueue(start, 0);

        while (priorityQueue.TryDequeue(
            out int currentVertex,
            out int currentDistance))
        {
            // Пропускаем устаревшую запись в очереди.
            if (currentDistance != distances[currentVertex])
            {
                continue;
            }

            foreach (var edge in graph[currentVertex])
            {
                // Защита от переполнения int.
                if (currentDistance > int.MaxValue - edge.Weight)
                {
                    continue;
                }

                int newDistance = currentDistance + edge.Weight;

                if (newDistance < distances[edge.Neighbor])
                {
                    distances[edge.Neighbor] = newDistance;

                    priorityQueue.Enqueue(
                        edge.Neighbor,
                        newDistance);
                }
            }
        }

        return distances;
    }
}