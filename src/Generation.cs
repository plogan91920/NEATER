public class Generation
{
    static int Count = 0;
    public int Id;
    public List<Genome> genomes = new List<Genome>();
    public List<Species> species = new List<Species>();

    //Might want to keep results here as well? hard to say.
    Generation()
    {
        Id = Count++;
    }
}