namespace ConsoleAppGame;
public abstract class Logger
{
    public static void Log(string _message)
    {
        Console.WriteLine(_message);
    }
    
    public static void LogSameLine(string _message)
    {
        Console.Write("\r{0}" + new string(' ', _message.Length), _message);
    }
    
    public static string ReadString()
    {
        return Console.ReadLine() ?? string.Empty;
    }
    
    public static int ReadInt()
    {
        return int.Parse(ReadString());
    }
    
    public static void Clear()
    {
        Console.Clear();
    }
}