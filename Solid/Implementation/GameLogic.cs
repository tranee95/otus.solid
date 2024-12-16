using Solid.interfaces;

namespace Solid.Implementation
{
    /// <summary>
    /// Класс, представляющий игру "Угадай число"
    /// </summary>
    public class GameLogic : IGameLogic
    {
        private int _attemptsCount;
        private readonly int _randomNumber;
        private readonly IMessages _messages;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="GameLogic"/> с заданным количеством попыток
        /// и генератором случайных чисел
        /// </summary>
        /// <param name="attemptsCount">Количество попыток, предоставляемых игроку</param>
        /// <param name="randomNumber"></param>
        /// <param name="messages"></param>
        public GameLogic(
            int attemptsCount, 
            int randomNumber,
            IMessages messages)
        {
            _attemptsCount = attemptsCount;
            _messages = messages;
            _randomNumber = randomNumber;
        }

        /// <inheritdoc />
        public bool Find(int findNumber)
        {
            SubtractingAttempts();
            return findNumber switch
            {
                _ when findNumber.Equals(_randomNumber) => true,
                _ when findNumber > _randomNumber => ShowMessageIfMore(),
                _ when findNumber < _randomNumber => ShowMessageIfLess()
            };
        }

        /// <inheritdoc />
        public bool IsHasAttempts() => _attemptsCount > 0;

        /// <inheritdoc />
        public int GetAttemptsCount() => _attemptsCount;

        /// <summary>
        /// Уменьшает количество оставшихся попыток
        /// </summary>
        /// <returns>Возвращает новое количество оставшихся попыток</returns>
        private int SubtractingAttempts() => --_attemptsCount;

        /// <summary>
        /// Выводит сообщение, если введенное число больше искомого
        /// </summary>
        /// <returns>Возвращает <c>false</c>.</returns>
        private bool ShowMessageIfMore()
        {
            Console.WriteLine(_messages.IfMore);
            return false;
        }

        /// <summary>
        /// Выводит сообщение, если введенное число меньше искомого
        /// </summary>
        /// <returns>Возвращает <c>false</c>.</returns>
        private bool ShowMessageIfLess()
        {
            Console.WriteLine(_messages.IfLess);
            return false;
        }
    }
}