using System.Text;

namespace EV_Routing;

public class Map
{
    private Dictionary<int, string> _locations = new Dictionary<int, string>()
    {
        { 0, "Home" },
        { 1, "Deakin University" },
        { 2, "Glen Waverley Train Station" },
        { 3, "Knox Shopping Centre" },
        { 4, "Monash University" },
        { 5, "University of Melbourne" },
        { 6, "Smith's Beach" }
    };

    public double[][] _connectingPlacesOfInterests = new double[][]
    {
        new double[] { 0, 14.2, -1, 3.4, 11.9, -1, 111 },
        new double[] { 14.2, 0, 7.4, -1, -1, 20.8, -1 },
        new double[] { -1, 7.4, 0, 8.3, -1, 29.5, 114 },
        new double[] { 3.4, -1, 8.3, 0, 15.9, 33.2, 114 },
        new double[] { 11.9, -1, -1, 15.9, 0, -1, 113 },
        new double[] { -1, 20.8, 29.5, 33.2, -1, 0, 145 },
        new double[] { 111, -1, 114, 114, 113, 145, 0 }
    };

    private Graph _graph;
    private Routing _routing;

    public Map()
    {
        _graph = new Graph(_connectingPlacesOfInterests);
        _routing = new Routing(_graph);
    }

    public double Distance(int source, int target)
    {
        var path = _routing.SearchRoute(source, target);
        return path.Sum(edge => edge.Cost);
    }


    public void DisplayRoute(int source, int target)
    {
        Console.WriteLine("Route:");
        var path = _routing.SearchRoute(source, target);
        foreach (var edge in path)
        {
            var sourceLocation = _locations[edge.Source];
            var targetLocation = _locations[edge.Target];
            Console.WriteLine($"  {sourceLocation} -> {targetLocation}: {edge.Cost}Km");
        }
    }

    public void DisplayAllLocations()
    {
        Console.WriteLine("Locations:");
        foreach (var kv in _locations)
        {
            int key = kv.Key;
            string location = kv.Value;
            Console.WriteLine($"  {key}: {location}");
        }
    }
}