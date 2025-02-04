using System;
using System.Collections.Generic;
using System.Numerics;

class Game
{
    private Player player;
    private Dictionary<string, Room> rooms;
    private string currentRoom;

    public void Start()
    {
        Console.Clear();
        Console.WriteLine("🏰 Welcome to Escape From Castle!");
        Console.Write("Enter your name, brave adventurer: ");
        string name = Console.ReadLine();

        player = new Player(name);
        InitializeRooms();

        Console.Clear();
        Console.WriteLine($"Hello, {player.Name}! You are trapped inside an ancient castle. Find the key and escape!");
        Console.WriteLine("\nPress ENTER to begin...");
        Console.ReadLine();

        currentRoom = "Entrance";
        Play();
    }

    private void InitializeRooms()
    {
        rooms = new Dictionary<string, Room>();

        rooms["Entrance"] = new Room("Castle Entrance", "A large wooden door is locked behind you. There's only one way forward.", "Hall");
        rooms["Hall"] = new Room("Great Hall", "A grand hall with torches on the walls. There's a locked door requiring a 'Golden Key'.", "Library");
        rooms["Library"] = new Room("Ancient Library", "Bookshelves everywhere. A mysterious book stands out.", "Secret Room", "Golden Key");
        rooms["Secret Room"] = new Room("Secret Chamber", "A dark chamber with a lever.", "Exit", "Lever");
        rooms["Exit"] = new Room("Castle Exit", "You've found the final door! Use the lever to open it and escape.", "Victory", "Lever");
    }

    private void Play()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"📍 You are in: {rooms[currentRoom].Name}");
            Console.WriteLine($"{rooms[currentRoom].Description}");

            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Move to next room");
            Console.WriteLine("2. Check inventory");
            Console.WriteLine("3. Search the room");
            Console.WriteLine("4. Quit Game");

            Console.Write("\nYour choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    MoveToNextRoom();
                    break;
                case "2":
                    player.Inventory.ShowInventory();
                    break;
                case "3":
                    SearchRoom();
                    break;
                case "4":
                    Console.WriteLine("Exiting game... Thanks for playing!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void MoveToNextRoom()
    {
        Room current = rooms[currentRoom];

        if (current.RequiredItem != null && !player.Inventory.HasItem(current.RequiredItem))
        {
            Console.WriteLine($"🚪 You need '{current.RequiredItem}' to proceed!");
        }
        else
        {
            currentRoom = current.NextRoom;
            if (currentRoom == "Victory")
            {
                Console.WriteLine("🎉 Congratulations! You have escaped the castle and won the game!");
                Console.ReadLine();
                return;
            }
        }
        Console.ReadLine();
    }

    private void SearchRoom()
    {
        if (rooms[currentRoom].RequiredItem != null && !player.Inventory.HasItem(rooms[currentRoom].RequiredItem))
        {
            Console.WriteLine($"🔑 You found a {rooms[currentRoom].RequiredItem}!");
            player.Inventory.AddItem(rooms[currentRoom].RequiredItem);
        }
        else
        {
            Console.WriteLine("There is nothing useful here.");
        }
        Console.ReadLine();
    }
}
