

namespace LAB4
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void DisplayPlayerStats(string userName)
        {
            var player = _playerRepository.GetPlayerByName(userName);
            if (player != null) player.GetStats();
            else Console.WriteLine($"Player {userName} not found.");
        }
        
        public void UpdatePlayerName(string oldUserName, string newUserName)
        {
            _playerRepository.UpdatePlayerName(oldUserName, newUserName);
        }
        
       public void CreatePlayer(string userName, string accountType)
        {
            GameAccount newPlayer ;

            
            switch (accountType)
            {
                case "standard":
                    newPlayer = new StandardAccount(userName);
                    break;
                case "doubleRating":
                    newPlayer = new DoubleRating(userName);
                    break;
                default:
                    Console.WriteLine("Invalid account type.");
                    return;
            }

            _playerRepository.AddPlayer(newPlayer);  
        }
       
       public void DeletePlayer(string userName)
        {
            _playerRepository.DeletePlayer(userName);
        }
       
       public void GetAllPlayers()
        {
            
            foreach (var player in  _playerRepository.GetAllPlayers())
            {
                Console.WriteLine(player.UserName);
            }
        }

    }
}