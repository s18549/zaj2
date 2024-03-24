
using APBD_Zadanie3.Exception;
namespace APBD_Zadanie3.Classes;


public abstract class Container
{
    public double CargoMass { get; protected set; }
    public int Height { get; private set; }
    public double OwnWeight { get; private set; }
    public int Depth { get; set; }
    public String SerialNumber { get;  set; }
    public double MaxLoad { get; private set; }

    public static int counter = 0;

    protected Container( int height, double ownWeight, int depth, double maxLoad)
    {
        
        Height = height;
        OwnWeight = ownWeight;
        Depth = depth;
        MaxLoad = maxLoad;

        
    }

    public abstract void LoadCargo(double mass);
    public abstract void UnloadCargo();
}

