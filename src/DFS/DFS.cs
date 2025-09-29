using static System.Formats.Asn1.AsnWriter;

namespace Namespace;
/*
    DFS(node) :
        process(node)
        for each child of node:
            DFS(child)
*/
public class Node
{
    public char Value;
    public List<Node> Children = [];
}
public class DFS
{
    public void DFSRecursive(Node node)
    {
        if (node == null) return;
        //Console.WriteLine("Enter " + node.Value);
        Console.WriteLine(node.Value); // * printing before the loop
        // 2. Visit each child in order
        foreach (var child in node.Children)
        {
            DFSRecursive(child);
        }
        //Console.WriteLine("Exit " + node.Value);
    }
}

//      A
//     / \
//    B   C
//   / \
//  D   E


public class DFSManual
{
    public void stackPushPopTestIterative()
    {
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        var stackSize = stack.Count;
        for (var i = 0; i < stackSize; i++)
        {
            var currentPopItem = stack.Pop();
            Console.WriteLine(currentPopItem);
        }

        //while (stack.Count > 0)
        //{
        //    var node = stack.Pop();
        //    Console.WriteLine(node);
        //}
    }

    public void DFSIterative(Node root)
    {
        var stack = new Stack<Node>();
        stack.Push(root);

        //for (; stack.Count > 0;)
        //{
        //    var currentRemoved = stack.Pop();
        //    Console.WriteLine(currentRemoved.Value);

        //    // Push children in reverse order
        //    for (int i = currentRemoved.Children.Count - 1; i >= 0; i--)
        //    {
        //        stack.Push(currentRemoved.Children[i]);
        //    }
        //}

        while (stack.Count > 0)
        {
            var node = stack.Pop();
            Console.WriteLine(node.Value);

            // Push right → then left (so left is visited first)
            for (int i = node.Children.Count - 1; i >= 0; i--)
                stack.Push(node.Children[i]);
        }
    }
}
