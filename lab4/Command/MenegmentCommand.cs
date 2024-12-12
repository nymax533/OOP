namespace LAB4;

public class MenegmentCommand
{
    private readonly List<ICommand> _commands;

    public MenegmentCommand()
    {
        _commands = new List<ICommand>();
    }

    public void RegisterCommand(ICommand command)
    {
        _commands.Add(command);
    }

    public void ShowMenu()
    {
        Console.WriteLine("Available commands:");
        for (int i = 0; i < _commands.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_commands[i].GetDescription()}");
        }
    }

    public void ExecuteCommand(int index)
    {
        if (index < 1 || index > _commands.Count)
        {
            Console.WriteLine("Invalid command!");
            return;
        }

        _commands[index - 1].Execute();
    }
 
   
}
