namespace Namespace.BF;

public class Node
{
    public char Value;
    public List<Node> Children = [];
}

public class BFS
{
    public void BFSIterative(Node root)
    {
        var queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            Console.WriteLine(node.Value);

            foreach (var child in node.Children)
            {
                queue.Enqueue(child);
            }
        }
    }
}


//      A
//     / \
//    B   C
//   / \
//  D   E


