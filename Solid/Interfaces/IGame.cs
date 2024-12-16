namespace Solid.interfaces
{
    public interface IGame
    {
        /// <summary>
        /// Запускает игру, используя заданную игровую логику
        /// </summary>
        /// <param name="gameLogic">Логика игры, которая управляет состоянием игры</param>
        void Run(IGameLogic gameLogic);

        /// <summary>
        /// Подготавливает логику игры, запрашивая количество попыток и создавая генератор случайных чисел
        /// </summary>
        /// <returns>Экземпляр <see cref="IGameLogic"/> с установленными параметрами игры</returns>
        IGameLogic PrepareGameLogic();
    }
}