using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AlgorithmsDataStructures2
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("Вы работаете с int or string?");
            string mode = Console.ReadLine();
            if (mode.Equals("int"))
            {
                Console.WriteLine("Введите значение корня: ");
                int rootValue = Convert.ToInt32(Console.ReadLine());
                SimpleTreeNode<int> root = new SimpleTreeNode<int>(rootValue, null);               
                Console.WriteLine("Дерево создано. Введите следующую команду...");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1. AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)");
                Console.WriteLine("2. DeleteNode(SimpleTreeNode<T> NodeToDelete)");
                Console.WriteLine("3. GetAllNodes()");
                Console.WriteLine("4. FindNodesByValue(T val)");
                Console.WriteLine("5. MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)");
                Console.WriteLine("6. Count()");
                Console.WriteLine("7. LeafCount()");
                string nextCommand = Console.ReadLine();
                while (!nextCommand.Equals("exit"))
                {
                    SimpleTree<int> simpleTree = new SimpleTree<int>(root);
                    switch (nextCommand)
                    {
                        case "1":
                            Console.WriteLine("Показываю текущие узлы. Выберите родительский узел: ");
                            Console.WriteLine();
                           ShowSimpleTreeInt(root, "", true);
                            Console.WriteLine();
                            int nodeNumber = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите значение для нового узла: ");
                            int newNodeValue = Convert.ToInt32(Console.ReadLine());
                            SimpleTreeNode<int> newNode = new SimpleTreeNode<int>(newNodeValue, null);
                            Console.WriteLine("Спасибо. Добавляю новый узел. Метод AddChild() отработал");
                            simpleTree.AddChild(simpleTree.GetAllNodes()[nodeNumber], newNode);
                            Console.WriteLine("Вывожу актуальное дерево: ");
                           ShowSimpleTreeInt(root, "", true);
                            Console.WriteLine();
                            Console.WriteLine("Введите следующую команду: ");
                            nextCommand = Console.ReadLine();
                            break;
                        case "2":
                            Console.WriteLine("Показываю текущие узлы. Выберите узел для удаления: ");
                           ShowSimpleTreeInt(root, "", true);
                            Console.WriteLine();
                            int nodeNumberToDelete = Convert.ToInt32(Console.ReadLine());
                            simpleTree.DeleteNode(simpleTree.GetAllNodes()[nodeNumberToDelete]);
                            Console.WriteLine("Метод Delete() отработал. Показываю текущее дерево: ");
                           ShowSimpleTreeInt(root, "", true);
                            Console.WriteLine("Введите следующую команду: ");
                            nextCommand = Console.ReadLine();
                            break;
                        case "3":
                            Console.WriteLine("Показываю текущие узлы: ");
                           ShowSimpleTreeInt(root, "", true);
                            Console.WriteLine();
                            Console.WriteLine("Введите следующую команду: ");
                            nextCommand = Console.ReadLine();
                            break;
                        case "4":
                            Console.WriteLine("Введите значение для поиска узла");
                            int nodeValueToSearch = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Функция поиска отработала. Вывожу найденные узлы.");
                            //ShowSimpleTreeInt(simpleTree.FindNodesByValue(nodeValueToSearch));
                            Console.WriteLine();
                            Console.WriteLine("Введите следующую команду: ");
                            nextCommand = Console.ReadLine();
                            break;
                        case "5":
                            Console.WriteLine("Выберите Node для переноса: ");
                           ShowSimpleTreeInt(root, "", true);
                            Console.WriteLine();
                            int nodeNumberToMove = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Выберите нового родителя: ");
                            int nodeNumberNewparent = Convert.ToInt32(Console.ReadLine());
                            simpleTree.MoveNode(simpleTree.GetAllNodes()[nodeNumberToMove], simpleTree.GetAllNodes()[nodeNumberNewparent]);
                            Console.WriteLine("Функция Move() отработала. Вывожу найденные узлы.");
                           ShowSimpleTreeInt(root, "", true);
                            Console.WriteLine();
                            Console.WriteLine("Введите следующую команду: ");
                            nextCommand = Console.ReadLine();
                            break;
                        case "6":
                            Console.WriteLine("Вывожу количество узлов: ");
                            Console.WriteLine(simpleTree.Count());
                            Console.WriteLine("Введите следующую команду: ");
                            nextCommand = Console.ReadLine();
                            break;
                        case "7":
                            Console.WriteLine("Вывожу количество листьев: ");
                            Console.WriteLine(simpleTree.LeafCount());
                            Console.WriteLine("Введите следующую команду: ");
                            nextCommand = Console.ReadLine();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Введите значение корня: ");
                string rootValue = Console.ReadLine();
                SimpleTreeNode<string> root = new SimpleTreeNode<string>(rootValue, null);                
                Console.WriteLine("Дерево создано. Введите следующую команду...");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1. AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)");
                Console.WriteLine("2. DeleteNode(SimpleTreeNode<T> NodeToDelete)");
                Console.WriteLine("3. GetAllNodes()");
                Console.WriteLine("4. FindNodesByValue(T val)");
                Console.WriteLine("5. MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)");
                Console.WriteLine("6. Count()");
                Console.WriteLine("7. LeafCount()");
                string nextCommand = Console.ReadLine();
                while (!nextCommand.Equals("exit"))
                {
                    SimpleTree<string> simpleTree = new SimpleTree<string>(root);
                    switch (nextCommand)
                    {
                        case "1":
                            Console.WriteLine("Показываю текущие узлы. Выберите родительский узел: ");
                            ShowSimpleTreeString(root, "", true);
                            Console.WriteLine();
                            int nodeNumber = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите значение для нового узла: ");
                            int newNodeValue = Convert.ToInt32(Console.ReadLine());
                            SimpleTreeNode<int> newNode = new SimpleTreeNode<int>(newNodeValue, null);
                            Console.WriteLine("Спасибо. Добавляю новый узел. Метод AddChild() отработал");
                            simpleTree.AddChild(simpleTree.GetAllNodes()[nodeNumber], newNode);
                            Console.WriteLine("Вывожу актуальное дерево: ");
                            ShowSimpleTreeString(root, "", true);
                            Console.WriteLine();
                            Console.WriteLine("Введите следующую команду: ");
                            nextCommand = Console.ReadLine();
                            break;
                        case "2":
                            Console.WriteLine("Показываю текущие узлы. Выберите узел для удаления: ");
                            ShowSimpleTreeString(root, "", true);
                            Console.WriteLine();
                            int nodeNumberToDelete = Convert.ToInt32(Console.ReadLine());
                            simpleTree.DeleteNode(simpleTree.GetAllNodes()[nodeNumberToDelete]);
                            Console.WriteLine("Метод Delete() отработал. Показываю текущее дерево: ");
                            ShowSimpleTreeString(root, "", true);
                            Console.WriteLine("Введите следующую команду: ");
                            nextCommand = Console.ReadLine();
                            break;
                        case "3":
                            Console.WriteLine("Показываю текущие узлы: ");
                            ShowSimpleTreeString(root, "", true);
                            Console.WriteLine();
                            Console.WriteLine("Введите следующую команду: ");
                            nextCommand = Console.ReadLine();
                            break;
                        case "4":
                            Console.WriteLine("Введите значение для поиска узла");
                            int nodeValueToSearch = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Функция поиска отработала. Вывожу найденные узлы.");
                            //ShowSimpleTreeInt(simpleTree.FindNodesByValue(nodeValueToSearch));
                            Console.WriteLine();
                            Console.WriteLine("Введите следующую команду: ");
                            nextCommand = Console.ReadLine();
                            break;
                        case "5":
                            Console.WriteLine("Выберите Node для переноса: ");
                            ShowSimpleTreeString(root, "", true);
                            Console.WriteLine();
                            int nodeNumberToMove = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Выберите нового родителя: ");
                            int nodeNumberNewparent = Convert.ToInt32(Console.ReadLine());
                            simpleTree.MoveNode(simpleTree.GetAllNodes()[nodeNumberToMove], simpleTree.GetAllNodes()[nodeNumberNewparent]);
                            Console.WriteLine("Функция Move() отработала. Вывожу найденные узлы.");
                            ShowSimpleTreeString(root, "", true);
                            Console.WriteLine();
                            Console.WriteLine("Введите следующую команду: ");
                            nextCommand = Console.ReadLine();
                            break;
                        case "6":
                            Console.WriteLine("Вывожу количество узлов: ");
                            Console.WriteLine(simpleTree.Count());
                            Console.WriteLine("Введите следующую команду: ");
                            nextCommand = Console.ReadLine();
                            break;
                        case "7":
                            Console.WriteLine("Вывожу количество листьев: ");
                            Console.WriteLine(simpleTree.LeafCount());
                            Console.WriteLine("Введите следующую команду: ");
                            nextCommand = Console.ReadLine();
                            break;
                    }
                }
            }
            
        }

        public static void ShowSimpleTreeInt(SimpleTreeNode<int> tree, string indent, bool last)
        {            
            Console.WriteLine(indent + "+- " + tree.NodeValue);           
            indent += last ? "   " : "|  ";

            if (tree.Children != null)
            {
                for (int i = 0; i < tree.Children.Count; i++)
                {                  
                    ShowSimpleTreeInt(tree.Children[i], indent, i == tree.Children.Count - 1);
                }
            }
        }

        public static void ShowSimpleTreeString(SimpleTreeNode<string> tree, string indent, bool last)
        {
            Console.WriteLine(indent + "+- " + tree.NodeValue);
            indent += last ? "   " : "|  ";

            if (tree.Children != null)
            {
                for (int i = 0; i < tree.Children.Count; i++)
                {
                    ShowSimpleTreeString(tree.Children[i], indent, i == tree.Children.Count - 1);
                }
            }
        }
    }
}

