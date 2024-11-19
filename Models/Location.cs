using ConsoleAppGame.Observer;
using ConsoleAppGame.Singleton;

namespace ConsoleAppGame.Models;

public class Location(string _name, string _description) : ISubject
{
    public enum Type
    {
        PLANET,
        SPACE_STATION,
        ASTEROID
    }
    
    private List<IObserver> Observers { get; set; } = [];

    public string Name         { get; set; } = _name;
    public string Description  { get; set; } = _description;
    public Type   LocationType { get; set; }
    
    public int GetCost()
    {
        return LocationType switch
        {
            Type.PLANET        => 10,
            Type.SPACE_STATION => 20,
            Type.ASTEROID      => 5,
            _                  => 0
        };
    }

    public override string ToString()
    {
        return $"{Name} - {Description}";
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