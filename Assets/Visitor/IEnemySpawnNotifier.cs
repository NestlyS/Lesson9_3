using System;

namespace Assets.Visitor
{
    public interface IEnemySpawnNotifier
    {
        event Action<Enemy> Spawned;
    }
}
