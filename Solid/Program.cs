using Solid.Implementation;

namespace Solid;

class Program
{
    public static void Main(string[] args)
    {
        var randomGenerator = CreateDefaultRandomGenerator(); 

        var attemptsCount = GetNumberAtConsoleMenu("Укажите число попыток: ");
        var findNumber = new FindNumberGame(attemptsCount, randomGenerator);

        while (findNumber.IsHasAttempts())
        {
            Console.WriteLine($"Осталось попыток: {findNumber.GetAttemptsCount()}");
            var number = GetNumberAtConsoleMenu("Укажите исклмое число число: ");
            var isEquals = findNumber.Find(number);

            if (isEquals)
            {
                Console.WriteLine("Урра вы победили!!!");
                break;
            }

            if (findNumber.IsHasAttempts()) continue;

            Console.WriteLine("Вы проиграли!");
            break;
        }

        Console.ReadLine();
    }

    /// <summary>
    /// Запрашивает у пользователя ввод числа через консоль и проверяет корректность ввода
    /// </summary>
    /// <param name="consoleMessage">Сообщение, которое будет отображено пользователю перед вводом числа</param>
    /// <returns>Введенное пользователем целое число</returns>
    private static int GetNumberAtConsoleMenu(string consoleMessage)
    {
        Console.Write(consoleMessage);
        int number;
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Введеное значение не является числом");
        }
        return number;
    }

    /// <summary>
    /// Создает новый экземпляр генератора случайных чисел с заданным диапазоном.
    /// </summary>
    /// <returns>Экземпляр <see cref="RandomGenerator"/> с заданными минимальным и максимальным значениями</returns>
    private static RandomGenerator CreateDefaultRandomGenerator()
    {
        var min = GetNumberAtConsoleMenu("Укажите минимальное число: ");
        var max = GetNumberAtConsoleMenu("Укажите максимальное число: ");

        var random = new RandomGenerator(min, max);
        if (!random.Validate())
        {
            Console.WriteLine("Введеное значение не является числом, повторите попытку");
            random = CreateDefaultRandomGenerator();
        }

        return random;
    }
}