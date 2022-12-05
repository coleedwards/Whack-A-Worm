public class WhackAWorm
{

    public WhackAWorm(bool newInstance)
    {
        WormGame game = new WormGame();

        WormGameMenu menu = new WormGameMenu(game);
        Console.CursorVisible = false;

        // Worm main menu display
        WormMainMenu wormMainMenu = new WormMainMenu(menu, newInstance);

        // Display
        wormMainMenu.display();
    }

    public static void Main(string[] args)
    {
        new WhackAWorm(true);
    }


}
