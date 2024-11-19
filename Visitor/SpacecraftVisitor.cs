using ConsoleAppGame.Models;

namespace ConsoleAppGame.Visitor;

public class SpacecraftVisitor : IVisitor
{
    public void VisitHealth(Spacecraft _spacecraft)
    {
        _spacecraft.Health = (int)MathF.Min(_spacecraft.Health + 10, 100);
        Logger.Log($"Visited {_spacecraft.Name} and increased health to {_spacecraft.Health}");
    }

    public void VisitReward(Mission _mission)
    {
        throw new NotImplementedException();
    }

    public void VisitTime(Mission _mission)
    {
        throw new NotImplementedException();
    }
}