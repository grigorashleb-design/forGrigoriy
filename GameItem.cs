class GameItem
{
    public GameItem(string name, char symbol, int health = 0, int gold = 0)
    {
        Name = name;
        Symbol = symbol;
        Health = health;
        Gold = gold;
    }

    public string Name { get; }

    public char Symbol { get; }

    public int Health { get; }

    public int Gold { get; }

    public void ApplyTo(Character character)
    {
        if (Health > 0)
        {
            character.Heal(Health);
        }

        if (Gold > 0)
        {
            character.AddGold(Gold);
        }
    }
}
