public class Node
{
    public enum NodeType
    {
        Input,
        Output,
        Hidden
    }

    public int Id;
    public double Bias = 0.0;
    public string Owner;

    public NodeType Type;
    public List<int> Relationships = new List<int>();

    public Node(string obj, NodeType type)
    {
        Type = type;
        Id = Innovation_Node.Innovate(obj, null);
        Owner = obj;
    }

    public Node(ref Object obj, Link link)
    {
        Type = NodeType.Hidden;
        Owner = obj.Name;
        Id = Innovation_Node.Innovate(obj.Name, link.Id);
    }
}