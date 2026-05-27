class EnemyLogic
{
    public void HandleTurn(GameWorld world, GameLevel level)
    {
        foreach (var enemy in world.Enemies)
        {
            var dx = world.Character.X > enemy.X ? 1 : world.Character.X < enemy.X ? -1 : 0;
            var dy = world.Character.Y > enemy.Y ? 1 : world.Character.Y < enemy.Y ? -1 : 0;

            if (Math.Abs(world.Character.X - enemy.X) <= 1 && Math.Abs(world.Character.Y - enemy.Y) <= 1)
            {
                world.Character.TakeDamage(1);
                continue;
            }

            var nextX = enemy.X + dx;
            var nextY = enemy.Y + dy;
            if (level.GetTile(nextX, nextY) == '.' && !world.IsPlayerAt(nextX, nextY))
            {
                enemy.X = nextX;
                enemy.Y = nextY;
            }
        }
    }
}
