using System;

public class WormGameMenu
{
    private WormGame wormGame;
    private Thread wormThread;
    private Thread wormTimerThread;
    private int[] selectedGridPosition;
    private bool isDisplayed;
    private bool firstTimePrint;

    // Initalise all variables and start game threads
    public WormGameMenu(WormGame wormGame)
    {
        this.wormGame = wormGame;
        this.firstTimePrint = false;
        selectedGridPosition = new int[] { 0, 0 };
        WormThread wormThreadObj = new WormThread(this.wormGame, this);
        wormThread = new Thread(new ThreadStart(wormThreadObj.recycleWorms));
        wormTimerThread = new Thread(new ThreadStart(new WormTimerThread(this.wormGame, this).runThread));
    }

    // Display main game screen
    public void display()
    {
        isDisplayed = true;
        this.wormThread.Start();
        Thread gridThread = new Thread(new ThreadStart(this.refreshWormGrid));
        //gridThread.Start();
        wormTimerThread.Start();
        while (isDisplayed && wormGame.getTimer() > 0)
        {
            if (keyInput(Console.ReadKey())) break;
        }
    }

    // Reprint the grid 
    public void refreshWormGrid()
    {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        if (!firstTimePrint)
        {
            ConsoleUtil.clearConsole();
            firstTimePrint = true;
        }
        Console.SetCursorPosition(38, 6);
        Console.WriteLine("Score: " + this.wormGame.getScore());
        Console.SetCursorPosition(38, 7);
        Console.WriteLine("Timer: " + this.wormGame.getTimer());

        int left = 34;
        for (int x = 0; x < 10; x++)
        {
            int coordsDisplay = 9;
            for (int y = 0; y < 10; y++)
            {
                Console.SetCursorPosition(left, coordsDisplay);
                if (selectedGridPosition[0] == x && selectedGridPosition[1] == y)
                {
                    bool worm = false;
                    if (wormGame.isGoodWorm(x, y))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        worm = true;
                    }

                    if (wormGame.isBadWorm(x, y))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        worm = true;
                    }


                    Console.BackgroundColor = ConsoleColor.Blue;
                    if (worm)
                    {
                        Console.WriteLine("O");
                    }
                    else
                    {
                        Console.WriteLine("#");
                    }
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                else
                {
                    bool worm = false;
                    if (wormGame.isGoodWorm(x, y))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        worm = true;
                    }

                    if (wormGame.isBadWorm(x, y))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        worm = true;
                    }


                    if (worm)
                    {
                        Console.WriteLine("O");
                    }
                    else
                    {
                        Console.WriteLine("#");
                    }
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                coordsDisplay++;
            }
            left += 2;
        }
        Thread.Sleep(500);

    }
    
    // Get key input and make changes to variables depending on key input
    public bool keyInput(ConsoleKeyInfo key)
    {
        int oldX = selectedGridPosition[0];
        int oldY = selectedGridPosition[1];
        bool updatedGrid = false;

        switch (key.Key)
        {
            case ConsoleKey.RightArrow:
                int newX = oldX + 1;
                if (newX > -1 && newX <= 9)
                {
                    selectedGridPosition[0] = newX;
                    updatedGrid = true;
                }
                break;
            case ConsoleKey.LeftArrow:
                newX = oldX - 1;
                if (newX > -1 && newX <= 9)
                {
                    selectedGridPosition[0] = newX;
                    updatedGrid = true;
                }
                break;
            case ConsoleKey.UpArrow:
                int newY = oldY - 1;
                if (newY > -1 && newY <= 9)
                {
                    selectedGridPosition[1] = newY;
                    updatedGrid = true;
                }
                break;
            case ConsoleKey.DownArrow:
                newY = oldY + 1;
                if (newY > -1 && newY <= 9)
                {
                    selectedGridPosition[1] = newY;
                    updatedGrid = true;
                }
                break;
            case ConsoleKey.Enter:
                if (wormGame.isGoodWorm(oldX, oldY))
                {
                    Console.Beep();
                    this.wormGame.recycleWorms();
                    this.wormGame.addScore(1);
                    updatedGrid = true;
                }

                if (wormGame.isBadWorm(oldX, oldY))
                {
                    this.wormGame.recycleWorms();
                    this.wormGame.removeScore(1);
                    updatedGrid = true;
                }
                break;
            default:
                break;
        }

        if (updatedGrid)
        {
            refreshWormGrid();
        }

        return false;
    }

    internal class WormThread
    {
        private WormGameMenu wormGameMenu;
        private WormGame wormGame;

        public WormThread(WormGame wormGame, WormGameMenu wormGameMenu)
        {
            this.wormGame = wormGame;
            this.wormGameMenu = wormGameMenu;
        }

        // Every random 1-5 seconds, call the void to refresh the worms
        public void recycleWorms()
        {
            while (wormGame.getTimer() > 0)
            {
                wormGame.recycleWorms();
                this.wormGameMenu.refreshWormGrid();
                Thread.Sleep(new Random().Next(1, 5) * 1000);
            }
        }
    }

    internal class WormTimerThread
    {
        private WormGame wormGame;
        private WormGameMenu wormGameMenu;

        public WormTimerThread(WormGame wormGame, WormGameMenu wormGameMenu)
        {
            this.wormGame = wormGame;
            this.wormGameMenu = wormGameMenu;
        }

        // Manage the timer and the timer display by reducing it every second
        public void runThread()
        {
            while (wormGame.getTimer() > 0)
            {
                wormGame.removeTimer(1);
                if (wormGame.getTimer() == 9)
                {
                    Console.SetCursorPosition(46, 7);
                    Console.Write(" ");
                }
                Console.SetCursorPosition(38, 7);
                Console.WriteLine("Timer: " + this.wormGame.getTimer());
                Thread.Sleep(1000);
            }

            wormGame.stopGame();
        }
    }
}