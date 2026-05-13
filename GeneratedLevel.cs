class GeneratedLevel
{
    public GeneratedLevel(GameLevel level, List<Enemy> enemies, int playerStartX, int playerStartY)
    {
        Level = level;
        Enemies = enemies;
        PlayerStartX = playerStartX;
        PlayerStartY = playerStartY;
    }

    public GameLevel Level { get; }

    public List<Enemy> Enemies { get; }

    public int PlayerStartX { get; }

    public int PlayerStartY { get; }
}
