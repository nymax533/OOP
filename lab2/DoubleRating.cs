namespace LAB2
{
    
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
        
        public override void GetStats()
        {
            Console.WriteLine($"Player statistics for {UserName}:");
            Console.WriteLine($"Current rating: {CurrentRating}");
            Console.WriteLine("Game history:");

            foreach (var game in GameHistory)
            {
                string result = game.IsWin ? "Win" : "Loss";
                Console.WriteLine($" - Game ID: {game.GameId}, Opponent: {game.OpponentName}, Winner: {game.WinnerName}, Result: {result}, Rating change: {game.CalculateRatingChange()*2}");
            }

            Console.WriteLine();
        }
    }
    
}