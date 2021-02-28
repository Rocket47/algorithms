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
        public int[,] m_adjacency;
        public int max_vertex;

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int[size, size];
            vertex = new Vertex<T>[size];
        }

        public void AddVertex(T value)
        {
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
            m_adjacency[v1, v2] = 1;
            m_adjacency[v2, v1] = 1;
        }

        public void RemoveEdge(int v1, int v2)
        {
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
            Stack<int> stack = new Stack<int>();
            List<Vertex<T>> output = new List<Vertex<T>>();

            var current = VFrom;

            vertex[current].Hit = true;
            stack.Push(current);

            while (stack.Count != 0)
            {
                current = stack.Pop();
                output.Add(vertex[current]);

                for (int i = 0; i < m_adjacency.GetUpperBound(0); i++)
                {
                    if (m_adjacency[current, i] == 1 && i == VTo)
                    {
                        output.Add(vertex[i]);
                        return output;
                    }

                    if (m_adjacency[current, i] == 1 && vertex[i].Hit != true)
                    {
                        stack.Push(i);
                        vertex[i].Hit = true;
                    }
                }
            }
            stack.Clear();
            return output;
        }
		
		public List<Vertex<T>> BreadthFirstSearch(int VFrom, int VTo)
    {
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
            // поиск кратчайшего пути
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
            return null;
        }
    }
}