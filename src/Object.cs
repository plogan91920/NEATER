public class Object
{
    public string Name;
    public List<Relationship> Relationships = new List<Relationship>();
    public float AverageNumber = 0;
    public int SampleSize = 1;

    public Object(string name)
    {
        Name = name;
    }

    void AddReference(Object obj)
    {
        Relationships.Add(new Relationship(obj.Name));
    }

}