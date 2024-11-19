using ConsoleAppGame.Models;

namespace ConsoleAppGame.Strategy;

public class EconomicalStrategy : IStrategy
{
    public void Execute(Mission _mission)
    {
        _mission.Reward = 10;
        _mission.Time   = 10;
    }
}