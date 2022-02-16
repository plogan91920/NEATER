public class Node
{
    public enum NodeType
    {
        Input,
        Output,
        Hidden
    }

    public int Id;
    public int Bias = 0;

    public NodeType Type;

    public Node( ref Object obj, NodeType type)
    {
        Type = type;
        Id = Innovation_Node.Innovate(obj.Name, null);
    }

    public Node(ref Object obj, Link link)
    {
        Type = NodeType.Hidden;
        Id = Innovation_Node.Innovate(obj.Name, link.Id);
    }
}