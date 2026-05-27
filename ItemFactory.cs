class ItemFactory
{
    public GameItem CreateGold()
    {
        return new GameItem("Gold", '$', gold: 10);
    }

    public GameItem CreateSmallMedkit()
    {
        return new GameItem("Small Medkit", '+', health: 3);
    }

    public GameItem CreateBigMedkit()
    {
        return new GameItem("Big Medkit", 'H', health: 8);
    }
}
