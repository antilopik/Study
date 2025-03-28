namespace Project;

class Calculator
{
    static void Main()
    {
        var firstNumber = GetNumberFromConsole("number");
        var secondNumber = GetNumberFromConsole("second number");
        var operation = GetOperationFromConsole(out var operatorasstring);
        float result = 0f;
        switch (operation)
        {
            case ArifmeticOperator.Plus:
              result = firstNumber + secondNumber;
                break;
            case ArifmeticOperator.Minus:
                result = firstNumber - secondNumber;
                break;
            case ArifmeticOperator.Multiply:
                result = firstNumber * secondNumber;
                break;
            case ArifmeticOperator.Divide:
                result = firstNumber / secondNumber;
                break;
        }
        Console.WriteLine($"{firstNumber} {operatorasstring} {secondNumber} = {result}"); 
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

    private static ArifmeticOperator GetOperationFromConsole(out string action)
    {
        var operatorIsParsed = false;
        while (!operatorIsParsed)
        {
            Console.WriteLine("please enter operator");
            action = Console.ReadLine();
            if (action == "+")
            {
                operatorIsParsed = true;
                return ArifmeticOperator.Plus;  
            }
            else if (action == "-")
            {
                operatorIsParsed = true;
                return ArifmeticOperator.Minus;   
            }
            else if (action == "*")
            {
                operatorIsParsed = true;
                return ArifmeticOperator.Multiply;
            }
            else if (action == "/")
            {
                operatorIsParsed = true;
                return ArifmeticOperator.Divide;    
            }
            else
            {
                operatorIsParsed = false;
                Console.WriteLine("Invalid operator. Please enter a valid operator (+, -, *, /)");
            }
        }
        throw new Exception("This should never happen");
    }
}