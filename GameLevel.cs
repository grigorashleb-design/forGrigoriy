class GameLevel
{
    private readonly char[,] _tiles;

    public GameLevel(int width, int height, char[,] tiles)
    {
        Width = width;
        Height = height;
        _tiles = tiles;
    }

    public int Width { get; }

    public int Height { get; }

    public char GetTile(int x, int y)
    {
        return _tiles[x, y];
    }

    public void SetTile(int x, int y, char tile)
    {
        _tiles[x, y] = tile;
    }
}
