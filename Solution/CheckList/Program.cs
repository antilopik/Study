// See https://aka.ms/new-console-template for more information


using System.Collections.Generic;
using System.Transactions;
using CheckList;

class Program
{
    private static List<CheckListItem> list = new List<CheckListItem>();
    private const string COMMAND_LIST_ITEMS = "list";
    private const string COMMAND_ADD_ITEM = "add";
    private const string COMMAND_MARK_ITEM = "mark";

    static void Main()
    {
        try {
            var shouldProceed = true;
            string? answer = string.Empty;
            while (shouldProceed)
            {
                if (string.IsNullOrEmpty(answer))
                {
                    Console.WriteLine("Enter command");
                    answer = Console.ReadLine();
                }
                if (answer == COMMAND_LIST_ITEMS)
                {
                    ListAllItems();
                }
                else if (answer == COMMAND_ADD_ITEM)
                {
                    AddItem();
                }
                else if (answer == COMMAND_MARK_ITEM)
                {
                    MarkCompleted();
                }
                else
                {
                    Console.WriteLine($"\"{answer}\" is not a command");
                }
                Console.WriteLine("Do you want another command");
                answer = Console.ReadLine();
                if (answer == "no")
                {
                    shouldProceed = false;
                }    
            }

        } 
        catch (Exception ex) 
        {
            throw;
        }
    }

    private static void ListAllItems()
    {
        var index = 0;
        foreach (var checkListItem in list)
        {
            Console.WriteLine($"´{index}) {checkListItem.title}, done: {checkListItem.isDone}");
            index ++;
        }
    }

    private static void AddItem() 
    {
        var newItemRequested = true;
        while (newItemRequested)
        {
            Console.WriteLine("Enter name of task");
            var arg = Console.ReadLine();
            if (arg == COMMAND_LIST_ITEMS)
            {
                ListAllItems();
            }
            else if(arg == COMMAND_MARK_ITEM)
            {
                newItemRequested = false;
                MarkCompleted();
            }
            else
            {
                var tittle = arg;
                var newCheckListItem = new CheckListItem(tittle);
                list.Add(newCheckListItem);
                Console.WriteLine("Add new task?");
                arg = Console.ReadLine();
                if (arg == COMMAND_LIST_ITEMS)
                {
                    newItemRequested = false;
                    ListAllItems();
                }
                else if (arg == COMMAND_MARK_ITEM)
                {
                    newItemRequested = false;
                    MarkCompleted();
                }
                else if (arg != COMMAND_ADD_ITEM)
                {
                    newItemRequested = false;
                }
            }
        }
    }

    private static void MarkCompleted()
    {
        int index = GetNumberFromConsole();
        while (list.Count() <= index)
        {
            Console.WriteLine($"Index \"{index}\" does not exist in the list");
            index = GetNumberFromConsole();
        }
        list.ElementAt(index).isDone = true;
    }

    private static int GetNumberFromConsole()
    {
        Console.WriteLine("Please enter an index");
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
