using System;
using UnityEngine;

namespace Assets.Visitor
{
    [Serializable]
    public class EnemyStatPairConfig
    {
        [field: SerializeField] public EnemyType EnemyType {  get; private set; }
        [field: SerializeField] public int EnemyStatValue {  get; private set; }
    }
}