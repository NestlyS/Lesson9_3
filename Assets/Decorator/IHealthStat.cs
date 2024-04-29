public interface IHealthStat
{
    int MaxHealth { get; }
    int Value { get; }
    void Add(int value);
    void Reduce(int value); 
}
