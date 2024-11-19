using ConsoleAppGame.Visitor;

namespace ConsoleAppGame.Models;

public interface IModel
{
    public void Accept(IVisitor _visitor);
}