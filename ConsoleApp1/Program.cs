using System;
using System.Text;
using RacingGameLib;

namespace RacingGameConsole
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            RacingGame game = new RacingGame();

            Console.WriteLine("=== GAME ĐUA XE (Console) ===");
            Console.WriteLine("Phím: W = tăng tốc, S = phanh, A = trái, D = phải, Q = thoát\n");

            while (!game.IsGameOver)
            {
                Console.WriteLine(game.GetStatus());
                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.W) game.Accelerate();
                else if (key == ConsoleKey.S) game.Brake();
                else if (key == ConsoleKey.A) game.MoveLeft();
                else if (key == ConsoleKey.D) game.MoveRight();
                else if (key == ConsoleKey.Q) break;

                Console.Clear();
            }

            Console.WriteLine("Kết thúc game. " + game.GetStatus());
            Console.ReadKey();
        }
    }
}
