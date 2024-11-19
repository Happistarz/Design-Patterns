using ConsoleAppGame.Models;

namespace ConsoleAppGame.Visitor;

public interface IVisitor
{
    public void VisitHealth(Spacecraft _spacecraft);
    public void VisitReward(Mission _mission);
    public void VisitTime(Mission _mission);
}