public class Relationship
{
    public string Name;
    public string Start;
    public string End;
    public float AverageCardinality = 0;
    public int SampleSize = 0;
    public static List<Relationship> Relationships = new List<Relationship>();

    public Relationship(string name, string start, string end)
    {
        Name = name;
        Start = start;
        End = end;

        Relationships.Add(this);
    }

    public static Relationship? Find(string name)
    {
        return Relationships.Find(obj => obj.Name == name);
    }

    //Keeps tabs on the average number of connections made to accurately cost the connection.
    public void UpdateCardinality(int number)
    {
        AverageCardinality = (AverageCardinality * SampleSize++ + number) / SampleSize;

        //Cap sample at the last X runs
        if (SampleSize > 1000)
            SampleSize = 1000;
    }
}