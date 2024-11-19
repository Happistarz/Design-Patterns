using System.Diagnostics;
using ConsoleAppGame.Builder;
using ConsoleAppGame.Models;
using ConsoleAppGame.Observer;
using ConsoleAppGame.Visitor;

namespace ConsoleAppGame.Singleton;

public class GameManager
{
    private static GameManager? _instance;

    public static GameManager Instance => _instance ??= new GameManager();

    public  int       Score { get; set; }
    private Stopwatch Timer { get; set; }

    public int Energy { get; set; } = 100;
    public int Metal  { get; set; } = 100;
    public int Fuel   { get; set; } = 100;

    public List<Spacecraft> Spacecrafts { get; set; } = [];
    public List<Mission>    Missions    { get; set; } = [];
    public List<Location>   Locations   { get; set; } = [];

    public List<string>       Logs               { get; set; } = [];
    public SpacecraftObserver SpacecraftObserver { get; set; } = new();
    public MissionObserver    MissionObserver    { get; set; } = new();
    public LocationObserver   LocationObserver   { get; set; } = new();
    public Director           Director           { get; set; } = new();
    public SpacecraftVisitor  SpacecraftVisitor  { get; set; } = new();
    public MissionVisitor     MissionVisitor     { get; set; } = new();

    private GameManager()
    {
        Score = 0;
        Timer = new Stopwatch();
        Timer.Start();
    }

    public string GetTime()
    {
        return Timer.Elapsed.ToString("mm\\:ss");
    }

    public string GetResources()
    {
        return $"Energy: [{Energy}] | Metal: [{Metal}] | Fuel: [{Fuel}]";
    }

    public Spacecraft? GetSpacecraft(int _index)
    {
        return _index < Spacecrafts.Count ? Spacecrafts[_index] : null;
    }

    public string GetSpacecrafts()
    {
        var spacecrafts = "";
        for (var i = 0; i < Spacecrafts.Count; i++)
        {
            spacecrafts += $"{i}. {Spacecrafts[i]}\n";
        }

        return spacecrafts;
    }

    public Mission? GetMission(int _index)
    {
        return _index < Missions.Count ? Missions[_index] : null;
    }

    public Location? GetLocation(int _index)
    {
        return _index < Locations.Count ? Locations[_index] : null;
    }

    public string GetLocations()
    {
        var locations = "";
        for (var i = 0; i < Locations.Count; i++)
        {
            locations += $"{i}. {Locations[i]}\n";
        }

        return locations;
    }

    public string GetLogs()
    {
        return Logs.Aggregate("", (_current, _log) => _current + $"{_log}\n");
    }

    public void Update()
    {
        Spacecrafts.ForEach(_spacecraft => _spacecraft.Update());
        Missions.ForEach(_mission => _mission.Update());
        Director.UpdateStep();
        
        Missions.RemoveAll(_mission => _mission.MissionState == Mission.State.SUCCESS);

        Energy += 10;
        Metal  += 10;
        Fuel   += 10;
        
        VisitSpacecrafts();
        VisitMissions();
    }

    private void VisitSpacecrafts()
    {
        if (new Random().Next(0, 100) >= 10) return;
        
        Spacecrafts.ForEach(_spacecraft => _spacecraft.Accept(SpacecraftVisitor));
    }
    
    private void VisitMissions()
    {
        if (new Random().Next(0, 100) >= 10) return;
        
        Missions.ForEach(_mission => _mission.Accept(MissionVisitor));
    }
}