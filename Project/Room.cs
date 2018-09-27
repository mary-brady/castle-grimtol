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

        public void ChangeRoom()
        {

        }
        public void removeItem(string itemName)
        {
            Items.RemoveAll(i => i.Name == "key");
        }
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Exits = new Dictionary<string, IRoom>();
            Items = new List<Item>();
        }
    }
}