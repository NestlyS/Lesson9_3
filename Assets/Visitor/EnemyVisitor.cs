using System.Collections.Generic;

namespace Assets.Visitor
{
    public class EnemyVisitor : IEnemyVisitor
    {
        public EnemyVisitor(Dictionary<EnemyType, int> config)
        {
            Config = config;
        }

        protected readonly Dictionary<EnemyType, int> Config;
        public int Value { get; protected set; }

        public void Visit(Elf elf) => Value += Config.GetValueOrDefault(EnemyType.Elf);

        public void Visit(Human human) => Value += Config.GetValueOrDefault(EnemyType.Human);

        public void Visit(Ork ork) => Value += Config.GetValueOrDefault(EnemyType.Ork);

        public void Visit(Robot robot) => Value += Config.GetValueOrDefault(EnemyType.Robot);

        public void Visit(Enemy enemy) => Visit((dynamic)enemy);
    }
}