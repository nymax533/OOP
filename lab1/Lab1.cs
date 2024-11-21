 namespace LAB1
 {
     public class Game
     {
         public Guid GameId { get; }
         public string OpponentName { get; }
         public string WinnerName { get; }
         public bool IsWin { get; }
         public int RatingChange { get; }

         public Game(Guid gameId, string opponentName, string winnerName, bool isWin, int ratingChange)
         {
             GameId = gameId;
             OpponentName = opponentName;
             WinnerName = winnerName;
             IsWin = isWin;
             RatingChange = ratingChange;
         }
     }

     public class GameAccount
     {
         public string UserName { get; }
         public int CurrentRating { get; private set; }
         public int GamesCount { get; private set; }

         private List<Game> gameHistory;

         public GameAccount(string userName)
         {
             UserName = userName;
             CurrentRating = 20;
             GamesCount = 0;
             gameHistory = new List<Game>();
         }

         private void WinGame(GameAccount opponent, int rating)
         {
             CurrentRating += rating;
             opponent.CurrentRating -= rating;
         }

         private void LoseGame(GameAccount opponent, int rating)
         {
             opponent.CurrentRating += rating;
             CurrentRating -= rating;
         }

         public void PlayGame(GameAccount opponent, int rating, bool isWin)
         {
             if (rating < 0)
             {
                 throw new ArgumentException("Rating change cannot be negative.");
             }

             if (isWin)
             {
                 WinGame(opponent, rating);
             }
             else
             {
                 LoseGame(opponent, rating);
             }

             opponent.CurrentRating = opponent.CurrentRating < 0 ? 1 : opponent.CurrentRating;
             CurrentRating = CurrentRating < 0 ? 1 : CurrentRating;

             Guid gameId = Guid.NewGuid();

             Game gameForWinner = new Game(gameId, opponent.UserName, UserName, true, rating);
             Game gameForLoser = new Game(gameId, UserName, UserName, false, rating);

             gameHistory.Add(gameForWinner);
             opponent.gameHistory.Add(gameForLoser);
         }

         public void GetStats()
         {
             Console.WriteLine($"Stats for {UserName} (Current Rating: {CurrentRating}):");
             Console.WriteLine(
                 "------------------------------------------------------------------------------------------");
             Console.WriteLine(
                 "Opponent        Winner          Result    Rating Change   GameId                              ");
             Console.WriteLine(
                 "------------------------------------------------------------------------------------------");

             foreach (var game in gameHistory)
             {
                 string result = game.IsWin ? "Win" : "Loss";
                 Console.WriteLine(game.OpponentName + "          " + game.WinnerName + "          " + result +
                                   "     " + game.RatingChange + "              " + game.GameId);
             }

             Console.WriteLine(
                 "------------------------------------------------------------------------------------------");
         }
     }

     public class Program
     {
         public static void Main(string[] args)
         {
             GameAccount player1 = new GameAccount("Player1");
             GameAccount player2 = new GameAccount("Player2");
             GameAccount player3 = new GameAccount("Player3");

             player1.PlayGame(player2, 5, true);
             player3.PlayGame(player1, 10, false);
             player1.PlayGame(player3, 15, true);
             player2.PlayGame(player3, 20, false);
             player3.PlayGame(player2, 25, true);

             player1.GetStats();
             player2.GetStats();
             player3.GetStats();
         }
     }
 }