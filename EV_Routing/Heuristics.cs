namespace EV_Routing;

public class Heuristics
{
    private List<Tuple<double, double>> _recordedData = new List<Tuple<double, double>>();
    private void RecordingData(double distanceTravelled, double measuredBatteryLevel)
    {
        Tuple<double, double> recordingData = new Tuple<double, double>(distanceTravelled, measuredBatteryLevel);
        _recordedData.Add(recordingData);
    }
    
    
    
}