using Solid.interfaces;

namespace Solid.Implementation
{
    /// <summary>
    /// Класс, представляющий генератор случайных чисел в заданном диапазоне
    ///
    /// Данынй класс реализует
    /// 1. Принцем разделение интерфейсов
    /// 2. Принцеп подстановки Лисков
    /// 3. Принцеп единой ответствености, конечно под вопросом, поскольку мы помимо создания генератора случайных чисел
    /// мы ещё и валидируем данные, но поскольку без данной валидации мы можем поулчить ошибку, я считаю что тут все уместно
    /// </summary>
    public class RandomGenerator : IRandomGenerator, IValidate 
    {
        private readonly Random _random = new Random();
        private readonly int _min;
        private readonly int _max;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RandomGenerator"/> с заданным диапазоном
        /// </summary>
        /// <param name="min">Минимальное значение (включительно) для генерации случайных чисел</param>
        /// <param name="max">Максимальное значение (исключительно) для генерации случайных чисел</param>
        public RandomGenerator(int min, int max)
        {
            _min = min;
            _max = max;
        }

        /// <inheritdoc />
        public int Next() => _random.Next(_min, _max);

        /// <inheritdoc />
        public bool Validate() => !(_max <= _min);
    }
}