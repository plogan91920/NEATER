public static class Mutator
{
    public static void Mutate(ref Genome genome)
    {

    }

    static void AddNode(ref Genome genome)
    {
        //Normal NEAT mutation with 2 changes:
        //First new nodes may typically be in either the start or end nodes Object.
        //Secondly, rarely, the node may be in an Object Related to one of those Objects instead.
    }

    static void AddLink(ref Genome genome)
    {
        //Normal NEAT mutation
    }

    static void ShiftWeight(ref Link link)
    {
        
    }

    static void ScrambleWeight(ref Link link)
    {

    }
}