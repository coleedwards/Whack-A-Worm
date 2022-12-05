public class WormMainMenu
{
    private WormGameMenu wormGameMenu;
    private bool isPlayHighlighted;
    private bool isDisplayed;
    private bool printTitle;

    public WormMainMenu(WormGameMenu wormGameMenu, bool printTitle)
    {
        this.wormGameMenu = wormGameMenu;
        isPlayHighlighted = true;
        isDisplayed = false;
        this.printTitle = printTitle;
    }

    // When ready to play, display the countdown menu
    public void onPlay()
    {
        Console.ReadKey();
        new WormCountdownMenu(wormGameMenu).display();
    }

    // Display the countdown menu
    public void display()
    {
        isDisplayed = true;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.DarkBlue;

        if (printTitle)
        {
            Console.Clear();
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Whack A Worm!"));
        } else
        {
            ConsoleUtil.clearConsole();
        }

        while (isDisplayed)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(34, 7);

            if (isPlayHighlighted)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("[Play]");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(34, 8);
                Console.WriteLine("[Exit]");
            }
            else
            {
                Console.WriteLine("[Play]");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(34, 8);
                Console.WriteLine("[Exit]");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
            }
            if (keyInput(Console.ReadKey())) break;
        }
    }

    // Take key input and change menu depending on the certain key input
    public bool keyInput(ConsoleKeyInfo key)
    {
        if (key.Key == ConsoleKey.DownArrow)
        {
            if (isPlayHighlighted) isPlayHighlighted = false;
        } else if (key.Key == ConsoleKey.UpArrow)
        {
            if (!isPlayHighlighted) isPlayHighlighted = true;
        } else if (key.Key == ConsoleKey.Enter)
        {
            if (isPlayHighlighted)
            {
                // play game
                isDisplayed = false;
                onPlay();
                return true;
            } else
            {
                ConsoleUtil.clearConsole();
                Console.SetCursorPosition(38, 7);
                Console.WriteLine("Goodbye.");
                System.Environment.Exit(0);
            }
        }
        return false;
    }

}
