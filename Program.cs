using APBD_Zadanie3.Classes;
using System;
using System.Collections.Generic;

namespace APBD_Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tworzenie kontenera danego typu
            GasContainer gasContainer = new GasContainer(10, 1000, 5, 5000, 2.5);

            // Załadowanie ładunku do danego kontenera
            try
            {
                gasContainer.LoadCargo(2000);
            }
            catch (OverfillException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Tworzenie statku
            Ship ship = new Ship();

            // Załadowanie kontenera na statek
            try
            {
                ship.LoadContainer(gasContainer);
            }
            catch (OverfillException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Załadowanie listy kontenerów na statek
            List<Container> containers = new List<Container>();
            containers.Add(new LiquidContainer(10, 2000, 6, 8000, true));
            containers.Add(new RefrigeratedContainer(12, 1500, 6, 7000, "Fish", 0));
            containers.Add(new LiquidContainer(8, 1800, 4, 6000, false));

            try
            {
                ship.LoadContainers(containers);
            }
            catch (OverfillException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Usunięcie kontenera ze statku
            ship.UnloadContainer(gasContainer);

            // Rozładowanie kontenera
            gasContainer.UnloadCargo();

            // Zastąpienie kontenera na statku o danym numerze innym kontenerem
            LiquidContainer newLiquidContainer = new LiquidContainer(9, 1500, 5, 7000, true);
            ship.ReplaceContainer("KON-G-0", newLiquidContainer);

            // Możliwość przeniesienia kontenera między dwoma statkami
            Ship anotherShip = new Ship();
            ship.TransferContainer("KON-L-0", anotherShip);

            // Wypisanie informacji o danym kontenerze
            Console.WriteLine("Information about gas container:");
            Console.WriteLine($"Serial number: {gasContainer.SerialNumber}");
            Console.WriteLine($"Pressure: {gasContainer.Pressure}");

            // Wypisanie informacji o danym statku i jego ładunku
            Console.WriteLine("\nInformation about ship:");
            Console.WriteLine($"Ship ID: {ship.ShipId}");
            Console.WriteLine("Containers on the ship:");
            foreach (var container in ship.Containers)
            {
                Console.WriteLine($"Serial number: {container.SerialNumber}, Cargo mass: {container.CargoMass}");
            }
        }
    }
}
