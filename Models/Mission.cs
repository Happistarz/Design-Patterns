using ConsoleAppGame.Observer;
using ConsoleAppGame.Singleton;
using ConsoleAppGame.Strategy;
using ConsoleAppGame.Visitor;

namespace ConsoleAppGame.Models;

public class Mission(string _name, Spacecraft? _spacecraft, Location? _destination) : ISubject, IModel
{
    public enum State
    {
        IN_PROGRESS,
        SUCCESS
    }

    public enum Strategy
    {
        SAFE,
        ECONOMICAL,
        FAST
    }

    private List<IObserver> Observers { get; set; } = [];
    private IStrategy       _missionStrategy = new SafeStrategy();

    public string      Name         { get; set; } = _name;
    public State       MissionState { get; set; } = State.IN_PROGRESS;
    public int         Reward       { get; set; }
    public int         Time         { get; set; }
    public Location?   Destination  { get; set; } = _destination;
    public Spacecraft? Spacecraft   { get; set; } = _spacecraft;

    public override string ToString()
    {
        return $"{Name} - {MissionState} - Reward: {Reward} - Time: {Time}";
    }

    public void SetStrategy(Strategy _strat)
    {
        IStrategy strategy = _strat switch
        {
            Strategy.SAFE       => new SafeStrategy(),
            Strategy.ECONOMICAL => new EconomicalStrategy(),
            Strategy.FAST       => new FastStrategy(),
            _                   => new SafeStrategy()
        };
        strategy.Execute(this);
    }

    public void Accept(IVisitor _visitor)
    {
        _visitor.VisitReward(this);
        _visitor.VisitTime(this);
    }

    public void Update()
    {
        if (Time > 0)
        {
            Time--;
        }
        else
        {
            MissionState = State.SUCCESS;
            Notify();
            Spacecraft = null;
        }
    }

    public void Notify()
    {
        foreach (var observer in Observers)
        {
            observer.Update(this);
        }
    }

    public void Attach(IObserver _observer)
    {
        Observers.Add(_observer);
    }

    public void Detach(IObserver _observer)
    {
        Observers.Remove(_observer);
    }
}