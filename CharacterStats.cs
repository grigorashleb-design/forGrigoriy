class CharacterStats
{
    public int Health { get; private set; } = 10;

    public int Gold { get; set; }

    public int Level { get; set; } = 1;

    public int Damage { get; set; } = 1;

    public void SetHealth(int health)
    {
        Health = health;
    }

    public void AddHealth(int health)
    {
        Health += health;
    }

    public void RemoveHealth(int health)
    {
        Health -= health;
    }
}
