class Room
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string NextRoom { get; private set; }
    public string RequiredItem { get; private set; }

    public Room(string name, string description, string nextRoom, string requiredItem = null)
    {
        Name = name;
        Description = description;
        NextRoom = nextRoom;
        RequiredItem = requiredItem;
    }
}
