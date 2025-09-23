namespace DFSBFS.TreeBuilding;

public class TreeNode
{
    public int Id { get; set; }
    public int? ParentId { get; set; }  // null means root
    public char Value { get; set; }
    public List<TreeNode> Children { get; set; } = new();
}
