using System.Text;

class Game
{
    private readonly GameMapGenerator _mapGenerator;
    private readonly GameWorld _world;

    private GameLevel _currentLevel = null!;

    public Game()
    {
        _mapGenerator = new GameMapGenerator();

        _world = new GameWorld(
            new PlayerMovement(),
            new EnemyLogic());
    }

    public void Start()
    {
        Console.CursorVisible = false;

        StartLevel();

        while (_world.IsRunning)
        {
            Draw();

            if (_world.PlayTurn(_currentLevel))
            {
                StartLevel();
            }
        }

        Stop();
    }

    private void StartLevel()
    {
        var generatedLevel =
            _mapGenerator.Generate(_world.Player.Stats.Level);

        _currentLevel = generatedLevel.Level;

        _world.StartLevel(generatedLevel);
        _world.Player.Stats.Health = 10;
    }

    private void Draw()
    {
        Console.SetCursorPosition(0, 0);

        var buffer = new StringBuilder();

        for (var y = 0; y < _currentLevel.Height; y++)
        {
            for (var x = 0; x < _currentLevel.Width; x++)
            {
                if (_world.IsPlayerAt(x, y))
                {
                    buffer.Append('@');
                    continue;
                }

                var enemy =
                    _world.Enemies.FirstOrDefault(
                        e => e.X == x && e.Y == y);

                if (enemy != null)
                {
                    buffer.Append('E');
                    continue;
                }

                buffer.Append(
                    _currentLevel.GetTile(x, y));
            }

            buffer.AppendLine();
        }

        buffer.Append(
            $"[WASD] Движение | " +
            $"HP: {_world.Player.Stats.Health} | " +
            $"Gold: {_world.Player.Stats.Gold} | " +
            $"Level: {_world.Player.Stats.Level}");

        Console.Write(buffer.ToString());
    }

    private void Stop()
    {
        Console.Clear();

        Console.WriteLine(
            $"ИГРА ОКОНЧЕНА. " +
            $"Ваше золото: {_world.Player.Stats.Gold} " +
            $"на {_world.Player.Stats.Level} уровне.");

        Console.ReadKey();
    }
}