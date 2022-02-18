public class Innovation_Node
{
    static List<Innovation_Node> Innovation_Nodes = new List<Innovation_Node>();

    int? Link;
    string Object;

    Innovation_Node(string obj, int? link)
    {
        Link = link;
        Object = obj;

        Innovation_Nodes.Add(this);
    }

    public static int Innovate(string obj, int? link)
    {
        int foundLink = Innovation_Nodes.FindIndex(IN => (IN.Link == link && IN.Object == obj));
        if (foundLink >= 0)
        {
            return foundLink;
        }

        new Innovation_Node(obj, link);

        return Innovation_Nodes.Count - 1;
    }
}