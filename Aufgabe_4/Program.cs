using System;
using System.Collections.Generic;

namespace Aufgabe_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<String>();
            var root = tree.CreateNode("root");
            var child1 = tree.CreateNode("child1");
            var child2 = tree.CreateNode("child2");
            var child3 = tree.CreateNode("Child3");
            var child4 = tree.CreateNode("Child4");
            var child5 = tree.CreateNode("Child5");
            var child6 = tree.CreateNode("Child6");
            root.AppendChild(child1);
            root.AppendChild(child2);
            root.AppendChild(child3);
            root.AppendChild(child4);
            root.AppendChild(child5);
            root.AppendChild(child6);
            var grand11 = tree.CreateNode("grand11");
            var grand12 = tree.CreateNode("grand12");
            var grand13 = tree.CreateNode("grand13");
            var grand14 = tree.CreateNode("grand14");
            var grand15 = tree.CreateNode("grand15");
            child1.AppendChild(grand11);
            child1.AppendChild(grand12);
            child1.AppendChild(grand13);
            child1.AppendChild(grand14);
            child1.AppendChild(grand15);
            child1.RemoveChild(grand14);
            var grand21 = tree.CreateNode("grand21");
            child2.AppendChild(grand21);
            child1.RemoveChild(grand12);
            var searchList = root.FindNode("child2");
            var serachList2 = root.FindNode("Child19");
            root.PrintSearch(searchList);
            root.PrintSearch(serachList2);
            root.PrintTree();
        }
    }

    public class Tree<T>
    {
        private bool gefunden = false;
        public T Content;
        public List<Tree<T>> ListOfChildren = new List<Tree<T>>();

        public Tree<T> CreateNode(T t)
        {
            Tree<T> node = new Tree<T>()
            {
                Content = t
            };

            return node;
        }

        public void AppendChild(Tree<T> t)
        {
            ListOfChildren.Add(t);
        }

        public void RemoveChild(Tree<T> t)
        {
            ListOfChildren.Remove(t);
        }

        public void PrintTree(String placeholder = "")
        {
            Console.WriteLine(placeholder + Content);
            foreach (Tree<T> child in ListOfChildren)
                child.PrintTree(placeholder + "*");
        }

        public List<Tree<T>> FindNode(T searchNode)
        {
            return (ListOfChildren.FindAll(x => x.Content.Equals(searchNode)));
        }

        public void PrintSearch(List<Tree<T>> input)
        {
            foreach (var c in input)
            {
                gefunden = true;
                int k = 1;
                Console.WriteLine("Gesuchte Node: " + c.Content + " Vorkommen: " + k);
                k++;
            }
            if (gefunden == false)
            {
                Console.WriteLine ("Gesuchte Node nicht gefunden");
            }
            gefunden = false;
        }
    }

}
