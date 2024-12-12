namespace LAB4;

public class ShowPlayerCommand : ICommand
{
    private readonly IPlayerService _playerService;
    
    public ShowPlayerCommand(IPlayerService playerService)
    {
        _playerService = playerService;
    }
    
    public void Execute()
    {
        Console.Write("Enter player name to view stats: ");
        string player = Console.ReadLine();
        _playerService.DisplayPlayerStats(player);
    }
    
    public string GetDescription() => "Show player stats";
    
}