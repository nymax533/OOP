namespace LAB4
{
    public static class GameFactory
    {
        private static int gameId;

        public static (Game WinnerGame, Game LoserGame) CreateGame(string gameType, GameAccount winner, GameAccount loser, bool isWin)
        {
            return gameType switch
            {
                "Standard" => (
                    new StandardGame(loser.UserName, winner.UserName, ++gameId, isWin),
                    new StandardGame(winner.UserName, loser.UserName, gameId, !isWin)
                ),
                "Training" => (
                    new TrainingGame(loser.UserName, winner.UserName, ++gameId, isWin),
                    new TrainingGame(winner.UserName, loser.UserName, gameId, !isWin)
                ),
                _ => throw new ArgumentException("Invalid game type")
            };
        }
    }
}