public class Relationship
{
    public string Target;
    public float AverageCardinality = 0;
    public int SampleSize = 0;

    public Relationship(string obj)
    {
        Target = obj;
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