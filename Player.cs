class Player
{
    public int X { get; set; }

    public int Y { get; set; }

    public CharacterStats Stats { get; } = new();

    public void TakeDamage(int damage)
    {
        Stats.RemoveHealth(damage);
    }

    public void Heal(int health)
    {
        Stats.AddHealth(health);
    }

    public void SetHealth(int health)
    {
        Stats.SetHealth(health);
    }
}
