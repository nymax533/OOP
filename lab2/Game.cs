using System;

namespace LAB2
{
    
    public abstract class Game
    {
        public int GameId { get;  }
        public string OpponentName { get; }
        public string WinnerName { get; }
        
        
        protected int Rating { get; set; }
        
        public bool IsWin { get; }
        public abstract int CalculateRatingChange();

        protected Game(string opponentName,string winner,int rating,int gameId,bool isWin)
        {
            if (rating < 0)
            {
                throw new ArgumentException("Rating cannot be negative");
            }

            Rating = rating;
            GameId = gameId;
            OpponentName = opponentName;
            WinnerName = winner;
            IsWin = isWin;
        }
    }
}