using ConsoleAppGame.Builder;
using ConsoleAppGame.Models;
using ConsoleAppGame.Singleton;

namespace ConsoleAppGame.Command;

public class LocationCommand : ICommand
{
    public List<Parameter> GetParameters() =>
    [
        new() { Name = "Name" },
        new() { Name = "Cost", Validator = _parameter => int.TryParse(_parameter.Value, out _) }
    ];
    
    public List<Parameter> Parameters      { get; } = [];

    public void Execute()
    {
        var location = new Location(Parameters[0].Value, Parameters[1].Value);
        GameManager.Instance.Locations.Add(location);
        location.Attach(GameManager.Instance.LocationObserver);
        GameManager.Instance.Director.MakeLocation(new LocationBuilder(location));
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }
}