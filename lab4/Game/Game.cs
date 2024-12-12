
namespace LAB4
{
    public abstract class Game
    {
        public int GameId { get; set; }
        public string OpponentName { get; }
        public string WinnerName { get; }
        protected int Rating { get; }
        public bool IsWin { get; }

        protected Game(string opponentName, string winner, int gameId, bool isWin)
        {
            
            OpponentName = opponentName;
            WinnerName = winner;
            Rating = 20;
            GameId = gameId;
            IsWin = isWin;
        }

        public abstract int CalculateRatingChange();
    }

    public class StandardGame : Game
    {
        public StandardGame(string opponentName, string winner, int gameId, bool isWin)
            : base(opponentName, winner,  gameId, isWin) { }

        public override int CalculateRatingChange()
        {
            return Rating;
        }
    }

    public class TrainingGame : Game
    {
        public TrainingGame(string opponentName, string winner,  int gameId, bool isWin)
            : base(opponentName, winner,  gameId, isWin) { }

        public override int CalculateRatingChange()
        {
            return 0; 
        }
    }
}