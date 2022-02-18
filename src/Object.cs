public class Object
{
    public string Name;
    public float AverageNumber = 0;
    public int SampleSize = 1;
    public static List<Object> Objects = new List<Object>();

    public Object(string name)
    {
        Name = name;

        Objects.Add(this);
    }

    public static Object? Find(string name)
    {
        return Objects.Find(obj => obj.Name == name);
    }

}