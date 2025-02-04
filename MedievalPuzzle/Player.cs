class Player
{
    public string Name { get; private set; }
    public Inventory Inventory { get; private set; }

    public Player(string name)
    {
        Name = name;
        Inventory = new Inventory();
    }
}
