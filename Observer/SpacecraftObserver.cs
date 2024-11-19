using ConsoleAppGame.Models;
using ConsoleAppGame.Singleton;

namespace ConsoleAppGame.Observer;

public class SpacecraftObserver : IObserver
{
    public void Update(ISubject _subject)
    {
        if (_subject is Spacecraft spacecraft)
        {
            GameManager.Instance.Logs.Add(
                $"Spacecraft {spacecraft.Name} [{spacecraft.SpacecraftType}] has been initializated.");
        }
    }
}