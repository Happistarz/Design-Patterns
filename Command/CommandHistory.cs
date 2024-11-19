namespace ConsoleAppGame.Command;

public class CommandHistory
{
    private readonly Stack<ICommand> _commands = new Stack<ICommand>();
    
    public void Push(ICommand _command)
    {
        _commands.Push(_command);
    }
    
    public void Undo()
    {
        if (_commands.Count <= 0) return;
        
        var command = _commands.Pop();
        command.Undo();
    }
    
    public bool IsEmpty()
    {
        return _commands.Count == 0;
    }
}