// See https://aka.ms/new-console-template for more information


using System.Transactions;
using CheckList;

var list = new List<CheckListItem>();

Console.WriteLine("Add new task?");
var arg = Console.ReadLine();
while (arg == "yes")
{
    Console.WriteLine("Enter name of task");
    var tittle = Console.ReadLine();
    var newCheckListItem = new CheckListItem(tittle);
    list.Add(newCheckListItem);
    Console.WriteLine("Add new task?");
    arg = Console.ReadLine();
}

if (arg == "list")
{
    foreach (var checkListItem in list)
    {
        Console.WriteLine(checkListItem.title);
    }
}

