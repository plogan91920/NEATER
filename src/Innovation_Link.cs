public class Innovation_Link
{
    static List<Innovation_Link> Innovation_Links = new List<Innovation_Link>();

    int Start;
    int End;
    int Cardinality = 1;

    Innovation_Link(int start, int end)
    {
        Start = start;
        End = end;
    }

    public static int Innovate(int start, int end)
    {
        int foundLink = Innovation_Links.FindIndex(IL => (IL.Start == start && IL.End == end));
        if (foundLink >= 0)
        {
            return foundLink;
        }

        Innovation_Link newLink = new Innovation_Link(start, end);
        Innovation_Links.Add(newLink);

        return Innovation_Links.Count - 1;
    }

    public static int GetCardinality(int id)
    {
        return Innovation_Links[id].Cardinality;
    }
}