using ConsoleAppGame.Models;
using ConsoleAppGame.Singleton;
using ConsoleAppGame.State;

namespace ConsoleAppGame.Command;

public class MissionCommand : ICommand
{
    public List<Parameter> GetParameters() =>
    [
        new() { Name = "Name" },
        new()
        {
            Name      = "Strategy",
            Validator = _parameter => Enum.TryParse(typeof(Mission.Strategy), _parameter.Value, out _)
        },
        new()
        {
            Name = "Spacecraft", Validator = _parameter =>
            {
                if (!int.TryParse(_parameter.Value.ToString(), out var id)) return false;
                var spacecraft = GameManager.Instance.GetSpacecraft(id);
                return spacecraft is { CurrentState: SpacecraftIdleState };
            }
        },

        new() { Name = "Location", Validator = _parameter => int.TryParse(_parameter.Value, out _) }
    ];

    public List<Parameter> Parameters { get; } = [];

    public void Execute()
    {
        var spacecraft = GameManager.Instance.GetSpacecraft(int.Parse(Parameters[2].Value));
        var mission = new Mission(Parameters[0].Value, spacecraft,
                                  GameManager.Instance.GetLocation(int.Parse(Parameters[3].Value)));
        spacecraft?.SetMission(mission);
        mission.Spacecraft = spacecraft;
        mission.SetStrategy((Mission.Strategy)Enum.Parse(typeof(Mission.Strategy), Parameters[1].Value));

        GameManager.Instance.Missions.Add(mission);
        mission.Attach(GameManager.Instance.MissionObserver);
        GameManager.Instance.Fuel -= spacecraft?.GetCost() ?? 0;
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }
}