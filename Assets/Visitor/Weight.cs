using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Visitor
{
    public class Weight : IDisposable, ISpawnAvaibilityChecker
    {
        public int Value => _enemyVisitor.Value;

        private readonly int _maxWeight;
        private IEnemyDeathNotifier _enemyDeathNotifier;
        private IEnemySpawnNotifier _enemySpawnNotifier;
        private EnemyWeightVisitor _enemyVisitor;

        public Weight(
            IEnemyDeathNotifier enemyDeathNotifier,
            IEnemySpawnNotifier enemySpawnNotifier,
            Dictionary<EnemyType, int> statConfig, 
            int maxWeight
        )
        {
            _maxWeight = maxWeight;

            _enemyDeathNotifier = enemyDeathNotifier;
            _enemyDeathNotifier.Notified += OnEnemyKilled;

            _enemySpawnNotifier = enemySpawnNotifier;
            _enemySpawnNotifier.Spawned += OnEnemySpawned;

            _enemyVisitor = new EnemyWeightVisitor(statConfig);
        }

        public void OnEnemySpawned(Enemy enemy)
        {
            Debug.Log("Создан враг типа " + enemy.GetType());
            _enemyVisitor.Visit(enemy);
            Debug.Log("Общий вес: " + Value);
        }

        public void OnEnemyKilled(Enemy enemy)
        {
            _enemyVisitor.Unvisit(enemy);
            Debug.Log("Общий вес: " + Value);
        }

        public void Dispose()
        {
            _enemySpawnNotifier.Spawned -= OnEnemySpawned;
            _enemyDeathNotifier.Notified -= OnEnemyKilled;
        }

        public bool CanBeSpawned() => Value < _maxWeight;
    }
}

