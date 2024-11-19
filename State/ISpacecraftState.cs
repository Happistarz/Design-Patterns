using ConsoleAppGame.Models;

namespace ConsoleAppGame.State;

public interface ISpacecraftState
{
    public void SetContext(Spacecraft _spacecraft);
    public string Render();
    public void Update();
}