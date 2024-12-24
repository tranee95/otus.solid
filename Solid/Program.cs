using Solid.Implementation;

namespace Solid;

class Program
{
    public static void Main(string[] args)
    {
        var messageService = new ConsoleMessageService();

        var game = new Game(messageService);
        var gameLogic = game.PrepareGameLogic();

        game.Run(gameLogic);
    }
}