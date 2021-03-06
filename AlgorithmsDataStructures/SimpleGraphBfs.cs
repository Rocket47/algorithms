using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Vertex<T>
    {
        public bool Hit;
        public T Value;
        public Vertex(T val)
        {
            Value = val;
            Hit = false;
        }
    }

    public class SimpleGraph<T>
    {
        public Vertex<T>[] vertex;
        public Vertex<T>[] path;
        public int[,] m_adjacency;
        public int max_vertex;

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int[size, size];
            vertex = new Vertex<T>[size];
            path = new Vertex<T>[size];
        }

        public void AddVertex(T value)
        {
            // ваш код добавления новой вершины 
            // с значением value 
            // в свободную позицию массива vertex
            for (int i = 0; i < vertex.Length; i++)
            {
                if (vertex[i] == null)
                {
                    vertex[i] = new Vertex<T>(value);
                    break;
                }
            }
        }

        // здесь и далее, параметры v -- индекс вершины
        // в списке  vertex
        public void RemoveVertex(int v)
        {
            // ваш код удаления вершины со всеми её рёбрами
            for (int i = 0; i < vertex.Length; i++)
            {
                m_adjacency[v, i] = 0;
                m_adjacency[i, v] = 0;
            }
            vertex[v] = null;
        }

        public bool IsEdge(int v1, int v2)
        {
            // true если есть ребро между вершинами v1 и v2
            if (m_adjacency[v1, v2] == 1 && m_adjacency[v2, v1] == 1)
            {
                return true;
            }
            return false;
        }

        public void AddEdge(int v1, int v2)
        {
            // добавление ребра между вершинами v1 и v2
            m_adjacency[v1, v2] = 1;
            m_adjacency[v2, v1] = 1;
        }

        public void RemoveEdge(int v1, int v2)
        {
            // удаление ребра между вершинами v1 и v2
            m_adjacency[v1, v2] = 0;
            m_adjacency[v2, v1] = 0;
        }

        public List<Vertex<T>> DepthFirstSearch(int VFrom, int VTo)
        {
            // Узлы задаются позициями в списке vertex.
            // Возвращается список узлов -- путь из VFrom в VTo.
            // Список пустой, если пути нету.
            for (int i = 0; i < vertex.Length; i++)
            {
                vertex[i].Hit = false;
            }
            Stack<int> trace = new Stack<int>();
            List<Vertex<T>> result = new List<Vertex<T>>();
            int current = VFrom;
            vertex[current].Hit = true;
            trace.Push(current);
            while (trace.Count != 0)
            {
                current = trace.Pop();
                result.Add(vertex[current]);
                for (int i = 0; i <= m_adjacency.GetUpperBound(0); i++)
                {
                    if (m_adjacency[current, i] == 1 && i == VTo)
                    {
                        result.Add(vertex[i]);
                        return result;
                    }
                    if (m_adjacency[current, i] == 1 && vertex[i].Hit != true)
                    {
                        trace.Push(i);
                        vertex[i].Hit = true;
                    }
                }
            }
            result.Clear();
            return result;
        }

        public List<Vertex<T>> BreadthFirstSearch(int VFrom, int VTo)
        {
            // узлы задаются позициями в списке vertex.
            // возвращает список узлов -- путь из VFrom в VTo
            // или пустой список, если пути нету
            for (int i = 0; i < vertex.Length; i++)
            {
                vertex[i].Hit = false;
                path[i] = null;
            }
            // обход в ширину
            Queue<int> trace = new Queue<int>();
            int current = VFrom;
            vertex[current].Hit = true;
            trace.Enqueue(current);
            while (trace.Count!=0)
            {
                current = trace.Dequeue();
                for (int i = 0; i <= m_adjacency.GetUpperBound(0); i++)
                {
                    if (m_adjacency[current, i] == 1 && vertex[i].Hit != true)
                    {
                        vertex[i].Hit = true;
                        path[i] = vertex[current];
                        trace.Enqueue(i);
                    }
                }
            }
			
            List<Vertex<T>> result = new List<Vertex<T>>();
            current = VTo;
            while (path[current]!=null)
            {
                result.Add(vertex[current]);
                current = Array.IndexOf(vertex,path[current]);
            }
            result.Add(vertex[VFrom]);
            result.Reverse();
            if (result.Count==1) result.Clear(); // если в списке одна вершина, значит пути не существует и список надо обнулить
            return result;
        }
    }
}