using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        public void GetUserInput()
        {
            throw new System.NotImplementedException();
        }

        public void Go(string direction)
        {
            throw new System.NotImplementedException();
        }

        public void Help()
        {
            throw new System.NotImplementedException();
        }

        public void Inventory()
        {
            throw new System.NotImplementedException();
        }

        public void Look()
        {
            throw new System.NotImplementedException();
        }

        public void Quit()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public void Setup()
        {
            throw new System.NotImplementedException();
        }

        public void StartGame()
        {
            throw new System.NotImplementedException();
        }

        public void TakeItem(string itemName)
        {
            //make sure the item exists in the Current room
            Item item = CurrentRoom.Items.Find(i => i.Name == itemName);
            if (item != null)
            {
                CurrentPlayer.Inventory.Add(item);
                CurrentRoom.Items.Remove(item);
                return;
            }

            //find an item from a List C#
            //if found add to currentplayer inventory and remove from room
        }

        public void UseItem(string itemName)
        {
            CurrentPlayer.useItem(itemName);
        }
    }
}