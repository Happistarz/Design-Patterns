using System.Collections.Concurrent;
using ConsoleAppGame.Command;
using ConsoleAppGame.Factory;
using ConsoleAppGame.Models;

namespace ConsoleAppGame;

using Singleton;

public class Application
{
    private CommandHistory CommandHistory { get; set; } = new();

    private CommandFactory.Command _lastCommand;

    private static bool _running = true;

    public void Run()
    {
        // Welcome();
        GameManager.Instance.Spacecrafts.Add(new Spacecraft("Faucon Millenium", Spacecraft.Type.FIGHTER, 100));
        GameManager.Instance.Locations.Add(new Location("Terre", "Planète bleue"));
        GameManager.Instance.Locations.Add(new Location("Mars", "Planète rouge"));

        Wait(1000);

        while (_running)
        {
            GameManager.Instance.Update();
            Draw();

            var input = Logger.ReadString();
            
            if (string.IsNullOrWhiteSpace(input))
                continue;
            else if (input is "exit" or "q")
                _running = false;
            else
                BuildCommand(input);

            Wait(100);
        }
    }

    private void Draw()
    {
        if (_lastCommand != CommandFactory.Command.HELP)
            Logger.Clear();
        
        Logger.Log($"[Score: {GameManager.Instance.Score}] [Time: {GameManager.Instance.GetTime()}]");
        Logger.Log("\n=== BASE SPATIALE ===");
        Logger.Log($"Resources: {GameManager.Instance.GetResources()}");

        Logger.Log("=== VAISSEAUX ===");
        Logger.Log(GameManager.Instance.GetSpacecrafts());

        Logger.Log("=== LOCATIONS ===");
        Logger.Log(GameManager.Instance.GetLocations());
        
        Logger.Log("=== LOGS ===");
        Logger.Log(GameManager.Instance.GetLogs());

        Logger.Log("\n>>> Séléctionnez une option:");
    }

    private void BuildCommand(string _commandInput)
    {
        var type = CommandFactory.GetCommandType(_commandInput);
        _lastCommand = type;

        switch (type)
        {
            case CommandFactory.Command.UNDO when CommandHistory.IsEmpty():
                Logger.Log("Aucune commande à annuler.");
                return;
            case CommandFactory.Command.UNDO:
                CommandHistory.Undo();
                return;
            case CommandFactory.Command.UNKNOWN:
                Logger.Log("Commande inconnue.");
                return;
        }

        var command = CommandFactory.CreateCommand(type);

        if (command == null) return;
        
        CommandHistory.Push(command);
        command.Execute();
    }

    private static void Welcome()
    {
        Logger.Log("Welcome to the game!\n");
        Animate(27, 250, (_i) => { Logger.LogSameLine("Loading" + new string('.', _i % 6)); });
    }

    private static void Wait(int _milliseconds)
    {
        Thread.Sleep(_milliseconds);
    }

    // alias method for loop with index
    private static void Repeat(int _times, Action<int> _action)
    {
        for (var i = 0; i < _times; i++)
        {
            _action(i);
        }
    }

    private static void Animate(int _times, int _milliseconds, Action<int> _action)
    {
        Repeat(_times, (_i) =>
        {
            _action(_i);
            Wait(_milliseconds);
            Console.SetCursorPosition(0, Console.CursorTop);
        });
    }
}