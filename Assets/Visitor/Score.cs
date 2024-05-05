using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Visitor
{
    public class Score: IDisposable
    {
        public int Value => _enemyVisitor.Value;

        private IEnemyDeathNotifier _enemyDeathNotifier;
        private EnemyVisitor _enemyVisitor;

        public Score(IEnemyDeathNotifier enemyDeathNotifier, Dictionary<EnemyType, int> statConfig)
        {
            _enemyDeathNotifier = enemyDeathNotifier;
            _enemyDeathNotifier.Notified += OnEnenmyKilled;

            _enemyVisitor = new EnemyVisitor(statConfig);
        }

        public void OnEnenmyKilled(Enemy enemy)
        {
            _enemyVisitor.Visit(enemy);
            Debug.Log("Cчет: " + Value);
        }

        public void Dispose()
        {
            _enemyDeathNotifier.Notified -= OnEnenmyKilled;
        }
    }
}

