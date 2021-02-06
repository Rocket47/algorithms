using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Vertex
    {
        public int Value;
        public Vertex(int val)
        {
            Value = val;
        }
    }

    public class SimpleGraph
    {
        public Vertex[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int[size, size];
            vertex = new Vertex[size];
        }

        public void AddVertex(int value)
        {
            var newVertex = new Vertex(value);
            for (int i = 0; i < vertex.Length; i++)
            {
                if (vertex[i] == null)
                {
                    vertex[i] = newVertex;
                    break;
                }
            }
        }

        // здесь и далее, параметры v -- индекс вершины
        // в списке  vertex
        public void RemoveVertex(int v)
        {
            // ваш код удаления вершины со всеми её рёбрами
            if (v < max_vertex)
            {
                while (v + 1 < max_vertex)
                {
                    int i;
                    //rows
                    for (i = 0; i < max_vertex; i++)
                    {
                        m_adjacency[i, v] = m_adjacency[i, v + 1];
                    }

                    //columns 
                    for (i = 0; i < max_vertex; i++)
                    {
                        m_adjacency[v, i] = m_adjacency[v + 1, i];
                    }
                    v++;
                }
                if (max_vertex > 0)
                {
                    max_vertex--;
                }
            }   
            else
            {
                return;
            }
        }

        public bool IsEdge(int v1, int v2)
        {
            // true если есть ребро между вершинами v1 и v2
            if (m_adjacency != null)
            {
                if (m_adjacency[v1, v2] == 1) { return true; }
            }
            return false;
        }

        public void AddEdge(int v1, int v2)
        {
            if (v1 < 0 || v2 < 0 || v1 >= max_vertex || v2 >= max_vertex)
            {
                return;
            }

            if (!VertexExists(v1, vertex) || !VertexExists(v2, vertex))
            {
                return;
            }

            var pos1 = GetPosVertex(v1, vertex);
            var pos2 = GetPosVertex(v2, vertex);

            if (pos1 >= 0 && pos2 >= 0)
            {
                // добавление ребра между вершинами v1 и v2
                if (v1 != v2)
                {
                    m_adjacency[v1, v2] = 1;
                }
            }
        }

        public void RemoveEdge(int v1, int v2)
        {
            // удаление ребра между вершинами v1 и v2
        }

        public bool VertexExists(int v1, Vertex[] array)
        {
            foreach (var tmp in array)
            {
                if (tmp != null)
                {
                    if (tmp.Value == v1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int GetPosVertex(int v, Vertex[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    if (array[i].Value == v)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}