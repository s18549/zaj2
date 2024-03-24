using APBD_Zadanie3.Interfaces;
using APBD_Zadanie3.Exception;

namespace APBD_Zadanie3.Classes;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; private set; }

    public LiquidContainer( int height, double ownWeight, int depth,  double maxLoad, bool isHazardous)
        : base( height, ownWeight, depth,  maxLoad )
    {
        IsHazardous = isHazardous;
        SerialNumber = "KON-L-" + counter++;

    }

    public override void LoadCargo(double mass)
    {
        double maxAllowedLoad = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;
        if (mass+CargoMass > maxAllowedLoad) {
        
            throw new OverfillException($"Attempted to overfill the container {SerialNumber}. Max load is {MaxLoad}, attempted load was {mass}.");
        }
        CargoMass += mass;
    }

    public override void UnloadCargo()
    {
        CargoMass = 0;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard notification for {SerialNumber}: {message}");
    }
}
