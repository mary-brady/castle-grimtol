using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public string PlayerName { get; set; }
        public List<Item> Inventory { get; set; }

        // public void GiveItem(Item item)
        // {

        // }

        public Player(string name)
        {
            PlayerName = name;
            Inventory = new List<Item>();
        }

    }
}