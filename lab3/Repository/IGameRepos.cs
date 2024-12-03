
namespace LAB4
{
    public interface IGameRepository
    {
        void AddGame(Game game);
        List<Game> GetAllGames();
        
        void DeleteGame(int gameId);
        
    }
}