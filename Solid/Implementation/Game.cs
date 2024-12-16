using Solid.interfaces;

namespace Solid.Implementation
{
    /// <summary>
    /// Класс, представляющий игру
    /// </summary>
    public class Game : IGame
    {
        private readonly IMessages _messages;
        
        public Game(IMessages messages)
        {
            _messages = messages;
        }

        /// <inheritdoc />
        public void Run(IGameLogic gameLogic)
        {
            while (gameLogic.IsHasAttempts())
            {
                var attemptsCount = gameLogic.GetAttemptsCount();
                Console.WriteLine(_messages.GetCountToLossMessage(attemptsCount));

                var number = GetGuessNumberAtConsoleMenu();
                var isEquals = gameLogic.Find(number);

                if (isEquals)
                {
                    Console.WriteLine(_messages.Victory);
                    break;
                }

                if (gameLogic.IsHasAttempts()) continue;

                Console.WriteLine(_messages.Loss);
                break;
            }
            Console.ReadLine();
        }

        /// <inheritdoc />
        public IGameLogic PrepareGameLogic()
        {
            var randomGenerator = CreateDefaultRandomGenerator();
            var attemptsCount = GetAttemptsCountAtConsoleMenu();

            return new GameLogic(attemptsCount, randomGenerator.Next(), _messages);
        }

        /// <summary>
        /// Запрашивает у пользователя число через консоль с заданным сообщением
        /// </summary>
        /// <param name="consoleMessage">Сообщение, которое будет отображено пользователю</param>
        /// <returns>Введенное пользователем число</returns>
        private int GetNumberAtConsoleMenu(string consoleMessage)
        {
            Console.Write(consoleMessage);
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine(_messages.NotANumber);
            }
            return number;
        }

        /// <summary>
        /// Запрашивает у пользователя минимальное число через консоль.
        /// </summary>
        /// <returns>Введенное пользователем минимальное число</returns>
        private int GetMinNumberAtConsoleMenu()
        {
            return GetNumberAtConsoleMenu(_messages.EnterMinNumber);
        }

        /// <summary>
        /// Запрашивает у пользователя максимальное число через консоль
        /// </summary>
        /// <returns>Введенное пользователем максимальное число</returns>
        private int GetMaxNumberAtConsoleMenu()
        {
            return GetNumberAtConsoleMenu(_messages.EnterMaxNumber);
        }

        /// <summary>
        /// Запрашивает у пользователя количество попыток через консоль
        /// </summary>
        /// <returns>Введенное пользователем количество попыток</returns>
        private int GetAttemptsCountAtConsoleMenu()
        { 
            return GetNumberAtConsoleMenu(_messages.EnterAttemptsCount);
        }

        /// <summary>
        /// Запрашивает у пользователя искомое число
        /// </summary>
        /// <returns>Введенное искомое число</returns>
        private int GetGuessNumberAtConsoleMenu()
        {
            return GetNumberAtConsoleMenu(_messages.EnterGuessNumber); 
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
                Console.WriteLine(_messages.InvalidRange);
            }
            var random = new RandomGenerator(min, max);
            return random;
        }
    }
}