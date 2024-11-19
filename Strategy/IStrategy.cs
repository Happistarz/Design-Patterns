using ConsoleAppGame.Models;

namespace ConsoleAppGame.Strategy;

public interface IStrategy
{
    public void Execute(Mission _mission);
}