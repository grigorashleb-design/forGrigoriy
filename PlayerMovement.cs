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

        var nextX = world.Player.X + dx;
        var nextY = world.Player.Y + dy;

   
        var enemy = world.GetEnemyAt(nextX, nextY);

        if (enemy != null)
        {
            enemy.Health -= world.Player.Stats.Damage;

            if (enemy.Health <= 0)
            {
                world.Enemies.Remove(enemy);

                world.Player.Stats.Gold += 20;
            }

            return false;
        }

    
        if (level.GetTile(nextX, nextY) == '#')
        {
            return false;
        }


        world.Player.X = nextX;
        world.Player.Y = nextY;

  
        if (level.GetTile(world.Player.X, world.Player.Y) == '$')
        {
            world.Player.Stats.Gold += 10;

            level.SetTile(world.Player.X, world.Player.Y, '.');
        }

        return level.GetTile(world.Player.X, world.Player.Y) == '>';
    }
}