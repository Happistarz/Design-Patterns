using ConsoleAppGame.Models;

namespace ConsoleAppGame.Strategy;

public class SafeStrategy : IStrategy
{
    public void Execute(Mission _mission)
    {
        _mission.Reward = 5;
        _mission.Time   = 5;
    }
}