public class WormGame
{
    private Random random;
    private List<int[]> badWorms { get; }
    private List<int[]> goodWorms { get; }

    private int score;

    private int timer;

    // Declare all variables
    public WormGame()
    {
        badWorms = new List<int[]>();
        goodWorms = new List<int[]>();
        random = new Random();
        this.score = 0;
        this.timer = 60;
    }

    // Stop the game and display game over menu
    public void stopGame()
    {
        new WormGameOverMenu(this).display();
    }

    // Refresh and randomise the worms
    public void recycleWorms()
    {
        badWorms.Clear();
        goodWorms.Clear();
        // Good worms
        int amountOfGoodWorms = random.Next(1, 10);

        for (int i = 0; i < amountOfGoodWorms; i++)
        {
            int x = random.Next(0, 10);
            int y = random.Next(0, 10);
            if (!isGoodWorm(x, y))
            {
                goodWorms.Add(new int[] { x, y });
            }
        }

        // Bad worms
        int amountOfBadWorms = random.Next(1, 10);

        for (int i = 0; i < amountOfBadWorms; i++)
        {
            int x = random.Next(0, 10);
            int y = random.Next(0, 10);
            if (!isBadWorm(x, y))
            {
                badWorms.Add(new int[] { x, y });
            }
        }
    }

    // Gets, sets and checks on arrays and variables
    public bool isGoodWorm(int x, int y)
    {
        foreach (int[] goodWormArr in goodWorms)
        {
            if (x == goodWormArr[0] && y == goodWormArr[1]) return true;
        }
        return false;
    }

    public bool isBadWorm(int x, int y)
    {
        foreach (int[] badWormArr in badWorms)
        {
            if (x == badWormArr[0] && y == badWormArr[1]) return true;
        }
        return false;
    }

    public void removeWorm(bool good, int x, int y)
    {
        if (good)
        {
            foreach (int[] goodWormArr in goodWorms)
            {
                if (x == goodWormArr[0] && y == goodWormArr[1])
                {
                    goodWorms.Remove(goodWormArr);
                    break;
                }
            }
        } else
        {
            foreach (int[] goodWormArr in badWorms)
            {
                if (x == goodWormArr[0] && y == goodWormArr[1])
                {
                    badWorms.Remove(goodWormArr);
                    break;
                }
            }
        }
    }

    public void addScore(int i)
    {
        this.score += i;
    }

    public void removeScore(int i)
    {
        this.score -= i;
    }

    public void removeTimer(int i)
    {
        this.timer -= i;
    }

    public int getScore()
    {
        return this.score;
    }

    public int getTimer()
    {
        return this.timer;
    }
}
