
using SurfaceAreaCalculator.Figures;

var dictionary = new Dictionary<string, IFigure>()
{
    { "square", new Square() },
    { "rectangle", new Rectangle() },
    { "circle", new Circle() },
    { "triangle", new Triangle() },
};

var nextCicle = true;
while (nextCicle) 
{
    Console.WriteLine("Please enter your item:square,rectangle,circle,triangle.");
    var item = string.Empty;
    item = Console.ReadLine();
    if (dictionary.TryGetValue(item, out var figure))
    {
        figure.GetParamaetersOfFigureFromUser();
        figure.CalculateArea();
    }
    else
    {
        Console.WriteLine("Please enter a valid item.");
    }
    Console.WriteLine("Do you want to continue? yes or no");
    string answer = Console.ReadLine();
    if (answer != "yes")
    {
        nextCicle = false;
        Console.WriteLine("Goodbye!");
    }
}