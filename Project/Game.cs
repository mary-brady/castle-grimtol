using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        private bool playing;
        public IRoom CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        public void GetUserInput()
        {

            string userInput = Console.ReadLine();
            switch (userInput.ToLower())
            {
                case "go north":
                    Go("north");
                    break;
                case "go south":
                    Go("south");
                    break;
                case "go west":
                    Go("west");
                    break;
                case "go east":
                    Go("east");
                    break;
                case "use key":
                    UseItem("key");
                    break;
                case "take key":
                    TakeItem("key");
                    break;
                case "help":
                    Help();
                    break;
                case "look":
                    Look();
                    break;
                case "inventory":
                    Inventory();
                    break;
                case "quit":
                    Quit();
                    break;
                case "reset":
                    Reset();
                    break;
                case "start game":
                    StartGame();
                    break;
                case "start over":
                    StartGame();
                    break;

            }
        }
        public void Go(string direction)
        {
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                CurrentRoom = CurrentRoom.Exits[direction];
                Look();
                return;
            }
            else
            {
                Console.WriteLine("You've run into a wall...maybe try a different direction");
            }
        }

        public void Help()
        {
            Console.WriteLine($@"
1. Type 'Go' and one of four directions ('east', 'west', 'north', 'south'),
2. Type 'Look' to get a description of your location,
3. Type 'Use' plus the item name to use your items,
4. Type 'Take' to take the item
5. Type 'Reset' to reset the game,
6. Type 'Quit' to quit the game");
        }

        public void Inventory()
        {

            for (int i = 0; i < CurrentPlayer.Inventory.Count; i++)
            {
                Console.WriteLine($"You have a {CurrentPlayer.Inventory[i].Name} in your inventory");
            }
        }

        public void Look()
        {
            Console.WriteLine($"You are in {CurrentRoom}, {CurrentRoom.Description}");
        }

        public void Quit()
        {
            playing = false;
        }

        public void Reset()
        {
            Setup();
        }

        public void Setup()
        {
            Room Entrance = new Room("Entrance", "This is just the beginning...type 'Help' to see what you can do.");
            Room DeathTrap = new Room("Pit o' Spikey Death", "It was dark, you fell, you died. On spikes! Type 'start over' to play again!");
            Room Easty = new Room("East 1", "You've entered the next room...You scan the room and find a small object in the corner. After you've pick it up, you realize it's key. That should come in handy.");
            Room Eastier = new Room("East 3", "This room definitely has a locked door. Didn't you pick something up in the last room to open it?");
            Room Eastiest = new Room("Exit room", "Yay, you won this incredibly simple game!");

            Item key = new Item("key", "Metal that unlocks a door!");


            Entrance.Exits.Add("east", Easty);
            Entrance.Exits.Add("south", DeathTrap);
            Easty.Exits.Add("west", Entrance);
            Easty.Exits.Add("east", Eastier);
            Eastier.Exits.Add("west", Easty);
            Eastier.Exits.Add("east", Eastiest);

            Easty.Items.Add(key);

            CurrentRoom = Entrance;
        }

        public void StartGame()
        {
            Setup();
            Console.WriteLine("Welcome to QUEST TOWN! Your only mission: Escape.");
            while (playing)
            {
                GetUserInput();
            }
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