

namespace LAB4
{
    public interface IGameService
    {
        void PlayGame(string player1, string player2,  bool isWin, string gameType);
           
        void ShowAllGames();
        void DeleteGame(int gameId);
        
       
    }
}