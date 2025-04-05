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


if (from.Count == 2)
{
    if (from[0].CanEat(from[1]))
    { 
        Console.WriteLine($"{from[0]} has eaten {from[1]}");
    }
    else if (from[1].CanEat(from[0]))
    {
        Console.WriteLine($"{from[1]} has eaten {from[0]}");
    }
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

