public class WormCountdownMenu
{

    private WormGameMenu mainMenu;

    // Set variables
    public WormCountdownMenu(WormGameMenu mainMenu)
    {
        this.mainMenu = mainMenu;
    }

    // Display the countdown menu
    public void display()
    {
        ConsoleUtil.clearConsole();

        for (int i = 5; i > 0; i--)
        {
            Console.SetCursorPosition(38, 7);
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }

        onPlay();
    }

    // When ready to play, display the game menu
    public void onPlay()
    {
        mainMenu.display();
    }
}