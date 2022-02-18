public class Link
{
    public int Id;
    public int Start;
    public int End;
    public double Weight = 1;
    public bool Enabled = true;
    public List<string> Path = new List<string>();

    public Link(Node start,  Node end, ref List<string> path)
    {
        Start = start.Id;
        End = end.Id;
        Path = path;
        Id = Innovation_Link.Innovate(start.Id, end.Id, path);
    }

    public int GetCardinality()
    {
        return Innovation_Link.GetCardinality(Id);
    }
}