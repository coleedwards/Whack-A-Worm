public class ConsoleUtil { 

    // Clear the console by overlaying white space to reduce flicker
    public static void clearConsole()
    {
        for (int y = 6; y < Console.WindowHeight; y++) {
           for (int x = 1; x < Console.WindowWidth; x++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(" ");
            }
        }
    }

}