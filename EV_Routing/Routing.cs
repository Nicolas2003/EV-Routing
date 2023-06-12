namespace EV_Routing;

public class Routing
{
    private Graph _graph;
    private int[] _parents;
    private double[] _costs;
    private bool[] _unprocessed;
    private int _graphSize;
    
    public Routing(Graph graph)
    {
        _graph = graph;
        _graphSize = _graph.GetNodeLength();
        _parents = new int[_graphSize];
        _costs = new double[_graphSize];
        _unprocessed = new bool[_graphSize];
        
    }

    public List<Edge> SearchRoute(int source, int target)
    {
        InitializeCosts(source);
        InitializeParents();
        InitializeUnprocessed();
        
        ;
        for (var node = source; node >= 0; node = FindLowestCostNode(_unprocessed))
        {
            var currentCost = _costs[node];
            foreach (var neighbour in _graph.Neighbours(node))
            {
                var newCost = currentCost + _graph.Cost(node, neighbour);
                if (newCost < _costs[neighbour])
                {
                    _parents[neighbour] = node;
                    _costs[neighbour] = newCost;
                }
            }
            _unprocessed[node] = false;
        }

        return GetRoute(_parents, source, target);
    }
    
    private int FindLowestCostNode(bool[] unprocessed)
    {
        double lowestCost = double.PositiveInfinity;
        int lowestCostNode = -1;

        for (int node = 0; node < _graphSize; node++)
        {
            var cost = _costs[node];
            if (unprocessed[node] && cost <= lowestCost)
            {
                lowestCost = cost;
                lowestCostNode = node;
            }
        }

        return lowestCostNode;
    }

    private List<Edge> GetRoute(int[] parents, int source, int target)
    {
        List<Edge> result = new List<Edge>();
        int node = target;
        while (node != source)
        {
            var parent = parents[node];
            result.Insert(0, new Edge(parent, node, _graph.Cost(parent, node)));
            node = parent;
        }

        return result;
    }

    private void InitializeCosts(int source)
    {
        for (int i = 0; i < _graph.GetNodeLength(); i++)
            _costs[i] = double.PositiveInfinity;
        _costs[source] = 0;
    }

    private void InitializeParents()
    {
        for (int i = 0; i < _graph.GetNodeLength(); i++)
            _parents[i] = -1;
    }

    private void InitializeUnprocessed()
    {
        for (int i = 0; i < _graph.GetNodeLength(); i++)
            _unprocessed[i] = true;
    }
}