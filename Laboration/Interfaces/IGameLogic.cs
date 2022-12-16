namespace Laboration.Interfaces
{
    public interface IGameLogic
    {
        string GenerateGoalNumber();
        string CheckBullsAndCows(string goal, string guess);
        bool ContinueGame(int numberOfGuesses);

    }
}
