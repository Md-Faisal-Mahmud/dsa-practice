namespace DFSBFS.TreeBuilding;

public class TreeBuilder
{
    #region BFS ---------
    #region Tree
    public TreeNode BuildTreeBFS(TreeNode root, List<TreeNode> nodes) // iterative way
    {
        // Fast lookup: ParentId -> children
        var lookup = nodes.ToLookup(n => n.ParentId);

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            var children = lookup[current.Id].ToList();
            current.Children = children;

            foreach (var child in children)
                queue.Enqueue(child);
        }

        return root;
    }
    #endregion

    #region Forest
    public List<TreeNode> BuildForestIterative(List<TreeNode> nodes)
    {
        // 1. Group by ParentId for fast lookup
        var lookup = nodes.ToLookup(n => n.ParentId);

        // 2. Assign children iteratively
        foreach (var node in nodes)
        {
            node.Children = lookup[node.Id].ToList();
        }

        // 3. Roots are those with no ParentId
        var roots = lookup[null].ToList();

        return roots;
    }
    #endregion
    #endregion

    #region DFS ---------
    #region Tree
    public TreeNode BuildTreeIterativeDFS(TreeNode root, List<TreeNode> nodes) // iterative way
    {
        var lookup = nodes.ToLookup(n => n.ParentId);

        var stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            var children = lookup[current.Id].ToList();
            current.Children = children;

            // push children in reverse to keep left-to-right order
            for (int i = children.Count - 1; i >= 0; i--)
                stack.Push(children[i]);
        }

        return root;
    }
    #endregion

    #region Forest
    public List<TreeNode> BuildTree(List<TreeNode> nodes, int? parentId = null)
    {
        var roots = nodes.Where(n => n.ParentId == parentId).ToList();

        foreach (var root in roots)
        {
            var children = BuildTree(nodes, root.Id); // recursive
            foreach (var child in children)
            {
                root.Children.Add(child);
            }
        }

        return roots; // return all roots (forest)
    }

    public List<TreeNode> ForestV2(List<TreeNode> lists)
    {
        // 1. Find all root nodes (ParentId == null)
        var roots = lists.Where(n => n.ParentId == null).ToList();

        // 2. For each root, build its subtree
        foreach (var root in roots)
        {
            BuildTree_V2(root);
        }

        // 3. Recursive local function
        void BuildTree_V2(TreeNode node)
        {
            var children = lists.Where(n => n.ParentId == node.Id).ToList();
            foreach (var child in children)
            {
                BuildTree_V2(child);       // fill child.Children
                node.Children.Add(child); // ✅ attach the actual child
            }
        }

        // 4. Return all roots (forest)
        return roots;
    }
    #endregion
    #endregion
}

