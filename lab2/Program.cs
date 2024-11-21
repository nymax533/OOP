using System;

namespace LAB2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            GameAccount player1 = new StandardAccount("Player1");
            GameAccount player2 = new StandardAccount("Player2");
            GameAccount player3 = new DoubleRating("Player3");

            Engine.PlayGame(player1, player2, 10, true, "Standard");
            Engine.PlayGame(player1, player2, 10, true, "Training");
            Engine.PlayGame(player1, player2, 10, false, "Standard");
            Engine.PlayGame(player3, player2, 10, true, "Standard");
            Engine.PlayGame(player2,player1,60,false,"Standard");
         
            
            player1.GetStats();
            player2.GetStats();
            player3.GetStats();
        }
    }
}