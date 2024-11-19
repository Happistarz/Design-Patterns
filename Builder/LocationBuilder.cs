using ConsoleAppGame.Models;
using ConsoleAppGame.Singleton;

namespace ConsoleAppGame.Builder;

public class LocationBuilder : IBuilder
{
    private readonly Location _location;

    public LocationBuilder(Location _location)
    {
        this._location = _location;
        Reset();
    }

    public void Reset()
    {
    }

    public void SetFoundation()
    {
        GameManager.Instance.Logs.Add($"Location [{_location.Name}] Foundation set");
    }

    public void SetWalls()
    {
        GameManager.Instance.Logs.Add($"Location [{_location.Name}] Walls set");
    }

    public void SetRoof()
    {
        GameManager.Instance.Logs.Add($"Location [{_location.Name}] Roof set");
    }

    public void SetInterior()
    {
        GameManager.Instance.Logs.Add($"Location [{_location.Name}] Interior set");
    }

    private void Complete()
    {
        GameManager.Instance.Logs.Add($"Location [{_location.Name}] Completed");
        GameManager.Instance.Energy -= _location.GetCost();
        GameManager.Instance.Metal  -= _location.GetCost();
    }

    public int BuildStep(int _step)
    {
        switch (_step)
        {
            case 1:
                SetFoundation();
                break;
            case 2:
                SetWalls();
                break;
            case 3:
                SetRoof();
                break;
            case 4:
                SetInterior();
                Complete();
                break;
            default:
                return -1;
        }

        return _step;
    }
}