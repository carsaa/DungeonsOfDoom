using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    public class Game
    {
        Player player;
        Space[,] world;
        char[,] display = new char[20, 30];
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
                player.Bag.Add(currentItem);
                if (currentItem is Food)
                {
                    Food food = currentItem as Food;

                    player.Health += food.HealthGain;
                }
                else if (currentItem is Weapon)
                {
                    Weapon weapon = currentItem as Weapon;

                    player.AttackStrength += weapon.AttackStrength;
                }
                space.Item = null;
            }
        }

        private void DisplayStats()
        {
            int bagCount = player.Bag.Count;
            Console.WriteLine($"Health: {player.Health} Attack: {player.AttackStrength} Items: {bagCount} Weight: {player.Bag.Weight}");
            if (bagCount > 0)
            {
                Console.WriteLine($"Last item collected: {player.Bag[bagCount - 1].Name}");

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
                newX >= 0 && newX < world.GetLength(0) &&
                newY >= 0 && newY < world.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;

                player.Health--;
            }
        }

        private void DisplayWorld()
        {
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    Space space = world[x, y];

                    if (player.X == x && player.Y == y)
                    {
                        Console.Write(player.Icon);
                    }
                    else
                    {
                        Console.Write(space.Icon);
                    }
                }
                Console.WriteLine();
            }
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine($"Game over {player.Name} !");
            Console.ReadKey();
            Play();
        }

        private void CreateWorld()
        {
            world = new Space[30, 10];

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
                            else if (current < 12)
                            {
                                space.Monster = new Teacher("Håkan");
                            }
                            current = random.Next(0, 100);
                            if (current < 10)
                            {
                                space.Item = new Apple();
                            } else if (current < 11)
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
            player = new Player(30, 0, 0, 5, playerName);
        }
    }
}
