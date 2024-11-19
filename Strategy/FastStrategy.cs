using ConsoleAppGame.Models;

namespace ConsoleAppGame.Strategy;

public class FastStrategy : IStrategy
{
    public void Execute(Mission _mission)
    {
        _mission.Reward = 2;
        _mission.Time   = 2;
    }
}