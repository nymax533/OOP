
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
            
          
            var commandMenu = new MenegmentCommand();
            commandMenu.RegisterCommand(new ShowPlayerCommand(playerService));
            commandMenu.RegisterCommand(new AddPlayerCommand(playerService));
            commandMenu.RegisterCommand(new ShowAllPlayersCommand(playerService));
            commandMenu.RegisterCommand(new PlayGameCommand(gameService));

            while (true)
            {
                Console.WriteLine("---- Main Menu ----");
                commandMenu.ShowMenu();
                Console.WriteLine("\nEnter 0 to exit:");
                
                int commandNumber = int.Parse(Console.ReadLine());
                
                if (commandNumber == 0)
                {
                    return ;
                }
                
                commandMenu.ExecuteCommand(commandNumber);

                
            }
        }
    }
}