using System.Collections.Generic;
using Animals.Models;

var from = new List<BioEntity> { new Cabbage(), new Sheep(), new Wolf() };
var to = new List<BioEntity>(3);

var cargosDictionary = new Dictionary<string, Type>
{
    { "Cabbage", typeof(Cabbage) },
    { "Sheep", typeof(Sheep) },
    { "Wolf", typeof(Wolf) }
};

Type currentCargoType = null;
while (currentCargoType == null)
{
    Console.WriteLine("Enter first cargo");
    var firstCargo = Console.ReadLine();
    TryParseCargo(firstCargo, cargosDictionary, out currentCargoType);
}

for (int i = 0; i < from.Count; i++)
{
    if (from[i].GetType() == currentCargoType)
    {
        var cargo = from[i];
        from.Remove(cargo);
        to.Add(cargo);
    }
}

if (CheckLooseCondition(to) == GameState.Lost || CheckLooseCondition(from) == GameState.Lost)
{
    Console.WriteLine("You lost");
    return;
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
    if (cargosDictionary.TryGetValue(cargo, out var type))
    {
        typeOfCargo = type;
    }

    return typeOfCargo != null;
}

