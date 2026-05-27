class PlayerMovement
{
    public bool HandleTurn(GameWorld world, GameLevel level)
    {
        var key = Console.ReadKey(true).Key;

        var dx = 0;
        var dy = 0;

        if (key == ConsoleKey.W)
        {
            dy = -1;
        }

        if (key == ConsoleKey.S)
        {
            dy = 1;
        }

        if (key == ConsoleKey.A)
        {
            dx = -1;
        }

        if (key == ConsoleKey.D)
        {
            dx = 1;
        }

        var nextX = world.Character.X + dx;
        var nextY = world.Character.Y + dy;

   
        var enemy = world.GetEnemyAt(nextX, nextY);

        if (enemy != null)
        {
            enemy.TakeDamage(world.Character.Damage);

            if (enemy.Health <= 0)
            {
                world.Enemies.Remove(enemy);

                world.Character.AddGold(20 + enemy.Gold);
            }

            return false;
        }

    
        if (level.GetTerrainTile(nextX, nextY) == '#')
        {
            return false;
        }


        world.Character.X = nextX;
        world.Character.Y = nextY;

        world.PickUpItem(world.Character, level);

        return level.GetTerrainTile(world.Character.X, world.Character.Y) == '>';
    }
}
