public static class Mutator
{
    static Random rand = new Random();
    public static void Mutate(ref Genome genome)
    {
        //Add Node
        if (rand.NextDouble() <= CONFIG.ADD_NODE_CHANCE)
            AddNode(ref genome);

        //Add Link
        if (rand.NextDouble() <= CONFIG.ADD_LINK_CHANCE)
            AddLink(genome);

        //Change Weights
        if (rand.NextDouble() <= CONFIG.WEIGHT_SHIFT_CHANCE)
            ChangeWeight(ref genome);

    }

    static void AddNode(ref Genome genome)
    {
        int linkIndex = rand.Next(genome.Links.Count);
        Link link = genome.Links[linkIndex];

        int startId = link.Start;
        Node? start = genome.Nodes.Find(node => node.Id == startId);

        int endId = link.End;
        Node? end = genome.Nodes.Find(node => node.Id == endId);

        if (start == null || end == null)
            return;//Should throw an error isntead

        //Pick Parent
        string owner;
        List<string> startPath;
        List<string> endPath;

        if (start.Owner == end.Owner)
        {
            //Internal Link being split, should just be owned by that.
            owner = start.Owner;
            startPath = new List<string>();
            endPath = new List<string>();
        }
        else
        {
            //External Link, should typically be owned by the start or end but sometimes can be something along the path between them.
            List<string> basePath = link.Path;
            if (basePath.Count >= 2 && rand.NextDouble() <= CONFIG.NODE_DRIFT_CHANCE)
            {
                int splitIndex = rand.Next(1,basePath.Count - 1);
                Relationship? split = Relationship.Find(basePath[splitIndex]);

                if (split == null)
                    return;//Should throw an error instead

                owner = split.Start;
                startPath = basePath.GetRange(0, splitIndex);
                endPath = basePath.GetRange(splitIndex, basePath.Count - splitIndex);
            }
            else
            {
                if (rand.NextDouble() < 0.5)
                {
                    owner = start.Owner;
                    startPath = new List<string>();
                    endPath = link.Path;
                }
                else
                {
                    owner = end.Owner;
                    startPath = link.Path;
                    endPath = new List<string>();
                }
            }
        }

        //Disable the original
        link.Enabled = false;

        //Create a new node with owner
        Node midNode = new Node(owner, Node.NodeType.Hidden);
        midNode.Bias = rand.NextDouble() * 2 - 1;

        //Create new links with paths
        Link inputLink = new Link(start, midNode, ref startPath);
        inputLink.Weight = link.Weight;

        Link outputLink = new Link(midNode, end, ref endPath);
        outputLink.Weight = rand.NextDouble() * 2 - 1;

        genome.Nodes.Add(midNode);
        genome.Links.Add(inputLink);
        genome.Links.Add(outputLink);
    }

    static void AddLink(Genome genome)
    {
        Node startNode = genome.Nodes[rand.Next(genome.Nodes.Count - 1)];
        string scope = startNode.Owner;

        //Occasionally connect through a relationship
        List<string> path = new List<string>();
        while (rand.NextDouble() <= CONFIG.LINK_DRIFT_CHANCE && path.Count < CONFIG.MAX_LINK_DISTANCE)
        {
            List<Relationship> potentials = Relationship.Relationships.FindAll(rel => rel.Start == scope);
            if (potentials.Count == 0)
                break;

            string nextScope = potentials[rand.Next(potentials.Count - 1)].End;
            path.Add(nextScope);
            scope = nextScope;
        }
        
        //get valid connections
        List<Node> potentialEnds = genome.Nodes.FindAll(node => (
            node.Owner == scope
        )).FindAll(node => (
            genome.Links.Find(link => link.Start == startNode.Id && link.End == node.Id) == null
        ));
        
        //randomly pick one, if any exist
        if (potentialEnds.Count == 0)
            return;

        Link link = new Link(startNode, potentialEnds[rand.Next(potentialEnds.Count - 1)], ref path);
    }

    static void ChangeWeight(ref Genome genome)
    {
        for (int i = 0; i < genome.Links.Count; i++)
        {
            if (rand.NextDouble() <= CONFIG.WEIGHT_SCRAMBLE_CHANCE)
                genome.Links[i].Weight = rand.NextDouble() * 2 - 1;
            else if (rand.NextDouble() <= 0.5)
                genome.Links[i].Weight -= CONFIG.WEIGHT_SHIFT_AMOUNT;
            else
                genome.Links[i].Weight += CONFIG.WEIGHT_SHIFT_AMOUNT;

            genome.Links[i].Weight = Math.Clamp(genome.Links[i].Weight, -1, 1);
                
        }
    }
}