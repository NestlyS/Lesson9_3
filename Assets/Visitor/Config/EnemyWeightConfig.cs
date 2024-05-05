using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Visitor
{
    [Serializable]
    public class EnemyWeightConfig
    {
        [field: SerializeField] public int Weight {  get; private set; }
        [field: SerializeField] public List<EnemyStatPairConfig> Weights {  get; private set; }
    }
}
