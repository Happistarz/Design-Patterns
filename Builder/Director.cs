namespace ConsoleAppGame.Builder;

public class Director
{
    private IBuilder? _builder;
    
    private int Step { get; set; } = 1;

    private bool _isComplete;
    
    public void MakeLocation(IBuilder? builder)
    {
        this._builder = builder;
        builder?.Reset();
        Step = 1;
    }
    
    public void UpdateStep()
    {
        _isComplete = _builder?.BuildStep(Step) == -1;
        if (_isComplete) return;
        
        Step++;
    }
}