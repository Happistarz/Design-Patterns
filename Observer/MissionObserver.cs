using ConsoleAppGame.Models;
using ConsoleAppGame.Singleton;

namespace ConsoleAppGame.Observer;

public class MissionObserver : IObserver
{
    public void Update(ISubject _subject)
    {
        if (_subject is Mission mission)
        {
            GameManager.Instance.Logs.Add(
                $"Mission {mission.Name} has been completed by {mission.Spacecraft?.Name ?? "NO SPACECRAFT"}");
        }
    }
}