namespace EV_Routing;

public class Car
{
    private double _batteryCapacity; // in kWh
    private double _range;
    public double _batteryConsumptionPerKilometer;
    private double _totalCarWeight;

    public Car(double batteryCapacity, double range, double totalCarWeight)
    {
        _batteryCapacity = batteryCapacity;
        _range = range;

        _batteryConsumptionPerKilometer = _batteryCapacity / _range;
        _totalCarWeight = totalCarWeight;
    }

    public void GetCarInformation()
    {
        // Prints the car specifications
    }

    public double EstimatedConsumption(double distance) // distance has to be km
    {
        return distance * _batteryConsumptionPerKilometer;
    }
    
    public double GetCarRange()
    {
        return _range;
    }

    private double Force(double acceleration)
    {
        double force = acceleration * _totalCarWeight;
        return force;
    }

    public double GainedEnergy(double distanceTravelled, double velocity, double time, double electromagneticForce, double measuredVoltage)
    {
        double stoppingWork = -electromagneticForce * distanceTravelled + KineticEnergy(velocity);
        double gainedEnergy = stoppingWork / (measuredVoltage * (time * 3600 * 3.6 * Math.Pow(10, 6))); // this is in kj to now kWh
        return gainedEnergy;
    }


    public double WorkDone(double distanceTravelled, double acceleration)
    {
        double work = Force(acceleration) * distanceTravelled;
        return work;
    }

    public double KineticEnergy(double finalVelocity)
    {
        double kinecticEnergy = (_totalCarWeight * Math.Pow(finalVelocity, 2)) / 2;
        return kinecticEnergy;
    }
}