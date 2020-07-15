using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RootStats.Core.Containers
{
    [CreateAssetMenu(fileName = "NewFactionContainer", menuName = "Containers/FactionContainer", order = 0)]
    public class FactionContainer : Container<Faction>
    {
        public List<Faction> Factions => items;
        
        public override Faction GetItem(int id)
        {
            return items.Find(i => i.FactionId == id);
        }
        
        public int GetIdForNewFaction
        {
            get
            {
                var playerWithMaxId = items.OrderByDescending(i => i.FactionId).FirstOrDefault();

                return playerWithMaxId?.FactionId + 1 ?? 0;
            }
        }
    }
}