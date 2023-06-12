namespace EV_Routing
{
    class RoutingSimulation
    {
        public static int ReadInteger(string question)
        {
            bool reading = true;
            int number = 0;
            do
            {
                Console.Write(question);
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    reading = false;
                }
                catch
                {
                    Console.WriteLine("Invalid data type");
                }
            } while (reading);

            return number;
        }

        private static Tuple<int, int> GetTravelDetails(Map map)
        {
            Console.WriteLine("Travel Details: ");
            map.DisplayAllLocations();
            Console.WriteLine();
            int currentLocation = ReadInteger("  Starting location: ");
            int destination = ReadInteger("  Destination: ");
            Console.WriteLine();

            return new Tuple<int, int>(currentLocation, destination);
        }
        
        static void Main(string[] args)
        {
            Map map = new Map();
            var (currentLocation, destination) = GetTravelDetails(map);
            double distanceTwoNodes = map.Distance(currentLocation, destination);
            
            Car car = new Car(100, 651.74, 250);
            double currentBatteryLevel = 100;
            double distanceTravelled = 0;
            CarSimulation simulation = new CarSimulation(car, currentBatteryLevel, distanceTravelled);
            
            double consumption = simulation._car.EstimatedConsumption(distanceTwoNodes);
            if (consumption < currentBatteryLevel)
            {
                simulation.Drive(distanceTwoNodes);
                Console.WriteLine("Current Battery Level: {0:F3} kWh", currentBatteryLevel);
                Console.WriteLine("Estimated Battery Level after the travel: {0:F3} kWh", simulation.GetCurrentBatteryLevel());
                
                Console.WriteLine();
                Console.WriteLine("Here is the route: ");
                map.DisplayRoute(currentLocation, destination);
            }
            else
            {
                Console.WriteLine("Unfortunately your car does not have the required {0:F3} kWh in your battery", consumption);
            }
        }
    }
}