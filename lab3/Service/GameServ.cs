

namespace LAB4
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;

        public GameService(IGameRepository gameRepository, IPlayerRepository playerRepository)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
        }

        public void PlayGame(string player1Name, string player2Name, bool isWin, string gameType)
        {
            var player1 = _playerRepository.GetPlayerByName(player1Name);
            var player2 = _playerRepository.GetPlayerByName(player2Name);

           

            var (winnerGame, loserGame) = GameFactory.CreateGame(gameType, player1, player2, isWin);
            player1.WinGame(winnerGame);
            player2.LoseGame(loserGame);

            _gameRepository.AddGame(winnerGame);
            _gameRepository.AddGame(loserGame);
        }
        
     
        public void GetAllGames()
        {
            var uniqueGames = _gameRepository.GetAllGames()
                .GroupBy(game => game.GameId)
                .Select(group => group.First());
            Console.WriteLine("All Games:");
            
            foreach (var game in uniqueGames)
            {
                
                Console.WriteLine($"Game ID: {game.GameId},  {game.WinnerName} vs {game.OpponentName}");
                
                
            }
         
        }
        
        public void DeleteGame(int gameId)
        {
            _gameRepository.DeleteGame(gameId);
        }
        
    }
}