
namespace LAB4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dbContext = new DbContext();
            var playerRepo = new PlayerRepository(dbContext);
            var gameRepo = new GameRepository(dbContext);
            
            
            var playerService = new PlayerService(playerRepo);
            var gameService = new GameService(gameRepo, playerRepo);
            
            playerService.CreatePlayer("Player1", "standard");
            playerService.CreatePlayer("Player2", "doubleRating");
            playerService.CreatePlayer("Player3", "standard");
            
            

            Console.WriteLine("Game System:");

            
            gameService.PlayGame("Player1", "Player2",  true, "Standard");
            gameService.PlayGame("Player3", "Player2",  false, "Training");

            
            playerService.DisplayPlayerStats("Player1");
            playerService.DisplayPlayerStats("Player2");
            playerService.DisplayPlayerStats("Player3");
            
              playerService.DeletePlayer("Player1");
          //  gameService.DeleteGame(2);

            gameService.GetAllGames();
            
            
            
            Console.WriteLine("All Players:");
            playerService.GetAllPlayers();
            
            playerService.UpdatePlayerName("Player2", "Player4");
            
            Console.WriteLine("All Players:");
            playerService.GetAllPlayers();
            
            

        }
    }
}