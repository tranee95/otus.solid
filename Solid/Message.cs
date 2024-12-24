namespace Solid;

public static class Messages
{
    public static string EnterMinNumber => "Укажите минимальное число: ";
    public static string EnterMaxNumber => "Укажите максимальное число: ";
    public static string EnterAttemptsCount => "Укажите число попыток: ";
    public static string EnterGuessNumber => "Укажите искомое число: ";
    public static string NotANumber => "Введенное значение не является числом, повторите попытку";
    public static string Victory => "Ура, вы победили!!!";
    public static string Loss => "Вы проиграли!";
    public static string InvalidRange => "Минимальное число должно быть меньше максимального. Повторите попытку.";
    public static string IfMore => "Искомое значение больше, попробуйте ещё раз...";
    public static string IfLess => "Искомое значение меньше, попробуйте ещё раз...";
    public static string GetCountToLossMessage(int count) => $"Осталось попыток: {count}";
}