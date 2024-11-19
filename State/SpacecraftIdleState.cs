using ConsoleAppGame.Models;

namespace ConsoleAppGame.State;

public class SpacecraftIdleState : ISpacecraftState
{
    private Spacecraft _context;
    
    public void SetContext(Spacecraft _spacecraft)
    {
        this._context = _spacecraft;
    }

    public string Render()
    {
        return $"{_context.Name,-10} [{_context.SpacecraftType}] | [{_context.Health}] HP";
    }

    public void Update()
    {
        throw new NotImplementedException();
    }
}