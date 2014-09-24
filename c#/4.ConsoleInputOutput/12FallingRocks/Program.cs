using System;
using System.Collections.Generic;
using System.Threading;

struct Rocks
{
    public int x;
    public int y;
    public char c;
    public Rocks(int x, int y, char c)
    {
        this.x = x;
        this.y = y;
        this.c = c;
    }
}

class Program
{
    static byte position = 0;
    static int[] playerPositionX = new int[3];
    static int[] playerPositionY = new int[3];
    static char[] rocks = {'^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';'};
    static Random randomNumbersGenerator = new Random();

    static void Main()
    {
        bool isOver = false;
        int sleepTime = 150;
        int x = 10;
        int y = 30;
        int timeToDrop = 0;
        int points = 0;

        List<Rocks> fallingRocks = new List<Rocks>();

        Console.WindowHeight = x;
        Console.BufferHeight = x;
        Console.WindowWidth = y;
        Console.BufferWidth = y;
        
        playerPositionX[0] = x - 1;
        playerPositionX[1] = x - 1;
        playerPositionX[2] = x - 1;

        playerPositionY[0] = y / 2 - 2;
        playerPositionY[1] = y / 2 - 1;
        playerPositionY[2] = y / 2;

        while (isOver == false)
        {
            Console.Clear();

            foreach (var rock in fallingRocks)
            {
                Console.SetCursorPosition(rock.x, rock.y);
                Console.Write(rock.c);

                if (rock.x == playerPositionY[0] && rock.y == playerPositionX[0])
                {
                    isOver = true;
                    break;
                }
                else if (rock.x == playerPositionY[1] && rock.y == playerPositionX[1])
                {
                    isOver = true;
                    break;
                }
                else if (rock.x == playerPositionY[2] && rock.y == playerPositionX[2])
                {
                    isOver = true;
                    break;
                }
            }

            timeToDrop += 1;

            if (timeToDrop > 5)
            {
                for (int i = 0; i < fallingRocks.Count; i++)
                {
                    if (fallingRocks[i].y + 1 > x - 1)
                    {
                        fallingRocks.RemoveAt(i);
                    }
                    else
                    {
                        fallingRocks[i] = new Rocks(fallingRocks[i].x, fallingRocks[i].y + 1, fallingRocks[i].c);
                    }
                }

                int randomNumberOfRocks = randomNumbersGenerator.Next(1, 5);
                for (int i = 0; i < randomNumberOfRocks; i++)
                {
                    int randPositionX = randomNumbersGenerator.Next(0, 26);
                    int randomRock = randomNumbersGenerator.Next(0, rocks.Length);

                    fallingRocks.Add(new Rocks(randPositionX, 0, rocks[randomRock]));
                }

                timeToDrop = 0;
                points++;
            }

            movePlayer();
            printPlayer(playerPositionX, playerPositionY);

            Thread.Sleep(sleepTime);
        }

        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("End of game");

        Console.SetCursorPosition(0, 2);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You achieved {0} points :)", points / 3);
    }

    static void movePlayer()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo userInput = Console.ReadKey();
            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                position = 1;
            }
            if (userInput.Key == ConsoleKey.RightArrow)
            {
                position = 2;
            }
        }

        if (position == 1)
        {
            if (playerPositionY[0] > 0)
            {
                playerPositionY[0]--;
                playerPositionY[1]--;
                playerPositionY[2]--;
            }

            position = 0;
        }
        else if (position == 2)
        {
            if (playerPositionY[0] < 26)
            {
                playerPositionY[0]++;
                playerPositionY[1]++;
                playerPositionY[2]++;
            }

            position = 0;
        }
    }

    static void printPlayer(int[] playerPositionX, int[] playerPositionY)
    {
        for (int i = 0; i < playerPositionX.Length; i++)
        {
            Console.SetCursorPosition(playerPositionY[i], playerPositionX[i]);
            if (i == 0)
            {
                Console.Write("(");
            }
            else if (i == 1)
            {
                Console.Write("0");
            }
            else if (i == 2)
            {
                Console.Write(")");
            }
        }
    }
}