using ConsoleAppGame.Models;
using ConsoleAppGame.Singleton;
using ConsoleAppGame.State;

namespace ConsoleAppGame.Command;

public class SpacecraftCommand : ICommand
{
    public List<Parameter> GetParameters() =>
    [
        new() { Name = "Name" },
        new() { Name = "Type", Validator = _parameter => Enum.TryParse(typeof(Spacecraft.Type), _parameter.Value, out _) },
        new() { Name = "Cost", Validator = _parameter => int.TryParse(_parameter.Value, out _) }
    ];

    public List<Parameter> Parameters { get; init; } = [];

    public void Execute()
    {
        var spacecraft = new Spacecraft(Parameters[0].Value,
                                        (Spacecraft.Type)Enum.Parse(typeof(Spacecraft.Type), Parameters[1].Value),
                                        int.Parse(Parameters[2].Value));
        spacecraft.SetState(new SpacecraftIdleState());
        
        GameManager.Instance.Spacecrafts.Add(spacecraft);
        spacecraft.Attach(GameManager.Instance.SpacecraftObserver);
        spacecraft.Notify();
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }
}