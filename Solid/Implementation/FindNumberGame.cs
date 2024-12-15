using Solid.interfaces;

namespace Solid.Implementation
{
    /// <summary>
    /// Класс, представляющий игру "Угадай число"
    ///
    /// Данный класс реализуйет
    /// 1. Принцеп инверсии зависимости, конкретная реализация random вынесена в отдельную независемою реализацию
    /// 2. Принцеп открытости/закрытости, мы можем использовать интерфейсы для конкретной реализации random,
    /// тем самым легко подменить реализацию.  
    /// </summary>
    public class FindNumberGame : IFind
    {
        private int _attemptsCount;
        private readonly int _randomNumber;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FindNumberGame"/> с заданным количеством попыток
        /// и генератором случайных чисел
        /// </summary>
        /// <param name="attemptsCount">Количество попыток, предоставляемых игроку</param>
        /// <param name="randomGenerator">Генератор случайных чисел, используемый для получения искомого числа</param>
        public FindNumberGame(int attemptsCount, IRandomGenerator randomGenerator)
        {
            _attemptsCount = attemptsCount;
            _randomNumber = randomGenerator.Next();
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
            Console.WriteLine("Искомое значение больше, попробуйте ещё раз...");
            return false;
        }

        /// <summary>
        /// Выводит сообщение, если введенное число меньше искомого
        /// </summary>
        /// <returns>Возвращает <c>false</c>.</returns>
        private bool ShowMessageIfLess()
        {
            Console.WriteLine("Искомое значение меньше, попробуйте ещё раз...");
            return false;
        }
    }
}