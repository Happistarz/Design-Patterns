using ConsoleAppGame.Observer;
using ConsoleAppGame.State;
using ConsoleAppGame.Visitor;

namespace ConsoleAppGame.Models;

public class Spacecraft : ISubject, IModel
{
    public enum Type
    {
        CARGO,
        FIGHTER,
        SCOUT
    }
    
    public ISpacecraftState CurrentState = new SpacecraftIdleState();
    private List<IObserver> Observers { get; set; } = [];

    public string   Name           { get; set; }
    public Type     SpacecraftType { get; set; }
    public int      Health         { get; set; }
    public Mission? CurrentMission { get; private set; }

    public Spacecraft(string _name, Type _type, int _health)
    {
        this.Name = _name;
        this.SpacecraftType = _type;
        this.Health = _health;
        this.CurrentState.SetContext(this);
    }

    public int GetCost()
    {
        return SpacecraftType switch
        {
            Type.CARGO   => 10,
            Type.FIGHTER => 20,
            Type.SCOUT   => 5,
            _            => 0
        };
    }
    
    public void SetMission(Mission _mission)
    {
        this.CurrentMission = _mission;
        SetState(new SpacecraftMissionState(this));
    }
    
    public void SetState(ISpacecraftState _state)
    {
        this.CurrentState = _state;
        this.CurrentState.SetContext(this);
    }

    public override string ToString()
    {
        return this.CurrentState.Render();
    }

    public void Accept(IVisitor _visitor)
    {
        _visitor.VisitHealth(this);
    }

    public void Update()
    {
        if (CurrentMission != null) CurrentMission.Time--;
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