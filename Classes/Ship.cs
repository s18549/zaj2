using System;
using System.Collections.Generic;
using System.Linq;


namespace APBD_Zadanie3.Classes;
public class Ship
{
    public List<Container> Containers { get; private set; }
    public int MaxSpeed { get; private set; }
    public int MaxContainerCount { get; private set; }
    public double MaxWeight { get; private set; }

    public Ship(int maxSpeed, int maxContainerCount, double maxWeight)
    {
        Containers = new List<Container>();
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxWeight = maxWeight;
    }

    public void AddContainer(Container container)
    {
        if (Containers.Count >= MaxContainerCount)
            throw new InvalidOperationException("Cannot add more containers: capacity full.");
        if (GetTotalWeight() + container.OwnWeight + container.CargoMass > MaxWeight * 1000) // MaxWeight is in tons
            throw new InvalidOperationException("Cannot add container: weight limit exceeded.");
        Containers.Add(container);
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            AddContainer(container);
        }
    }

    public bool RemoveContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Containers.Remove(container);
            return true;
        }
        return false;
    }

    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        var index = Containers.FindIndex(c => c.SerialNumber == serialNumber);
        if (index == -1)
            throw new InvalidOperationException("Container not found.");
        Containers[index] = newContainer;
    }

    public void TransferContainer(Ship otherShip, string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
            throw new InvalidOperationException("Container not found.");

        RemoveContainer(serialNumber);
        otherShip.AddContainer(container);
    }

    public double GetTotalWeight()
    {
        return Containers.Sum(c => c.OwnWeight + c.CargoMass) / 1000; // Return weight in tons
    }

    public string GetShipInfo()
    {
        return $"Ship max speed: {MaxSpeed} knots, max container count: {MaxContainerCount}, max weight: {MaxWeight} tons, current weight: {GetTotalWeight()} tons";
    }

    public string GetContainerInfo(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        return container != null ? container.ToString() : "Container not found.";
    }
}