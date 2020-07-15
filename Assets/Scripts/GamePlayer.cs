using System;

namespace RootStats.Core
{
    [Serializable]
    public class GamePlayer
    {
        public int PlayerId { get; set; }
        public int FactionId { get; set; }
        public bool IsWinner { get; set; }
        public bool ByVictoryPoint { get; set; }
        public bool ByDominance { get; set; }

        public GamePlayer(int playerId, int factionId, bool isWinner, bool byVictoryPoint, bool byDominance)
        {
            PlayerId = playerId;
            FactionId = factionId;
            IsWinner = isWinner;
            ByVictoryPoint = byVictoryPoint;
            ByDominance = byDominance;
        }
    }
}