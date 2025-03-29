// See https://aka.ms/new-console-template for more information


using System.Collections.Generic;
using System.Transactions;
using CheckList;

class Program
{
    private static List<CheckListItem> list = new List<CheckListItem>();
    private const string COMMAND_LIST_ITEMS = "list";
    private const string COMMAND_ADD_ITEM = "add";

    static void Main()
    {
        Console.WriteLine("Add new task?");
        var arg = Console.ReadLine();
        if (arg == COMMAND_LIST_ITEMS)
        {
            ListAllItems();
        }
        else if (arg == COMMAND_ADD_ITEM)
        {
            AddItem();
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
                else if (arg != COMMAND_ADD_ITEM)
                {
                    newItemRequested = false;
                }
            }
        }
    }
}
