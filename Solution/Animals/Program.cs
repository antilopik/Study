using Animals.Models;
// declare variables to store entities for both sides of the river
var from = new List<BioEntity> { new Cabbage(), new Sheep(), new Wolf() };
var to = new List<BioEntity>(3);
var currentBoatmanLocation = BoatManLocation.LeftSide;

// declare a mapping for user input to entity types
var cargosDictionary = new Dictionary<string, Type>
{
    { "cabbage", typeof(Cabbage) },
    { "sheep", typeof(Sheep) },
    { "wolf", typeof(Wolf) },
    { "none", typeof(Nothing) }
};


var tripNumber = 0;
bool isGameLost = false;
while (from.Count > 0 && !isGameLost)
{
    tripNumber++;
    if (currentBoatmanLocation == BoatManLocation.LeftSide)
    {
        Type currentCargoType = GetEnityTypeToCarryOrNothing(cargosDictionary, tripNumber.ToString(), from);
        currentBoatmanLocation = MakeTransportation(from, to, currentCargoType, currentBoatmanLocation);
    }
    else
    {
        Type currentCargoType = GetEnityTypeToCarryOrNothing(cargosDictionary, tripNumber.ToString(), to);
        currentBoatmanLocation = MakeTransportation(to, from, currentCargoType, currentBoatmanLocation);
    }

    isGameLost = CheckLooseConditions(to, from, currentBoatmanLocation);
}

if (!isGameLost)
{
    Console.WriteLine("You won!");
}

static bool CheckLooseConditions(List<BioEntity> to, List<BioEntity> from, BoatManLocation boatManLocation)
{
    var result = false;
    switch (boatManLocation)
    {
        case BoatManLocation.LeftSide:
            if (CheckLooseCondition(to) == GameState.Lost)
            {
                result = true;
            }
            break;
        case BoatManLocation.RightSide:
            if (CheckLooseCondition(from) == GameState.Lost)
            {
                result = true;
            }
            break;
    }

    if (result)
    {
        Console.WriteLine("You lost");
    }
    return result;
}


static BoatManLocation MakeTransportation(List<BioEntity> from, List<BioEntity> to, Type typeToCarry, BoatManLocation current)
{
    if (typeToCarry == typeof(Nothing))
    {
        return UpdateBoatManLocation(current);
    }
    else 
    {
        for (int i = 0; i < from.Count; i++)
        {
            if (from[i].GetType() == typeToCarry)
            {
                var cargo = from[i];
                from.Remove(cargo);
                to.Add(cargo);
                return UpdateBoatManLocation(current);
            }
        }
        return current;
    }
}

static BoatManLocation UpdateBoatManLocation(BoatManLocation currentBoatmanLocation)
{
    if (currentBoatmanLocation == BoatManLocation.LeftSide)
    {
        currentBoatmanLocation = BoatManLocation.RightSide;
    }
    else
    {
        currentBoatmanLocation = BoatManLocation.LeftSide;
    }
    Console.WriteLine($"Boatman is on the {currentBoatmanLocation}");
    return currentBoatmanLocation;
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