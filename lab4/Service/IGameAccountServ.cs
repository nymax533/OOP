

namespace LAB4
{
    public interface IPlayerService
    {
        void DisplayPlayerStats(string userName);
        void UpdatePlayerName(string oldUserName, string newUserName);
        void CreatePlayer(string userName, string accountType); 
        void DeletePlayer(string userName);
        void ShowAllPlayers();

    }
}