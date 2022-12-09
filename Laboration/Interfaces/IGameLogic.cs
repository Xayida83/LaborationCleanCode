namespace Laboration.Interfaces
{
    public interface IGameLogic
    {
        string GenerateGoalNumber();
        string CheckBC(string goal, string guess);
    }
}
