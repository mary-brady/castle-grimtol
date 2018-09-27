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
                        Go(direction);
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
            if (direction = CurrentRoom.Exits)
            {

            }
        }

        public void Help()
        {

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
            Console.WriteLine($"You are in {CurrentRoom}, {CurrentRoom.Description}");
            Console.ReadLine() = GetUserInput();

        }

        public void Quit()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            Game game = new Game();
        }

        public void Setup()
        {
            Room Entrance = new Room("Entrance", "This is just the beginning");
            Room DeathTrap = new Room("Pit of Death", "It was dark, you fell, you died. Start over?");
            Room East1 = new Room("East 1", "You found an open door! Look around to find something useful");
            Room East2 = new Room("East 3", "This room definitely has a locked door");
            Room GameOver = new Room("Exit room", "Yay, you won this incredibly simple game!");

            Item key = new Item("key", "Metal that unlocks a door!");


            Entrance.Exits.Add("east", East1);
            East1.Exits.Add("east", East2);
            East2.Exits.Add("east", GameOver);

            East1.Items.Add(key);

            CurrentRoom = Entrance;
        }

        public void StartGame()
        {
            Game game = new Game();
        }

        public void TakeItem(string itemName)
        {
            Item item = CurrentRoom.Items.Find(i => i.Name == itemName);
            if (item != null)
            {
                CurrentPlayer.Inventory.Add(item);
                CurrentRoom.Items.Remove(item);
                return;
            }
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