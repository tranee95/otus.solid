using Solid.Implementation;

namespace Solid;

class Program
{
    public static void Main(string[] args)
    {
        var messages = new Messages();
        var game = new Game(messages);
        var gameLogic = game.PrepareGameLogic();

        game.Run(gameLogic);
    }
}