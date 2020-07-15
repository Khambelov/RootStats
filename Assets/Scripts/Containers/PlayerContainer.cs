using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RootStats.Core.Containers
{
    [CreateAssetMenu(fileName = "NewPlayerContainer", menuName = "Containers/PlayerContainer", order = 0)]
    public class PlayerContainer : Container<Player>
    {
        public List<Player> Players => items;

        public override Player GetItem(int id)
        {
            return items.Find(i => i.PlayerId == id);
        }

        public int GetIdForNewPlayer
        {
            get
            {
                var playerWithMaxId = items.OrderByDescending(i => i.PlayerId).FirstOrDefault();

                return playerWithMaxId?.PlayerId + 1 ?? 0;
            }
        }
    }
}