﻿using System;
using System.Collections.Generic;

namespace Aufgabe_4
{
    public class Tree<T>
    {
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<String>();
            var root = tree.CreateNode("root");
            var child1 = tree.CreateNode("child1");
            var child2 = tree.CreateNode("child1");
            root.AppendChild(child1);
            root.AppendChild(child2);
            var grand11 = tree.CreateNode("grand11");
            var grand12 = tree.CreateNode("grand12");
            var grand13 = tree.CreateNode("grand13");
            child1.AppendChild(grand11);
            child1.AppendChild(grand12);
            child1.AppendChild(grand13);
            var grand21 = tree.CreateNode("grand21");
            child2.AppendChild(grand21);
            child1.RemoveChild(grand12);

            root.PrintTree();
        }
    }
}
