

namespace LAB4
{
    public abstract class GameAccount
    {
        public string UserName { get; set; }
        
        public static int Id=0;
        
        public int CurrentRating
        {
            get => _currentRating;
            set => _currentRating = value < 0 ? 1 : value;
        }
        private int _currentRating;

        protected List<Game> GameHistory = new List<Game>();

        protected GameAccount(string userName)
        {
            Id++;
            UserName = userName;
            CurrentRating = 10; 
        }

        public virtual void WinGame(Game game)
        {
            GameHistory.Add(game);
            CurrentRating += game.CalculateRatingChange();
        }

        public virtual void LoseGame(Game game)
        {
            GameHistory.Add(game);
            CurrentRating -= game.CalculateRatingChange();
        }

        public  void GetStats()
        {
            Console.WriteLine($"Player statistics for {UserName}:");
            Console.WriteLine($"Current rating: {CurrentRating}");
            Console.WriteLine("Game history:");
            foreach (var game in GameHistory)
            {
                string result = game.IsWin ? "Win" : "Loss";
                Console.WriteLine($" - Game ID: {game.GameId}, Opponent: {game.OpponentName}, Winner: {game.WinnerName}, Result: {result}, Rating change: {game.CalculateRatingChange()}");
            }
            Console.WriteLine();
        }
    }

    public class StandardAccount : GameAccount
    {
        public StandardAccount(string userName) : base(userName) { }
    }

    public class DoubleRating : GameAccount
    {
        public DoubleRating(string userName) : base(userName) { }

        public override void WinGame(Game game)
        {
            CurrentRating += game.CalculateRatingChange() * 2;
            GameHistory.Add(game);
        }

        public override void LoseGame(Game game)
        {
            CurrentRating -= game.CalculateRatingChange() * 2;
            GameHistory.Add(game);
        }
    }
}
