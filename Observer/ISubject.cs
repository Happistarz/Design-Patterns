namespace ConsoleAppGame.Observer;

public interface ISubject
{
    public void Notify();
    
    public void Attach(IObserver _observer);
    
    public void Detach(IObserver _observer);
}