using ConsoleAppGame.Models;

namespace ConsoleAppGame.State;

public class SpacecraftMissionState(Spacecraft _context) : ISpacecraftState
{
    private Spacecraft _context = _context;

    public void SetContext(Spacecraft _spacecraft)
    {
        this._context = _spacecraft;
    }

    public string Render()
    {
        return $"{_context.Name,-10} [{_context.SpacecraftType}] | [{_context.Health}] HP || [{_context.CurrentMission?.ToString() ?? "NO MISSION"}]";
    }

    public void Update()
    {
        throw new NotImplementedException();
    }
}