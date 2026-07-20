using System.Globalization;

class TerminalDisplay
{
    public static void DisplayGrid<T>(List<List<T>> grid, Func<T, string> GetAvatar)
    {
        int height = grid.Count;
        int width = grid[0].Count;

        string spacer = ".";
        string border = "*";
        string empty = " ";

        Support.Display("--", true);

        for (int i = 0; i < width; i++)
        {
            // Support.Display($"{border}{spacer}", true);
            Support.Display($"{i:00}", true);
            if (i == width - 1)
            {
                Support.Display($"{border}");
            }
        }
        
        int k = 0;

        foreach(List<T> row in grid)
        {
            // Support.Display($"{border}{spacer}", true);
            Support.Display($"{k:00}", true);
            
            foreach(T slot in row)
            {
                if (slot != null)
                {
                    if(slot is Character)
                    {
                        
                    }
                    Support.Display(GetAvatar(slot), true);
                } else
                {
                    Support.Display(empty, true);
                }
                Support.Display(spacer, true);
            }
            Support.Display(border);

            k += 1;
        }
        for (int i = 0; i < width+2; i++)
        {
            if(i == width + 1)
            {
                Support.Display($"{border}", true);
            } else
            {
                Support.Display($"{border}{spacer}", true);
            }
        }
        Support.Display("");
    }

    public static void DisplayStats(Character jahCharacter)
    {
        Support.Display(jahCharacter.GetStringStats());
    }
}