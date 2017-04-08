using DungeonsOfDoom.Creatures;
using DungeonsOfDoom.Spaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    public class ConsoleDisplay
    {
        DisplayInfo[,] display = new DisplayInfo[21, 21];

        public void Display(String text)
        {
            Console.WriteLine(text);
        }

        public void DisplayWorld(Game game)
        {
            Space[,] world = game.world;
            Player player = game.player;

            int medianX = display.GetLength(0) / 2;
            int medianY = display.GetLength(1) / 2;
            // copy world to display
            for (int y = 0; y < display.GetLength(1); y++)
            {
                for (int x = 0; x < display.GetLength(0); x++)
                {
                    int worldX = player.X + (x - medianX);
                    int worldY = player.Y + (y - medianY);
                    if (game.IsValidCoordinate(worldX, worldY))

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
    }


}
