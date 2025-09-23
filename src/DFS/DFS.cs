namespace Namespace;

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

        // 1. Visit the current node
        Console.WriteLine(node.Value); // * printing before the loop

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


//public class DFS
//{
//    public void DFSStack(Node root)
//    {
//        var stack = new Stack<Node>();
//        stack.Push(root);

//        while (stack.Count > 0)
//        {
//            var node = stack.Pop();
//            Console.WriteLine(node.Value);

//            // Push children in reverse order to visit left first
//            for (int i = node.Children.Count - 1; i >= 0; i--)
//                stack.Push(node.Children[i]);
//        }
//    }
//}
