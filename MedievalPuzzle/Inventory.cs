using System;
using System.Collections.Generic;

class Inventory
{
    private List<string> items = new List<string>();

    public void AddItem(string item)
    {
        items.Add(item);
        Console.WriteLine($"✅ {item} added to inventory!");
    }

    public bool HasItem(string item)
    {
        return items.Contains(item);
    }

    public void ShowInventory()
    {
        Console.WriteLine("\n🎒 Inventory:");
        if (items.Count > 0)
        {
            Console.WriteLine(string.Join(", ", items));
        }
        else
        {
            Console.WriteLine("Empty");
        }
        Console.ReadLine();
    }
}
