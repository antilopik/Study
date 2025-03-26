namespace Project;

class Calculator
{
    static void Main()
    {
        var firstNumber = GetNumberFromConsole("number");
        var secondNumber = GetNumberFromConsole("second number");
        Console.WriteLine("please enter operator");
        var action = Console.ReadLine();
        if (action == "+")
        {
            Console.WriteLine("Result: " + (firstNumber + secondNumber));
        }
        else if (action == "-")
        {
            Console.WriteLine("Result: " + (firstNumber - secondNumber));
        }
        else if (action == "*")
        {
            Console.WriteLine("Result: " + (firstNumber * secondNumber));
        }
        else if (action == "/")
        {
            Console.WriteLine("Result: " + (firstNumber / secondNumber));
        }
    }

    private static int GetNumberFromConsole(string whatToAskFromUser)
    {
        Console.WriteLine($"Please enter a {whatToAskFromUser}");
        var arg = Console.ReadLine();
        int result;
        while (!int.TryParse(arg, out result)) 
        {
            Console.WriteLine($"'{arg}' is not a number! Please enter a number");
            arg = Console.ReadLine();
        }

        return result;
    }
}