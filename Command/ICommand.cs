namespace ConsoleAppGame.Command;

public struct Parameter
{
    public string              Name      { get; set; }
    public string              Value     { get; set; }
    public Func<Parameter, bool>? Validator { get; set; }

    public Parameter(string _name)
    {
        Name      = _name;
        Value     = "";
        Validator = null;
    }

    public override string ToString()
    {
        return $"{Name}: {Value}";
    }
}

public interface ICommand
{
    public List<Parameter> GetParameters();

    public List<Parameter> Parameters { get; }

    public void Execute();
    public void Undo();
}