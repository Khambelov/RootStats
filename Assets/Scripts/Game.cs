using System;

namespace RootStats.Core
{
    [Serializable]
    public class Game
    {
        public int GameId { get; set; }
        public string GameDate { get; set; }
        public GamePlayer[] GamePlayers { get; set; }

        public Game(int id, DateTime date, GamePlayer[] gamePlayers)
        {
            GameId = id;
            GameDate = date.ToString("dd.MM.yyyy");
            GamePlayers = gamePlayers;
        }
    }
}