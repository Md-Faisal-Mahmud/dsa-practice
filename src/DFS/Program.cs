//using DFSBFS.TreeBuilding;
//using Namespace;
////      A
////     / \
////    B   C
////   / \
////  D   E

//var A = new Node { Value = 'A' };
//var B = new Node { Value = 'B' };
//var C = new Node { Value = 'C' };
//var D = new Node { Value = 'D' };
//var E = new Node { Value = 'E' };

//A.Children.Add(B);
//A.Children.Add(C);
//B.Children.Add(D);
//B.Children.Add(E);

//var dfs = new DFS();
//dfs.DFSRecursive(A);

// bfs

#region Tree Building with recursion from adjacent List
using DFSBFS.TreeBuilding;
var nodes = new List<TreeNode>
{
    new TreeNode { Id = 1, ParentId = null, Value = 'A' },
    new TreeNode { Id = 2, ParentId = 1, Value = 'B' },
    new TreeNode { Id = 3, ParentId = 1, Value = 'C' },
    new TreeNode { Id = 4, ParentId = 2, Value = 'D' },
    new TreeNode { Id = 5, ParentId = 2, Value = 'E' },
};

//var nodes = new List<TreeNode>
//{
//    new TreeNode { Id = 1, ParentId = null, Value = 'A' },
//    new TreeNode { Id = 2, ParentId = 1, Value = 'B' },
//    new TreeNode { Id = 3, ParentId = 1, Value = 'C' },
//    new TreeNode { Id = 4, ParentId = null, Value = 'D' },
//    new TreeNode { Id = 5, ParentId = 4, Value = 'E' },
//};

var builder = new TreeBuilder();
//var roots = builder.BuildTree(nodes);  // returns a list of root(s)
var forestV2 = builder.ForestV2(nodes);

Console.WriteLine(forestV2);
//// Print tree
//void Print(TreeNode node, string indent = "")
//{
//    Console.WriteLine(indent + node.Value);
//    foreach (var child in node.Children)
//    {
//        Print(child, indent + "  ");
//    }
//}

//foreach (var root in roots)
//{
//    Print(root);
//}
#endregion
