using Solid.interfaces;
using Solid.Interfaces;

namespace Solid.Implementation;

/// <summary>
/// Класс, представляющий игру
/// </summary>
public class Game : IGame
{
    private readonly IMessageService _messageService;

    public Game(IMessageService messageService)
    {
        _messageService = messageService;
    }

    /// <inheritdoc />
    public void Run(IGameLogic gameLogic)
    {
        while (gameLogic.IsHasAttempts())
        {
            var attemptsCount = gameLogic.GetAttemptsCount();
            _messageService.ShowMessage(Messages.GetCountToLossMessage(attemptsCount));

            var number = GetGuessNumberAtConsoleMenu();
            var isEquals = gameLogic.Find(number);

            if (isEquals)
            {
                _messageService.ShowMessage(Messages.Victory);
                break;
            }

            if (gameLogic.IsHasAttempts()) continue;

            _messageService.ShowMessage(Messages.Loss);
            break;
        }
    }

    /// <inheritdoc />
    public IGameLogic PrepareGameLogic()
    {
        var randomGenerator = CreateDefaultRandomGenerator();
        var attemptsCount = GetAttemptsCountAtConsoleMenu();

        return new GameLogic(attemptsCount, randomGenerator.Next(), _messageService);
    }

    /// <summary>
    /// Запрашивает у пользователя число через консоль с заданным сообщением
    /// </summary>
    /// <param name="consoleMessage">Сообщение, которое будет отображено пользователю</param>
    /// <returns>Введенное пользователем число</returns>
    private int GetNumberAtConsoleMenu(string consoleMessage)
    {
        _messageService.ShowMessage(consoleMessage);
        int number;
        while (!int.TryParse(_messageService.Read(), out number))
        {
            _messageService.ShowMessage(Messages.NotANumber);
        }

        return number;
    }

    /// <summary>
    /// Запрашивает у пользователя минимальное число через консоль.
    /// </summary>
    /// <returns>Введенное пользователем минимальное число</returns>
    private int GetMinNumberAtConsoleMenu()
    {
        return GetNumberAtConsoleMenu(Messages.EnterMinNumber);
    }

    /// <summary>
    /// Запрашивает у пользователя максимальное число через консоль
    /// </summary>
    /// <returns>Введенное пользователем максимальное число</returns>
    private int GetMaxNumberAtConsoleMenu()
    {
        return GetNumberAtConsoleMenu(Messages.EnterMaxNumber);
    }

    /// <summary>
    /// Запрашивает у пользователя количество попыток через консоль
    /// </summary>
    /// <returns>Введенное пользователем количество попыток</returns>
    private int GetAttemptsCountAtConsoleMenu()
    {
        return GetNumberAtConsoleMenu(Messages.EnterAttemptsCount);
    }

    /// <summary>
    /// Запрашивает у пользователя искомое число
    /// </summary>
    /// <returns>Введенное искомое число</returns>
    private int GetGuessNumberAtConsoleMenu()
    {
        return GetNumberAtConsoleMenu(Messages.EnterGuessNumber);
    }

    /// <summary>
    /// Создает генератор случайных чисел с заданным диапазоном
    /// </summary>
    /// <returns>Экземпляр <see cref="IRandomGenerator"/> с установленным диапазоном</returns>
    private IRandomGenerator CreateDefaultRandomGenerator()
    {
        int min, max;
        while (true)
        {
            min = GetMinNumberAtConsoleMenu();
            max = GetMaxNumberAtConsoleMenu();
            if (min < max)
            {
                break;
            }

            _messageService.ShowMessage(Messages.InvalidRange);
        }

        var random = new RandomGenerator(min, max);
        return random;
    }
}