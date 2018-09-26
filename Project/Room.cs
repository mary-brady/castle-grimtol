using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, IRoom> Exits { get; set; }

        public void addItem(Item item)
        {
            Items.Add(item);
        }

        public void removeItem(string itemName)
        {
            Items.RemoveAll(i => i.Name == "key");
        }
    }
}