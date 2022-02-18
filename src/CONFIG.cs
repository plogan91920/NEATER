public static class CONFIG
{
    public static int POPULATION_SIZE = 150;

    //Speciation
    public static double C1 = 1.0;
    public static double C2 = 1.0;
    public static double C3 = 0.4;
    public static double DT = 3.0;

    //Breeding
    public static int STAGNATION_TIME = 15;
    public static double INHERIT_DISABLED = 0.75;
    public static double MUTATION_ONLY_SIZE = 0.25;
    public static double INTERSPECIES_MATING_CHANCE = 0.001;

    //Mutations
    public static double WEIGHT_SHIFT_CHANCE = 0.8;
    public static double WEIGHT_SHIFT_AMOUNT = 0.01;
    public static double WEIGHT_SCRAMBLE_CHANCE = 0.1;
    public static double ADD_NODE_CHANCE = 0.03;
    public static double ADD_LINK_CHANCE = 0.05;

    //NEATER
    public static double NODE_START_CHANCE = 0.5;
    public static double NODE_DRIFT_CHANCE = 0.001;
    public static double LINK_DRIFT_CHANCE = 0.005;
    public static int MAX_LINK_DISTANCE = 6;
}