using System;
using System.Threading;

public class TreeNode
{
    public int Value;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int value)
    {
        Value = value;
    }
}

public class ThreadSafeBinaryTree
{
    private TreeNode root = null;
    private object treeLock = new object();

    public void Insert(int value)
    {
        lock (treeLock)
        {
            root = InsertNode(root, value);
        }
    }

    private TreeNode InsertNode(TreeNode node, int value)
    {
        if (node == null)
            return new TreeNode(value);

        if (value < node.Value)
            node.Left = InsertNode(node.Left, value);
        else if (value > node.Value)
            node.Right = InsertNode(node.Right, value);

        return node;
    }

    public bool Contains(int value)
    {
        lock (treeLock)
        {
            TreeNode current = root;
            while (current != null)
            {
                if (value == current.Value)
                    return true;
                else if (value < current.Value)
                    current = current.Left;
                else
                    current = current.Right;
            }
            return false;
        }
    }

    public void Print()
    {
        lock (treeLock)
        {
            PrintReq(root);
        }
    }

    private void PrintReq(TreeNode node)
    {
        if (node == null) return;

        PrintReq(node.Left);
        Console.WriteLine(node.Value);
        PrintReq(node.Right);
    }
}

class Program
{
    static void Main()
    {
        ThreadSafeBinaryTree tree = new ThreadSafeBinaryTree();

        Thread t1 = new Thread(() =>
        {
            for (int i = 1; i <= 9; i += 2)
                tree.Insert(i);
        });


        Thread t2 = new Thread(() =>
        {
            for (int i = 2; i <= 10; i += 2)
                tree.Insert(i);
        });
  
        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine("Tree in-order:");
        tree.Print();

        Console.WriteLine("Is 5 in the tree? " + (tree.Contains(5) ? "Yes" : "No"));
        Console.WriteLine("Is 11 in the tree? " + (tree.Contains(11) ? "Yes" : "No"));
    }
}
