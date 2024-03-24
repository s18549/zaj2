using APBD_Zadanie3.Exception;
using System;
using System.Collections.Generic;


namespace APBD_Zadanie3.Classes;
public class RefrigeratedContainer : Container
{
    public string StoredProductType { get; private set; }
    public double MaintainedTemperature { get; private set; }

    private Dictionary<string, double> ProductTemperatureRequirements;

    public RefrigeratedContainer( int height, double ownWeight, int depth, double maxLoad, string storedProductType, double maintainedTemperature)
        : base( height, ownWeight, depth, maxLoad)
    {
        StoredProductType = storedProductType;
        MaintainedTemperature = maintainedTemperature;
        InitializeProductTemperatureRequirements();
        SerialNumber = "KON-C-" + counter++;
        if(maintainedTemperature < ProductTemperatureRequirements[storedProductType])
        {
            throw new ArgumentException("Wrong temperature for the given product type");
        }
        
    }

    private void InitializeProductTemperatureRequirements()
    {
        ProductTemperatureRequirements = new Dictionary<string, double>
        {
            { "Bananas", 13.3 },
            { "Chocolate", 18 },
            { "Fish", 2 },
            { "Meat", -15 },
            { "Ice cream", -18 },
            { "Frozen pizza", -30 },
            { "Cheese", 7.2 },
            { "Sausages", 5 },
            { "Butter", 20.5 },
            { "Eggs", 19 }
        };
    }

    public  void LoadCargo(double mass, string productType)
    {
        if (!ProductTemperatureRequirements.ContainsKey(productType))
        {
            throw new ArgumentException("Unknown product type.");
        }

        if (productType != StoredProductType )
        {
            throw new ArgumentException("Wrong product type. Can't store 2 different product types in the same container");
        }


        if (ProductTemperatureRequirements[productType] > MaintainedTemperature)
        {
            throw new InvalidOperationException($"The maintained temperature is too low for {productType}.");
        }
     
        if (mass+CargoMass > MaxLoad)
        {
            throw new OverfillException($"Attempted to overfill the container {SerialNumber}. Max load is {MaxLoad}, attempted load was {mass}.");
        }

        CargoMass += mass;
    }
    public override void LoadCargo(double mass)
    {}

    public override void UnloadCargo()
    {
        CargoMass = 0;
    }
}