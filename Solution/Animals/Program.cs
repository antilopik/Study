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
    { "wolf", typeof(Wolf) }
};

Type currentCargoType = GetFirstEnityTypeToCarry(cargosDictionary);
MakeTransportation(from, to, currentCargoType);
CheckLooseConditions(to, from);

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

    if (list.Count == 2)
    {
        if (list[0].CanEat(list[1]))
        {
            Console.WriteLine($"{list[0]} has eaten {list[1]}");
            return GameState.Lost;
        }
        else if (list[1].CanEat(list[0]))
        {
            Console.WriteLine($"{list[1]} has eaten {list[0]}");
            return GameState.Lost;
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

static Type GetFirstEnityTypeToCarry(Dictionary<string, Type> cargosDictionary)
{
    Type currentCargoType = null;
    while (currentCargoType == null)
    {
        Console.WriteLine("Enter first cargo");
        var firstCargo = Console.ReadLine();
        TryParseCargo(firstCargo, cargosDictionary, out currentCargoType);
    }

    return currentCargoType;
}