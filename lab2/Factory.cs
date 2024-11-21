using System;

namespace LAB2
{
    public static class GameFactory
    {
        private static int gameId ;
        public static (Game WinnerGame, Game LoserGame) CreateGame(string gameType, GameAccount winner, GameAccount loser, int rating, bool isWin)
        {
            return gameType switch
            {
                "Standard" => (
                    new StandardGame(loser.UserName, winner.UserName, rating, ++gameId, isWin),  
                    new StandardGame(winner.UserName, winner.UserName, rating, gameId,!isWin)  
                ),
                "Training" => (
                    new TrainingGame(loser.UserName, winner.UserName, rating, ++gameId, isWin),         
                    new TrainingGame(winner.UserName, winner.UserName,rating,gameId,!isWin)          
                ),
                _ => throw new ArgumentException("Invalid game type")
            };
        }
    }
}