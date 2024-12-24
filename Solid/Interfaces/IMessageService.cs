namespace Solid.Interfaces;

public interface IMessageService
{
    void ShowMessage(string text);

    string? Read();
}