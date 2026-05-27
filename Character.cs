class Character
{
    public Character(int health = 10, int damage = 1)
    {
        Health = health;
        Damage = damage;
    }

    public int X { get; set; }

    public int Y { get; set; }

    public int Health { get; private set; }

    public int Gold { get; private set; }

    public int Level { get; private set; } = 1;

    public int Damage { get; private set; }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void Heal(int health)
    {
        Health += health;
    }

    public void SetHealth(int health)
    {
        Health = health;
    }

    public void AddGold(int gold)
    {
        Gold += gold;
    }

    public void LevelUp()
    {
        Level++;
    }
}
