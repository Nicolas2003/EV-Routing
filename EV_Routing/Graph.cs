namespace EV_Routing;

public class Graph
{
    private double[][] _costs;

    public Graph(double[][] costs)
    {
        _costs = costs;
    }

    public double Cost(int source, int target)
    {
        return _costs[source][target];
    }

    public List<int> Neighbours(int node)
    {
        List<int> result = new List<int>();
        if (node < _costs.Length)
        {
            for (int i = 0; i < _costs[node].Length; i++)
                if (_costs[node][i] > 0)
                    result.Add(i);
        }

        return result;
    }

    public int GetNodeLength()
    {
        return _costs.Length;
    }
    
    
}
