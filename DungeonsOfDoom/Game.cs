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
        char[,] display = new char[21, 21];
        Random random = new Random(); //Bra att använda en instans av random för att inte slumpa samma sak hela tiden

        public void Play()
        {
            CreatePlayer();
            CreateWorld();

            do
            {
                Console.Clear();
                DisplayStats();
                DisplayWorld();
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

                do
                {
                    player.Attack(currentMonster);
                    currentMonster.Attack(player);
                } while (player.IsAlive && currentMonster.IsAlive);



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

        private void DisplayStats()
        {
            int bagCount = player.Bag.Count;
            Console.WriteLine($"Health: {player.Health} Attack: {player.AttackStrength} Items: {bagCount} Weight: {player.Bag.Weight}");
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

                //player.Health--;
            }
        }

        private bool IsValidCoordinate(int x, int y)
        {
            return x >= 0 && x < world.GetLength(0) && y >= 0 && y < world.GetLength(1);
        }

        private void DisplayWorld()
        {
            int meanX = display.GetLength(0) / 2;
            int meanY = display.GetLength(1) / 2;
            // copy world to display
            for (int y = 0; y < display.GetLength(1); y++)
            {
                for (int x = 0; x < display.GetLength(0); x++)
                {
                    int worldX = player.X + (x - meanX);
                    int worldY = player.Y + (y - meanY);
                    if (IsValidCoordinate(worldX, worldY))
                        display[x, y] = world[worldX, worldY].Icon;
                    else
                        display[x, y] = 'X';
                }
            }
            display[meanX, meanY] = player.Icon;

            // show display
            for (int y = 0; y < display.GetLength(1); y++)
            {
                for (int x = 0; x < display.GetLength(0); x++)
                {
                    if (display[x, y] == 'P')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" P ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.Write(" " + display[x, y] + " ");
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
            world = new Space[100, 100];

            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    if (random.Next(0, 100) > 90)
                    {
                        world[x, y] = new Pitfall();
                    }

                    else
                    {
                        Space space;
                        if (random.Next(0, 100) > 10)
                        {
                            space = new Room();
                        }
                        else
                        {
                            space = new Cave();
                        }


                        if (player.X != x || player.Y != y)
                        {
                            int current = random.Next(0, 100);
                            if (current < 10)
                            {
                                space.Monster = new Troll();
                            }
                            else if (current < 40)
                            {
                                space.Monster = new Teacher("Håkan");
                            }
                            current = random.Next(0, 100);
                            if (current < 10)
                            {
                                space.Item = new Apple();
                            }
                            else if (current < 11)
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
            string playerName = "Player1";
            //Console.Write("Ange ditt namn: ");
            //string playerName = Console.ReadLine();
            player = new Player(30, 20, 20, 5, playerName);
        }
    }
}
