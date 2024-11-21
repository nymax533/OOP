namespace LAB2
{
    public class TrainingGame : Game
    {
        public TrainingGame(string winner, string loser, int rating, int gameId, bool isWin) : base(winner, loser, rating, gameId, isWin)
        {
            
        }
        public override int CalculateRatingChange()
        {
          return  0;
        }
    }
}