using ConsoleAppGame.Models;

namespace ConsoleAppGame.Visitor;

public class MissionVisitor : IVisitor
{
    public void VisitHealth(Spacecraft _spacecraft)
    {
        throw new NotImplementedException();
    }

    public void VisitReward(Mission _mission)
    {
        _mission.Reward = (int)MathF.Min(_mission.Reward + 10, 100);
        Logger.Log($"Mission {_mission.Name} reward increased to {_mission.Reward}");
    }

    public void VisitTime(Mission _mission)
    {
        _mission.Time = (int)MathF.Max(_mission.Time - 1, 0);
        Logger.Log($"Mission {_mission.Name} time decreased to {_mission.Time}");
    }
}