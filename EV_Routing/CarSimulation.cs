namespace EV_Routing;

// Simulates the car data while it's travelling
// 651.7847
public class CarSimulation
{
    private double _currentBatteryLevel;
    private static double _distanceTravelled = 0;

    public Car _car;

    public CarSimulation(Car car, double measuredBatteryLevel, double distanceTravelled)
    {
        _car = car;
        
        _currentBatteryLevel = measuredBatteryLevel;
        _distanceTravelled = distanceTravelled;
    }

    public void Drive(double distanceToBeTravelled)
    {
        double energyConsumptionPerKilometer = _car._batteryConsumptionPerKilometer;
        
        
        
        for (int meter = 0; meter < distanceToBeTravelled * 1000; meter++)
        {
            // double conversionToKm = _distanceTravelled / 1000;
            // Console.WriteLine(conversionToKm);

            _distanceTravelled = SetDistanceTravelled(meter * 0.001);
            _currentBatteryLevel = CurrentBatteryLevel(energyConsumptionPerKilometer * 0.001);
        }
    }

    public double GetCurrentBatteryLevel()
    {
        return _currentBatteryLevel;
    }

    public double TotalDrive(double distanceTravelled, double currentBatteryLevel)
    {
        return 21.2;
    }

    public void Charging()
    {
    }
    
    
    // public double ResistanceEnergy(double energy)
    // {
    //     double batteryCapacityDifference = _currentBatteryLevel - _measuredBatteryLevel;
    //     
    //     double resistance = batteryCapacityDifference - energy;
    //     return resistance;
    // }
    
    public double CurrentBatteryLevel(double energyUsed) // energyUsed should be in kWh
    {
        return _currentBatteryLevel = _currentBatteryLevel - energyUsed;
    }
    
    // public decimal BatteryPercentage()
    // {
    //      return (decimal)(_measuredBatteryLevel / _batteryCapacity) * 100m;
    // }
    
    // public double GetMeasuredBatteryLevel()
    // {
    //     return _measuredBatteryLevel;
    // }
    
    public double GetDistanceTravelled()
    {
        return _distanceTravelled;
    }

    public double SetDistanceTravelled(double distancedTravelled)
    {
        return _distanceTravelled = distancedTravelled;
    }
}