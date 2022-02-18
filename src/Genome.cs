public class Genome
{
    public List<Link> Links = new List<Link>();
    public List<Node> Nodes = new List<Node>();
    
    public void Phenotype()
    {
        //This will return the Phenotype of this organism for use.
    }

    public float GetCost()
    {
        return 0.0f;
    }
}