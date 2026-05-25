class Enemy
{
    public Enemy(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }

    public int Y { get; set; }

    public int Health { get; set; } = 3;
}
