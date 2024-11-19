namespace ConsoleAppGame.Command;

public class HelpCommand : ICommand
{
    public List<Parameter> GetParameters() => [];

    public List<Parameter> Parameters { get; } = [];

    public void Execute()
    {
        Logger.Log("Available commands:");
        Logger.Log("  help");
        Logger.Log("  spacecraft <name> <type> <health>");
        Logger.Log("  location <name> <description>");
        Logger.Log("  mission <name> <reward>");
        Logger.Log("  assign <mission> <spacecraft> <location> <time>");
        Logger.Log("  start <mission>");
        Logger.Log("  status");
        Logger.Log("  exit");
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }
}