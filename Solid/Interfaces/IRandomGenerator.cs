namespace Solid.interfaces
{
    public interface IRandomGenerator
    {
        /// <summary>
        /// Генерирует случайное число в заданном диапазоне
        /// </summary>
        /// <returns>Случайное целое число в диапазоне от <c>_min</c>
        /// (включительно) до <c>_max</c> (исключительно)</returns>
        int Next();
    }
}