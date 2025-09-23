using Namespace;
//      A
//     / \
//    B   C
//   / \
//  D   E

var A = new Node { Value = 'A' };
var B = new Node { Value = 'B' };
var C = new Node { Value = 'C' };
var D = new Node { Value = 'D' };
var E = new Node { Value = 'E' };

A.Children.Add(B);
A.Children.Add(C);
B.Children.Add(D);
B.Children.Add(E);

var dfs = new DFS();
dfs.DFSRecursive(A);