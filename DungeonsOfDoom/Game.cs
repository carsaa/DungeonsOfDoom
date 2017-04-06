using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{

    public class Game
    {
        Player player;
        Space[,] world;
        DisplayInfo[,] display = new DisplayInfo[21, 21];
        const int worldSizeX = 100, worldSizeY = 100;


        public void Play()
        {
            CreatePlayer();
            CreateWorld();

            do
            {
                Console.Clear();
                DisplayWorld();
                DisplayStats();
                DisplayItems();
                AskForMovement();
                CheckSpace();

            } while (player.IsAlive);

            GameOver();
        }
        private void DisplayItems()
        {
            foreach (var item in player.Bag)
            {
                Console.Write(item.Name + ", ");
            }
        }

        private void CheckSpace()
        {
            Space space = world[player.X, player.Y];

            space.Visit(player);

            if (space.Monster != null)
            {
                Monster currentMonster = space.Monster;
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Battle(currentMonster);
                space.Monster = null;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }

            if (space.Item != null)
            {
                Item currentItem = space.Item;
                Console.Beep();

                currentItem.Interaction(player);

                space.Item = null;
            }
        }

        private void Battle(Monster currentMonster)
        {
            do
            {
                string currentInfo;
                if (RandomUtils.TryPercentage(50))
                {
                    currentInfo = player.Attack(currentMonster);
                    TextUtils.AnimateText(currentInfo, 20);
                    if (currentMonster.IsAlive)
                    {
                        currentInfo = currentMonster.Attack(player);
                        TextUtils.AnimateText(currentInfo, 20);
                    }
                }

                else
                {
                    currentInfo = currentMonster.Attack(player);
                    TextUtils.AnimateText(currentInfo, 20);

                    if (player.IsAlive) { 
                        currentInfo = player.Attack(currentMonster);
                        TextUtils.AnimateText(currentInfo, 20);

                    }
                }

            } while (player.IsAlive && currentMonster.IsAlive);

            if (player.IsAlive)
            {
                TextUtils.AnimateText($"{currentMonster.Name} died!", 20);
                Console.ReadKey();
            }
            else
            {
                TextUtils.AnimateText($"Frappidiclappidido, {currentMonster.Name} killed you!", 20);
                Console.ReadKey();
            }
            Monster.MonsterCounter--;
        }

        private void DisplayStats()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            int bagCount = player.Bag.Count;
            Console.WriteLine($"Health: {player.Health} Attack: {player.AttackStrength} Items: {bagCount} Weight: {player.Bag.Weight}");
            Console.WriteLine($"Monsters left: {Monster.MonsterCounter}");
            if (bagCount > 0)
            {
                Console.WriteLine($"You found a {player.Bag[bagCount - 1].Name}! Item added to bag.");

            }
            else
            {
                Console.WriteLine();
            }
        }

        private void AskForMovement()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            int newX = player.X;
            int newY = player.Y;
            bool isValidMove = true;

            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    newX++; break;

                case ConsoleKey.LeftArrow:
                    newX--; break;

                case ConsoleKey.UpArrow:
                    newY--; break;

                case ConsoleKey.DownArrow:
                    newY++; break;

                default:
                    isValidMove = false; break;
            }

            if (isValidMove &&
                IsValidCoordinate(newX, newY))
            {
                player.X = newX;
                player.Y = newY;

                player.Health--;
            }
        }

        private bool IsValidCoordinate(int x, int y) => x >= 0 && x < world.GetLength(0) && y >= 0 && y < world.GetLength(1);

        private void DisplayWorld()
        {
            int medianX = display.GetLength(0) / 2;
            int medianY = display.GetLength(1) / 2;
            // copy world to display
            for (int y = 0; y < display.GetLength(1); y++)
            {
                for (int x = 0; x < display.GetLength(0); x++)
                {
                    int worldX = player.X + (x - medianX);
                    int worldY = player.Y + (y - medianY);
                    if (IsValidCoordinate(worldX, worldY))

                        display[x, y] = new DisplayInfo(world[worldX, worldY].Icon, ConsoleColor.White);
                    else
                        display[x, y] = new DisplayInfo('X', ConsoleColor.DarkMagenta);
                }
            }
            display[medianX, medianY] = new DisplayInfo(player.Icon, ConsoleColor.Green);

            // show display
            for (int y = 0; y < display.GetLength(1); y++)
            {
                for (int x = 0; x < display.GetLength(0); x++)
                {
                    DisplayInfo info = display[x, y];
                    Console.ForegroundColor = info.Color;
                    Console.Write(" " + info.Icon + " ");
                }
                Console.WriteLine();
            }

        }

        private void GameOver()
        {
            Console.Clear();
            TextUtils.AnimateText($"Game over {player.Name} !", 70);
            Thread.Sleep(1000);
            Console.ReadKey();
            Play();
        }

        private void CreateWorld()
        {
            //Resetting monster counter when game restarts
            Monster.MonsterCounter = 0;

            world = new Space[worldSizeX, worldSizeY];

            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    if (RandomUtils.TryPercentage(2))
                    {
                        world[x, y] = new Pitfall();
                    }

                    else
                    {
                        Space space;
                        if (RandomUtils.TryPercentage(3))
                        {
                            space = new Cave();
                        }
                        else
                        {
                            space = new Room();
                        }
                        //Skulle kunna lösa placering av creatures/items i metoder för att abstrahera bort det från Space-klassen.
                        if (player.X != x || player.Y != y)
                        {
                            if (RandomUtils.TryPercentage(5))
                            {
                                space.Monster = new Troll();
                            }
                            else if (RandomUtils.TryPercentage(5))
                            {
                                space.Monster = new Teacher("Håkan");
                            }

                            if (RandomUtils.TryPercentage(5))
                            {
                                space.Item = new Apple();
                            }
                            else if (RandomUtils.TryPercentage(1))
                            {
                                space.Item = new Spear(1);
                            }

                        }
                        world[x, y] = space;
                    }

                }
            }
        }

        private void CreatePlayer()
        {
            string playerName = "Linus";

            //Ny spelare med 30 liv och 5 attack, slumpar startposition
            player = new Player(30, RandomUtils.GetRandomNumber(0, worldSizeX),
                RandomUtils.GetRandomNumber(0, worldSizeY), 5, playerName);
        }
    }
}
