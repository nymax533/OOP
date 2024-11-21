using System;
using System.Collections.Generic;

namespace LAB2
{
    
    public  class GameAccount
    {
        public string UserName { get; }

        protected int CurrentRating
        {
            get => _currentRating;
            
            set
            {
                if (value < 0)
                {
                    _currentRating = 1;
                }
                else
                {
                   _currentRating = value;
                }
            }
        }
        
        private int _currentRating;

        protected List<Game> GameHistory  = new List<Game>();

        protected GameAccount(string userName)
        {
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

        

        public virtual void GetStats()
        {
            Console.WriteLine($"Player statistics for {UserName}:");
            Console.WriteLine($"Current rating: {CurrentRating}");
            Console.WriteLine("Game history:");
            foreach (var game in GameHistory)
            {
                string result = game.IsWin ? "Win" : "Loss";
                Console.WriteLine($" - Game ID: {game.GameId}, Opponent: {game.OpponentName}, Winner: {game.WinnerName},Result: {result}, Rating change: {game.CalculateRatingChange()}");
            }
            Console.WriteLine();
        }

    }
}