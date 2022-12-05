public class IntCharUtil
{
    // // https://stackoverflow.com/a/10373827
    public static string getCharValue(int index)
    {
        const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        var value = "";

        if (index >= letters.Length)
            value += letters[index / letters.Length - 1];

        value += letters[index % letters.Length];

        return value;
    }

    // Get the ASCII value - 65 of a character to integer
    public static int getIntValue(char character)
    {
        return char.ToUpper(character) - 65;
    }
}