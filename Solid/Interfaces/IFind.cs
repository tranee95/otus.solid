namespace Solid.interfaces;

public interface IFind
{
    /// <summary>
    /// Проверяет, угадал ли игрок искомое число
    /// </summary>
    /// <param name="findNumber">Число, введенное игроком для проверки</param>
    /// <returns>Возвращает <c>true</c>, если число угадано, иначе <c>false</c></returns>
    bool Find(int findNumber);

    /// <summary>
    /// Проверяет, остались ли у игрока попытки
    /// </summary>
    /// <returns>Возвращает <c>true</c>, если попытки остались, иначе <c>false</c></returns>
    bool IsHasAttempts();

    /// <summary>
    /// Возвращает количество оставшихся попыток
    /// </summary>
    /// <returns>Количество оставшихся попыток</returns>
    int GetAttemptsCount();
}