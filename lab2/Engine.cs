using System;

namespace LAB2
{
      public static class Engine
    {
        public static void PlayGame(GameAccount player1,GameAccount player2, int rating ,bool isWin,string gameType)
        {
            if (isWin)
            {
                var (winnerGame, loserGame) = GameFactory.CreateGame(gameType, player1, player2, rating, isWin);
                player1.WinGame(winnerGame);
                player2.LoseGame(loserGame);
            }
            else
            {
                var (winnerGame, loserGame) = GameFactory.CreateGame(gameType, player2, player1, rating, !isWin);
                player1.LoseGame(loserGame);
                player2.WinGame(winnerGame);
            }
        }
    }
}

