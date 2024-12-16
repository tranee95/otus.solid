namespace Solid.interfaces
{
    public interface IMessages
    {
        string EnterMinNumber { get; }
        string EnterMaxNumber { get; }
        string EnterAttemptsCount { get; }
        string EnterGuessNumber { get; }
        string NotANumber { get; }
        string Victory { get; }
        string Loss { get; }
        string InvalidRange { get; }
        string IfMore { get; }
        string IfLess { get; }
        string GetCountToLossMessage(int count);
    }
}