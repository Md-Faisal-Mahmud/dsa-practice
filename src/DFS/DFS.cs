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

        //Console.WriteLine(node.Value); // * printing before the loop
        // 2. Visit each child in order
        foreach (var child in node.Children)
        {
            DFSRecursive(child);
        }
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

        for (int i = 0; i < stack.Count; i++)
        {
            var node = stack.Pop();
            Console.WriteLine(node.Value);

            // Push right → then left (so left is visited first)
            for (int j = node.Children.Count - 1; j >= 0; j--)
                stack.Push(node.Children[j]);
        }

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
