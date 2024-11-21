namespace LAB2
{
    public class StandardGame : Game
    {

        public  StandardGame(string winner, string loser, int rating, int gameId,bool isWin) : base(winner, loser, rating, gameId,isWin)
        {
           
        }
        
        public override int CalculateRatingChange()
        {
            return Rating;
        }
    }
}