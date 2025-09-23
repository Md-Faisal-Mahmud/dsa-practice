namespace DFSBFS.TreeBuilding;

public class TreeBuilder
{
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
            BuildTreeV2(root);
        }

        // 3. Recursive local function
        void BuildTreeV2(TreeNode node)
        {
            var children = lists.Where(n => n.ParentId == node.Id).ToList();

            foreach (var child in children)
            {
                BuildTreeV2(child);       // fill child.Children
                node.Children.Add(child); // ✅ attach the actual child
            }
        }

        // 4. Return all roots (forest)
        return roots;
    }

}

