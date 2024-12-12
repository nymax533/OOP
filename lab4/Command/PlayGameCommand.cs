namespace LAB4;

public class PlayGameCommand : ICommand
{
    private readonly IGameService _gameService;
    
    public PlayGameCommand(IGameService gameService)
    {
        _gameService = gameService;
    }
    public void Execute()
    {
        try
        {
            Console.Write("Enter winner: ");
            string winner = Console.ReadLine();

            Console.Write("Enter loser: ");
            string loser = Console.ReadLine();

            Console.WriteLine("Enter game type Standard or Training): ");
            string gameType = Console.ReadLine();

            _gameService.PlayGame(winner, loser, true, gameType);
                
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    
    public string GetDescription() => "Game add ";
}