using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void seeItems()
        {
            System.Console.WriteLine($"You have a {Name}, {Description} in your inventory");
        }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;

        }

    }

}