using ConsoleAppGame.Command;

namespace ConsoleAppGame.Factory;

public abstract class CommandFactory
{
    public enum Command
    {
        UNKNOWN,
        HELP,
        SPACECRAFT,
        LOCATION,
        UNDO,
        MISSION
    }

    public static ICommand? CreateCommand(Command _commandInput)
    {
        var command = GetCommand(_commandInput);
        var parameters = command.GetParameters();
        
        for (var i = 0; i < parameters.Count; i++)
        {
            var parameter = parameters[i];
            
            Logger.Log($"> Entrez le paramètre {parameter.Name} (or 'cancel'):");
            parameter.Value = Logger.ReadString();
            
            if (parameter.Value.Equals("cancel", StringComparison.CurrentCultureIgnoreCase)) return null;
            
            while (parameter.Validator != null && !parameter.Validator(parameter))
            {
                Logger.Log("Paramètre invalide");
                Logger.Log($"> Entrez le paramètre {parameter} (or 'cancel'):");
                parameter.Value = Logger.ReadString();
                if (parameter.Value.Equals("cancel", StringComparison.CurrentCultureIgnoreCase)) return null;
            }
            
            parameters[i] = parameter;
        }

        command.Parameters.AddRange(parameters);
        return command;
    }

    private static ICommand GetCommand(Command _command)
    {
        return _command switch
        {
            Command.HELP       => new HelpCommand(),
            Command.SPACECRAFT => new SpacecraftCommand(),
            Command.LOCATION   => new LocationCommand(),
            Command.MISSION => new MissionCommand(),
            _ => throw new ArgumentOutOfRangeException(nameof(_command), _command, null)
        };
    }

    public static Command GetCommandType(string _command)
    {
        return _command switch
        {
            "help"       => Command.HELP,
            "spacecraft" => Command.SPACECRAFT,
            "location"   => Command.LOCATION,
            "undo"       => Command.UNDO,
            "mission"    => Command.MISSION,
            _            => Command.UNKNOWN
        };
    }
}