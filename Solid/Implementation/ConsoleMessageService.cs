using Solid.Interfaces;

namespace Solid.Implementation;

public class ConsoleMessageService : IMessageService
{
    public void ShowMessage(string text) => Console.WriteLine(text);

    public string? Read() => Console.ReadLine();

}