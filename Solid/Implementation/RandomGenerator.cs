using Solid.interfaces;

namespace Solid.Implementation;

/// <summary>
/// Класс, представляющий генератор случайных чисел в заданном диапазоне
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