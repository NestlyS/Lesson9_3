using UnityEngine;

namespace Assets.Visitor
{
    public class VisitorBootstrap : MonoBehaviour
    {
        [SerializeField] private Spawner _enemySpawner;
        [SerializeField] private EnemyStatConfig _enemyStatConfig;

        private Score _score;
        private Weight _weight;

        private void Awake()
        {
            _score = new Score(_enemySpawner, _enemyStatConfig.ScoreConfig);
            _weight = new Weight(_enemySpawner, _enemySpawner, _enemyStatConfig.WeightConfig, _enemyStatConfig.MaxWeight);

            _enemySpawner.Init(_weight);
            _enemySpawner.StartWork();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
                _enemySpawner.KillRandomEnemy();
        }
    }
}

