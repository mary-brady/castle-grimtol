using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public string PlayerName { get; set; }
        public List<Item> Inventory { get; set; }

        public void TakeItem(string itemName)
        {
            Inventory.Add(new Item("key", "A key, which definitely unlocks a door."));
        }

        public void useItem(string itemName)
        {
            Inventory.RemoveAll(r => r.Name == "key");
        }
    }
}