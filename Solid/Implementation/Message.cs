using Solid.interfaces;

namespace Solid.Implementation
{
    public class Messages : IMessages
    {
       public string EnterMinNumber => "Укажите минимальное число: ";
       public string EnterMaxNumber => "Укажите максимальное число: ";
       public string EnterAttemptsCount => "Укажите число попыток: ";
       public string EnterGuessNumber => "Укажите искомое число: ";
       public string NotANumber => "Введенное значение не является числом, повторите попытку";
       public string Victory => "Ура, вы победили!!!";
       public string Loss => "Вы проиграли!";
       public string InvalidRange => "Минимальное число должно быть меньше максимального. Повторите попытку.";
       public string IfMore => "Искомое значение больше, попробуйте ещё раз...";
       public string IfLess => "Искомое значение меньше, попробуйте ещё раз...";
       public string GetCountToLossMessage(int count) => $"Осталось попыток: {count}";

    }
}