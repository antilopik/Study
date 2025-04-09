using System.Collections.Generic;
using Animals.Models;
// declare variables to store entities for both sides of the river
var from = new List<BioEntity> { new Cabbage(), new Sheep(), new Wolf() };
var to = new List<BioEntity>(3);
// declare a mapping for user input to entity types
var cargosDictionary = new Dictionary<string, Type>
{
    { "cabbage", typeof(Cabbage) },
    { "sheep", typeof(Sheep) },
    { "wolf", typeof(Wolf) },
    { "none", typeof(Nothing) }
};


var tripNumber = 0;
var tripFrom = to;
var tripTo = from;
while (from.Count > 0)
{
    tripNumber++;
    var bubber = tripFrom;
    tripFrom = tripTo;
    tripTo = bubber;
    Type currentCargoType = GetEnityTypeToCarryOrNothing(cargosDictionary, tripNumber.ToString(), tripFrom);
    if (currentCargoType != typeof(Nothing))
    {
        MakeTransportation(tripFrom, tripTo, currentCargoType);
    }
    CheckLooseConditions(tripTo, tripFrom);
}

static void CheckLooseConditions(List<BioEntity> to, List<BioEntity> from)
{
    if (CheckLooseCondition(to) == GameState.Lost || CheckLooseCondition(from) == GameState.Lost)
    {
        Console.WriteLine("You lost");
        return;
    }
}


static void MakeTransportation(List<BioEntity> from, List<BioEntity> to, Type typeToCarry)
{
    for (int i = 0; i < from.Count; i++)
    {
        if (from[i].GetType() == typeToCarry)
        {
            var cargo = from[i];
            from.Remove(cargo);
            to.Add(cargo);
        }
    }
}

static GameState CheckLooseCondition(List<BioEntity> list)
{
    for (int i = 0; i < list.Count; i++)
    {
        BioEntity current = list[i];
        for (int j = i + 1; j < list.Count; j++)
        {
            if (current.CanEat(list[j]))
            {
                Console.WriteLine($"{current} has eaten {list[j]}");
                return GameState.Lost;
            }
            else if (list[j].CanEat(current))
            {
                Console.WriteLine($"{list[j]} has eaten {current}");
                return GameState.Lost;
            }
        }
    }

    return GameState.Continue;
}


static bool TryParseCargo(string cargo, Dictionary<string, Type> cargosDictionary, out Type? typeOfCargo)
{
    typeOfCargo = null;
    if (cargosDictionary.TryGetValue(cargo.ToLower(), out var type))
    {
        typeOfCargo = type;
    }

    return typeOfCargo != null;
}

static Type GetEnityTypeToCarryOrNothing(Dictionary<string, Type> cargosDictionary, string cargoIndex, List<BioEntity> currentShore)
{
    Type currentCargoType = null;
    while (currentCargoType == null)
    {
        Console.WriteLine($"Enter {cargoIndex} cargo");
        var firstCargo = Console.ReadLine();
        TryParseCargo(firstCargo, cargosDictionary, out currentCargoType);
        if (currentCargoType != typeof(Nothing) && currentShore.All(x => x.GetType() != currentCargoType))
        {
            Console.WriteLine($"Cargo with type {currentCargoType} does not exists on the current shore");
            currentCargoType = null;
        }
    }
    return currentCargoType;
}