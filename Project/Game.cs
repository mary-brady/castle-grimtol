using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        public void GetUserInput()
        {
            string UserInput = Console.ReadLine();
            if (Int32.TryParse(UserInput, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Go();
                        break;
                    case 2:
                        TakeItem();
                        break;
                    case 3:
                        UseItem();
                        break;
                    case 4:
                        Look();
                        break;
                    case 5:
                        Inventory();
                        break;
                    case 6:
                        Help();
                        break;
                    case 7:
                        Quit();
                        break;
                    case 8:
                        Reset();
                        break;

                }
            }
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

            for (int i = 0; i < CurrentPlayer.Inventory.Count; i++)
            {
                Console.WriteLine($"You have a {CurrentPlayer.Inventory[i].Name} in your inventory");
            }
            string choice = Console.ReadLine();
            GetUserInput();
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
            Room Entrance = new Room("Entrance", "This is just the beginning");
            Room DeathTrap = new Room("Pit of Death", "It was dark, you fell, you died. Start over?");
            Room East1 = new Room("East 1", "You found an open door! Look around to find something useful");
            Room East2 = new Room("East 3", "This room definitely has a locked door");
            Room GameOver = new Room("Exit room", "Yay, you won this incredibly simple game!");
            Item key = new Item("key", "Metal that unlocks a door!");

            Entrance.Exits.Add("Entrance", East1);
            Entrance.Exits.Add("East1", East2);
            Entrance.Exits.Add("East2", GameOver);

            East1.Items.Add(key);
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
            Item item = CurrentPlayer.Inventory.Find(i => i.Name == itemName);

            if (item != null)
            {
                CurrentPlayer.Inventory.Remove(item);
            }

        }
    }
}