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
            string choice = Console.ReadLine();
            GetUserInput();
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
            Room Entrance = new Room("Entrance", "This is just the beginning");
            Room DeathTrap = new Room("Pit of Death", "It was dark, you fell, you died. Type 'start over' to play again!");
            Room East1 = new Room("East 1", "You found an open door! Look around to find something useful");
            Room East2 = new Room("East 3", "This room definitely has a locked door");
            Room GameOver = new Room("Exit room", "Yay, you won this incredibly simple game!");

            Item key = new Item("key", "Metal that unlocks a door!");


            Entrance.Exits.Add("east", East1);
            Entrance.Exits.Add("south", DeathTrap);
            East1.Exits.Add("west", Entrance);
            East1.Exits.Add("east", East2);
            East2.Exits.Add("west", East1);
            East2.Exits.Add("east", GameOver);

            East1.Items.Add(key);

            CurrentRoom = Entrance;
        }

        public void StartGame()
        {
            Setup();
            Console.WriteLine("Welcome to QUEST TOWN! Your only mission: Escape.")
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