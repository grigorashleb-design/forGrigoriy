class GameWorld
{
    private readonly PlayerMovement _playerMovement;
    private readonly EnemyLogic _enemyLogic;

    public GameWorld(PlayerMovement playerMovement, EnemyLogic enemyLogic)
    {
        _playerMovement = playerMovement;
        _enemyLogic = enemyLogic;
    }

    public Character Character { get; } = new();

    public List<Enemy> Enemies { get; } = new();

    public bool IsRunning => Character.Health > 0;

    public void StartLevel(GeneratedLevel generatedLevel)
    {
        Character.X = generatedLevel.PlayerStartX;
        Character.Y = generatedLevel.PlayerStartY;

        Enemies.Clear();
        Enemies.AddRange(generatedLevel.Enemies);
    }

    public bool PlayTurn(GameLevel level)
    {
        var shouldLoadNextLevel = _playerMovement.HandleTurn(this, level);
        if (shouldLoadNextLevel)
        {
            Character.LevelUp();
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
        return Character.X == x && Character.Y == y;
    }

    public bool IsEnemyAt(int x, int y)
    {
        return GetEnemyAt(x, y) != null;
    }

    public void PickUpItem(Character character, GameLevel level)
    {
        var item = level.GetItem(character.X, character.Y);

        if (item == null)
        {
            return;
        }

        item.ApplyTo(character);
        level.RemoveItem(character.X, character.Y);
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
