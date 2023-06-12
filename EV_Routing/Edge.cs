namespace EV_Routing;

public class Edge
{
    public int Source;
    public int Target;
    public double Cost;

    public Edge(int source, int target, double cost)
    {
        Source = source;
        Target = target;
        Cost = cost;
    }
}
