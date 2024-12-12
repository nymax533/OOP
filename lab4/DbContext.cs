

namespace LAB4
{
    public class DbContext
    {
        public List<GameAccount> Players { get; set; } = new List<GameAccount>();
        public List<Game> Games { get; set; } = new List<Game>();

        public DbContext()
        {
            
        }
    }
}