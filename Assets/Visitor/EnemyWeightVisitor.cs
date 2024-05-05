using System.Collections.Generic;

namespace Assets.Visitor
{
    public class EnemyWeightVisitor : EnemyVisitor
    {
        public EnemyWeightVisitor(Dictionary<EnemyType, int> config) : base(config)
        {
        }

        public void Unvisit(Elf elf) => Value -= Config.GetValueOrDefault(EnemyType.Elf);

        public void Unvisit(Human human) => Value -= Config.GetValueOrDefault(EnemyType.Human);
        public void Unvisit(Ork ork) => Value -= Config.GetValueOrDefault(EnemyType.Ork);

        public void Unvisit(Robot robot) => Value -= Config.GetValueOrDefault(EnemyType.Robot);

        public void Unvisit(Enemy enemy) => Unvisit((dynamic)enemy);
    }
}