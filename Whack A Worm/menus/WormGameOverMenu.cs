public class WormGameOverMenu
{

    private WormGame wormGame;

    public WormGameOverMenu(WormGame wormGame)
    {
        this.wormGame = wormGame;
    }

    // Display the game over menu
    public void display()
    {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        ConsoleUtil.clearConsole();
        Console.SetCursorPosition(34, 6);
        Console.WriteLine("Game Over!");
        Console.SetCursorPosition(34, 7);
        Console.WriteLine("Score: " + this.wormGame.getScore());
        Console.SetCursorPosition(34, 9);
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("[Main Menu]");

        ConsoleKey key = Console.ReadKey().Key;
       
        while (key != ConsoleKey.Enter)
        {
            key = Console.ReadKey().Key;
        }

        new WhackAWorm(false);
    }
}