
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
    dictionary.TryGetValue(item, out var figure)
    if (item == "square")
    {
        Console.WriteLine("Please enter one side lenght!");
        string x = Console.ReadLine();
        int a = Convert.ToInt32(x);
        a = a * a;
        Console.WriteLine(a);
        Console.ReadKey(); 
    }
    else if (item == "rectangle")
    {
        Console.WriteLine("Please enter two side lenghts!");
        string x = Console.ReadLine();
        string y = Console.ReadLine();
        int a = Convert.ToInt32(x);
        int b = Convert.ToInt32(y);
        a = a * b;
        Console.WriteLine(a);
        Console.ReadKey();
    }
    else if (item == "circle")
    {
        Console.WriteLine("Please enter the radius!");
        string x = Console.ReadLine();
        //double a = Convert.ToDouble(x);
        //double b = 3.14;
        //double c = a * a * b;
        //Console.WriteLine(c);
        //Console.ReadKey();
    }
    else if (item == "triangle")
    {
        Console.WriteLine("Please enter height!");
        string x = Console.ReadLine();
        Console.WriteLine("Please enter base!");
        string y = Console.ReadLine();
        int a = Convert.ToInt32(x);
        int b = Convert.ToInt32(y);
        a = a * b / 2;
        Console.WriteLine(a); 
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