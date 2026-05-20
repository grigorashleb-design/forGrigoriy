class GameMapGenerator
{
    private const int Width = 60;
    private const int Height = 20;
    private readonly Random _rng = new();

    public GeneratedLevel Generate(int level)
    {
        var map = CreateEmptyMap();

        CreateRandomWalls(map);

        const int playerStartX = 2;
        const int playerStartY = 2;

        map[playerStartX, playerStartY] = '.';

        var exitX = Width - 3;
        var exitY = Height - 3;

        map[exitX, exitY] = '>';

        var freeTiles = GetFreeTiles(
            map,
            playerStartX,
            playerStartY,
            exitX,
            exitY);

        Shuffle(freeTiles);

        const int goldCount = 5;

        PlaceGold(map, freeTiles, goldCount);

        var enemyCount = 3 + level;

        var enemies = CreateEnemies(
            freeTiles,
            goldCount,
            enemyCount);

        return new GeneratedLevel(
            new GameLevel(Width, Height, map),
            enemies,
            playerStartX,
            playerStartY);
    }

    private char[,] CreateEmptyMap()
    {
        var map = new char[Width, Height];

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                map[x, y] =
                    x == 0 ||
                    x == Width - 1 ||
                    y == 0 ||
                    y == Height - 1
                        ? '#'
                        : '.';
            }
        }

        return map;
    }

    private void CreateRandomWalls(char[,] map)
    {
        for (var i = 0; i < 150; i++)
        {
            var x = _rng.Next(1, Width - 1);
            var y = _rng.Next(1, Height - 1);

            map[x, y] = '#';
        }
    }

    
    private bool IsWalkable(char[,] map, int x, int y)
    {
        return map[x, y] == '.';
    }

    private List<(int x, int y)> GetFreeTiles(
    char[,] map,
    int playerX,
    int playerY,
    int exitX,
    int exitY)
    {
        var tiles = new List<(int, int)>();

        for (var y = 1; y < Height - 1; y++)
        {
            for (var x = 1; x < Width - 1; x++)
            {
                if (!IsWalkable(map, x, y))
                    continue;

                if ((x == playerX && y == playerY) ||
                    (x == exitX && y == exitY))
                    continue;

                tiles.Add((x, y));
            }
        }

        return tiles;
    }

    private void Shuffle<T>(List<T> list)
    {
        for (var i = list.Count - 1; i > 0; i--)
        {
            var j = _rng.Next(i + 1);

            (list[i], list[j]) = (list[j], list[i]);
        }
    }

    private void PlaceGold(char[,] map, List<(int x, int y)> freeTiles, int count)
    {
        count = Math.Min(count, freeTiles.Count);

        for (var i = 0; i < count; i++)
        {
            var (x, y) = freeTiles[i];
            map[x, y] = '$';
        }
    }

    private List<Enemy> CreateEnemies(
    List<(int x, int y)> freeTiles,
    int startIndex,
    int count)
    {
        var enemies = new List<Enemy>();

        count = Math.Min(count, freeTiles.Count - startIndex);

        for (var i = 0; i < count; i++)
        {
            var (x, y) = freeTiles[startIndex + i];
            enemies.Add(new Enemy(x, y));
        }

        return enemies;
    }
}
