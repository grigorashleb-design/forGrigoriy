class GameLevel
{
    private readonly char[,] _tiles;
    private readonly GameItem?[,] _items;

    public GameLevel(int width, int height, char[,] tiles, GameItem?[,] items)
    {
        Width = width;
        Height = height;
        _tiles = tiles;
        _items = items;
    }

    public int Width { get; }

    public int Height { get; }

    public char GetTile(int x, int y)
    {
        return _items[x, y]?.Symbol ?? _tiles[x, y];
    }

    public char GetTerrainTile(int x, int y)
    {
        return _tiles[x, y];
    }

    public void SetTile(int x, int y, char tile)
    {
        _tiles[x, y] = tile;
    }

    public GameItem? GetItem(int x, int y)
    {
        return _items[x, y];
    }

    public void SetItem(int x, int y, GameItem item)
    {
        _items[x, y] = item;
    }

    public void RemoveItem(int x, int y)
    {
        _items[x, y] = null;
    }
}
