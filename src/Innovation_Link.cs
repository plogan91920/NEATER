public class Innovation_Link
{
    static List<Innovation_Link> Innovation_Links = new List<Innovation_Link>();

    int Start;
    int End;
    List<string> Path = new List<string>();
    int Cardinality = 1;

    Innovation_Link(int start, int end, List<string> path)
    {
        Start = start;
        End = end;
        Path = path;

        Innovation_Links.Add(this);
    }

    public static int Innovate(int start, int end, List<string> path)
    {
        int foundLink = Innovation_Links.FindIndex(IL => (IL.Start == start && IL.End == end && IL.Path == path));
        if (foundLink >= 0)
        {
            return foundLink;
        }

        new Innovation_Link(start, end, path);

        return Innovation_Links.Count - 1;
    }

    public static int GetCardinality(int id)
    {
        return Innovation_Links[id].Cardinality;
    }
}