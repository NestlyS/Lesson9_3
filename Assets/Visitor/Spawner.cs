using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Visitor
{
    public class Spawner : MonoBehaviour, IEnemyDeathNotifier, IEnemySpawnNotifier
    {
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private EnemyFactory _enemyFactory;

        private List<Enemy> _spawnedEnemies = new List<Enemy>();
        private ISpawnAvaibilityChecker _spawnAvaibilityChecker;

        private Coroutine _spawn;

        public event Action<Enemy> Notified;
        public event Action<Enemy> Spawned;

        public void Init(ISpawnAvaibilityChecker spawnAvaibilityChecker)
        {
            _spawnAvaibilityChecker = spawnAvaibilityChecker;
        }

        public void StartWork()
        {
            StopWork();

            _spawn = StartCoroutine(Spawn());
        }

        public void StopWork()
        {
            if (_spawn != null)
                StopCoroutine(_spawn);
        }

        public void KillRandomEnemy()
        {
            if (_spawnedEnemies.Count == 0)
                return;

            _spawnedEnemies[UnityEngine.Random.Range(0, _spawnedEnemies.Count)].Kill();
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                if (_spawnAvaibilityChecker.CanBeSpawned() == false)
                {
                    Debug.Log("Не могу заспаунить новых врагов!");
                    yield return new WaitForSeconds(_spawnCooldown);
                    continue;
                }

                Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
                enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
                enemy.Died += OnEnemyDied;
                _spawnedEnemies.Add(enemy);
                Spawned?.Invoke(enemy);
                yield return new WaitForSeconds(_spawnCooldown);
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            Notified?.Invoke(enemy);
            enemy.Died -= OnEnemyDied;
            _spawnedEnemies.Remove(enemy);
        }
    }
}
