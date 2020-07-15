using System;
using UnityEngine;

namespace RootStats.Core
{
    [Serializable]
    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public Sprite PlayerPhoto { get; set; }

        public Player(int id, string name, Sprite photo)
        {
            PlayerId = id;
            PlayerName = name;
            PlayerPhoto = photo;
        }
    }
}