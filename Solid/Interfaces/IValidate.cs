namespace Solid.interfaces;

public interface IValidate
{
    /// <summary>
    /// Проверяет, корректен ли заданный диапазон для генерации случайных чисел
    /// </summary>
    /// <returns>Возвращает <c>true</c>, если диапазон корректен
    /// (максимальное значение больше минимального), иначе <c>false</c>
    /// </returns>
    bool Validate();
}