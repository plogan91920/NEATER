public class Link
{
    public int Id;
    public int Start;
    public int End;
    public float Weight = 1;
    public bool Enabled = true;

    Link(Node start,  Node end)
    {
        Start = start.Id;
        End = end.Id;
        Id = Innovation_Link.Innovate(start.Id, end.Id);
    }

    public int GetCardinality()
    {
        return Innovation_Link.GetCardinality(Id);
    }
}