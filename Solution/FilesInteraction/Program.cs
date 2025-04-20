// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter a line:");

const string fileName = "text.txt";
if(!File.Exists(fileName))
{
    var stream = File.Create(fileName);
    stream.Dispose();
}

var exit = false;
while (!exit)
{
    var input = Console.ReadLine();
    File.AppendAllLines(fileName, new string[] { input });
    Console.WriteLine("Add more?");
    exit = Console.ReadLine() != "yes";
}
