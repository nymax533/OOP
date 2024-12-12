namespace LAB4;

public class ShowAllPlayersCommand: ICommand
{
    private readonly IPlayerService _playerService;
    
    public ShowAllPlayersCommand(IPlayerService playerService)
    {
        _playerService = playerService;
    }
    
    public void Execute()
    {
        Console.WriteLine("All Players:");
        _playerService.ShowAllPlayers();
    }
    
    public string GetDescription() => "Show all players";
}