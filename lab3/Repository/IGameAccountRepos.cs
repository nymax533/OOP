
namespace LAB4
{
    public interface IPlayerRepository
    {
        void AddPlayer(GameAccount player);
        GameAccount GetPlayerByName(string userName);
        List<GameAccount> GetAllPlayers();
        
        void UpdatePlayerName(string oldUserName, string newUserName);
        
        void DeletePlayer(string userName);
        
     
    }
}