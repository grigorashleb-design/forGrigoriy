class GameWorld
{
    private readonly PlayerMovement _playerMovement;
    private readonly EnemyLogic _enemyLogic;

    public GameWorld(PlayerMovement playerMovement, EnemyLogic enemyLogic)
    {
        _playerMovement = playerMovement;
        _enemyLogic = enemyLogic;
    }

    public Player Player { get; } = new();

    public List<Enemy> Enemies { get; } = new();

    public bool IsRunning => Player.Stats.Health > 0;

    public void StartLevel(GeneratedLevel generatedLevel)
    {
        Player.X = generatedLevel.PlayerStartX;
        Player.Y = generatedLevel.PlayerStartY;

        Enemies.Clear();
        Enemies.AddRange(generatedLevel.Enemies);
    }

    public bool PlayTurn(GameLevel level)
    {
        var shouldLoadNextLevel = _playerMovement.HandleTurn(this, level);
        if (shouldLoadNextLevel)
        {
            Player.Stats.Level++;
            return true;
        }

        if (IsRunning)
        {
            _enemyLogic.HandleTurn(this, level);
        }

        return false;
    }

    public bool IsPlayerAt(int x, int y)
    {
        return Player.X == x && Player.Y == y;
    }

    public Enemy? GetEnemyAt(int x, int y)
    {
        foreach (var enemy in Enemies)
        {
            if (enemy.X == x && enemy.Y == y)
            {
                return enemy;
            }
        }

        return null;
    }
}
