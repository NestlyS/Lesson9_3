using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Visitor
{
    [CreateAssetMenu(menuName = "Create Visitor Config")]
    public class EnemyStatConfig : ScriptableObject
    {
        [SerializeField] private List<EnemyStatPairConfig> _scoreConfig;
        [SerializeField] private EnemyWeightConfig _weightConfig;

        public Dictionary<EnemyType, int> ScoreConfig
        {
            get => GetDictionaryFromPairConfig(_scoreConfig);
        }

        public Dictionary<EnemyType, int> WeightConfig
        {
            get => GetDictionaryFromPairConfig(_weightConfig.Weights);
        }

        public int MaxWeight
        {
            get => _weightConfig.Weight;
        }

        private Dictionary<EnemyType, int> GetDictionaryFromPairConfig(
            List<EnemyStatPairConfig> config
        ) =>
            config
                .Aggregate(
                    new Dictionary<EnemyType, int>(),
                    (pairConfig, next) =>
                    {
                        pairConfig.Add(next.EnemyType, next.EnemyStatValue);
                        return pairConfig;
                    }
                 );
    }
}