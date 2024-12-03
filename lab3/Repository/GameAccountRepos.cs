
namespace LAB4
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DbContext _context;

        public PlayerRepository(DbContext context)
        {
            _context = context;
        }

        public void AddPlayer(GameAccount player)
        {
            _context.Players.Add(player);
            
        }

        public GameAccount GetPlayerByName(string userName)
        {
            return _context.Players.FirstOrDefault(p => p.UserName == userName);
        }
        
       
          
        public void UpdatePlayerName(string oldUserName, string newUserName)
        {
            var player = _context.Players.FirstOrDefault(p => p.UserName == oldUserName);
            if (player != null)
            {
                player.UserName = newUserName;  
            }
        }
        
        public void DeletePlayer(string userName)
        {
            
            
            foreach (var game in _context.Players)
            {
                if (game.UserName == userName)
                {
                    _context.Players.Remove(game);
                    break;
                }
            }
            
        }


        public List<GameAccount> GetAllPlayers()  
        {
            return _context.Players; 
        }
    }
}