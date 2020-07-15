using System;
using UnityEngine;

namespace RootStats.Core
{
    [Serializable]
    public class Faction
    {
        public int FactionId { get; set; }
        public string FactionName { get; set; }
        public Sprite FactionIcon { get; set; }
        public Sprite[] FactionPhotos { get; set; }

        public Faction(int id, string name, Sprite icon, Sprite[] photos)
        {
            FactionId = id;
            FactionName = name;
            FactionIcon = icon;
            FactionPhotos = photos;
        }
    }
}