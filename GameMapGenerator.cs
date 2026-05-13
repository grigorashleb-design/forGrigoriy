class GameMapGenerator
{
    private const int Width = 60;
    private const int Height = 20;
    private readonly Random _rng = new();

    public GeneratedLevel Generate(int level)
    {
        var map = new char[Width, Height];

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                map[x, y] = x == 0 || x == Width - 1 || y == 0 || y == Height - 1 ? '#' : '.';
            }
        }

        for (var i = 0; i < 150; i++)
        {
            map[_rng.Next(1, Width - 1), _rng.Next(1, Height - 1)] = '#';
        }

        const int playerStartX = 2;
        const int playerStartY = 2;
        map[playerStartX, playerStartY] = '.';

        map[Width - 3, Height - 3] = '>';
        for (var i = 0; i < 5; i++)
        {
            map[_rng.Next(1, Width - 1), _rng.Next(1, Height - 1)] = '$';
        }

        var enemies = new List<Enemy>();
        for (var i = 0; i < 3 + level; i++)
        {
            var enemyX = _rng.Next(10, Width - 1);
            var enemyY = _rng.Next(5, Height - 1);

            if (map[enemyX, enemyY] == '.')
            {
                enemies.Add(new Enemy(enemyX, enemyY));
            }
        }

        return new GeneratedLevel(new GameLevel(Width, Height, map), enemies, playerStartX, playerStartY);
    }
}
