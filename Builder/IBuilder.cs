namespace ConsoleAppGame.Builder;

public interface IBuilder
{
    public void Reset();
    public void SetFoundation();
    public void SetWalls();
    public void SetRoof();
    public void SetInterior();
    
    public int BuildStep(int _step);
}