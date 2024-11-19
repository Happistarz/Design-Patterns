using ConsoleAppGame.Models;
using ConsoleAppGame.Singleton;

namespace ConsoleAppGame.Observer;

public class LocationObserver : IObserver
{
    public void Update(ISubject _subject)
    {
        if (_subject is Location location)
        {
            GameManager.Instance.Logs.Add(
                $"Location {location.Name} has been initialized");
        }
    }
}