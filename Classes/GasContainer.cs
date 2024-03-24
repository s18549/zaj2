using APBD_Zadanie3.Exception;
using APBD_Zadanie3.Interfaces;


namespace APBD_Zadanie3.Classes;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; private set; } // Ciśnienie w atmosferach
   

    public GasContainer( int height, double ownWeight, int depth, double maxLoad, double pressure)
        : base( height, ownWeight, depth,  maxLoad)
    {
        SerialNumber = "KON-G-" + counter++;
       
        Pressure = pressure;
    }

    public override void LoadCargo(double mass)
    {
        if (mass +CargoMass > MaxLoad)
        {
            throw new OverfillException($"Attempted to overfill the gas container {SerialNumber}. Max load is {MaxLoad}, attempted load was {mass}.");
        }
        CargoMass += mass;
    }

    public override void UnloadCargo()
    {
        
        CargoMass *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        
        Console.WriteLine($"Hazard notification for container {SerialNumber}: {message}");
    }
}