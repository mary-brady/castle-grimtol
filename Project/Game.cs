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
            Console.WriteLine("What are you gunna do?");
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
                default:
                    Console.WriteLine("I don't recognize that command?");
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
            if (CurrentRoom.Name == "Eastier")
            {
                Console.WriteLine("This door is locked. Try using your key?");
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
3. Type 'inventory' to see what's in your inventory,
4. Type 'Use' plus the item name to use your items,
5. Type 'Take' to take the item
6. Type 'Reset' to reset the game,
7. Type 'Quit' to quit the game");
        }

        public void Inventory()
        {
            foreach (var item in CurrentPlayer.Inventory)
            {
                Console.WriteLine($"You have a {item.Name} in your inventory");
            }
            Console.WriteLine("Seems like you don't have anything here");
        }

        public void Look()
        {
            Console.WriteLine($"You are in the {CurrentRoom.Name} room, {CurrentRoom.Description}");
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
            playing = true;

            Room Entrance = new Room("Entrance", "This is just the beginning.");
            Room DeathTrap = new Room("Pit o' Spikey Death", "It was dark, you fell, you died. On spikes! Type 'start over' to play again!");
            Room East1 = new Room("Easty", "You scan the room and find a small object in the corner. It's a key. Try taking it.");
            Room East2 = new Room("Eastier", "This room definitely has a locked door. Didn't you pick something up in the last room to open it?");
            Room Exit = new Room("Eastiest", "Yay, you won this incredibly simple game!");

            Item key = new Item("key", "Metal that unlocks a door!");
            Item lockedDoor = new Item("A locked door", "Feels like there should be a key...");


            Entrance.Exits.Add("east", East1);
            Entrance.Exits.Add("south", DeathTrap);
            East1.Exits.Add("west", Entrance);
            East1.Exits.Add("east", East2);
            East2.Exits.Add("west", East1);
            East2.Exits.Add("east", Exit);

            East1.Items.Add(key);
            East2.Items.Add(lockedDoor);

            CurrentRoom = Entrance;

            Console.Clear();
            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();
            CurrentPlayer = new Player(name);
        }

        public void StartGame()
        {
            Setup();
            Console.WriteLine("Welcome to QUEST TOWN! Your only mission: Escape.");
            while (playing)
            {
                GetUserInput();
            }
            // Console.Clear();
            Console.WriteLine("Ok byyyeee!");
        }

        public void TakeItem(string itemName)
        {
            Item item = CurrentRoom.Items.Find(i => i.Name == itemName);
            if (item != null)
            {
                CurrentPlayer.Inventory.Add(item);
                CurrentRoom.Items.Remove(item);
                Console.WriteLine("You grabbed the key, it's now in your inventory.");
                return;
            }
        }

        public void UseItem(string itemName)
        {
            Item item = CurrentPlayer.Inventory.Find(i => i.Name == itemName);

            if (item != null)
            {
                CurrentPlayer.Inventory.Remove(item);
                CurrentRoom.Items.Remove(item);
                Console.Write("The door is now unlocked! You may proceed...");
            }

        }
    }
}