using System.Globalization;
using System.Net;

class Support{
    public static int GetUserInputInteger(string Prompt)
    {
        int rvalue = 0;
        bool jahFlag = true;
        while (jahFlag)
        {
            try
            {
                Console.WriteLine(Prompt);
                string jahUserInputStr = Console.ReadLine();
                rvalue = int.Parse(jahUserInputStr);
                jahFlag = false;
            } catch (Exception)
            {
                Console.WriteLine("Value is not acceptable, please try again.");
            }
        }

        return rvalue;
    }

    public static float GetUserInputFloat(string Prompt)
    {
        float rvalue = 0;
        bool jahFlag = true;
        while (jahFlag)
        {
            try
            {
                Console.WriteLine(Prompt);
                string jahUserInputStr = Console.ReadLine();
                rvalue = float.Parse(jahUserInputStr);
                jahFlag = false;
            } catch (Exception)
            {
                Console.WriteLine("Value is not acceptable, please try again.");
            }
        }

        return rvalue;
    }

    public static string GetUserInputString(string Prompt)
    {
        string jahUserInputStr = "";
        bool jahFlag = true;
        while (jahFlag)
        {
            try
            {
                Console.WriteLine(Prompt);
                jahUserInputStr = Console.ReadLine();
                if (string.IsNullOrEmpty(jahUserInputStr) == true)
                {
                    throw new Exception();
                }
                jahFlag = false;
            } catch (Exception)
            {
                Console.WriteLine("Value is not acceptable, please try again.");
            }
        }

        return jahUserInputStr;
    }

    public static float GetUserInputRealNumber(string Prompt)
    {
        float rvalue = 0;
        bool jahFlag = true;
        while (jahFlag)
        {
            try
            {
                Console.WriteLine(Prompt);
                string jahUserInputStr = Console.ReadLine();
                rvalue = float.Parse(jahUserInputStr);
                if (float.IsRealNumber(rvalue))
                {
                    throw new Exception();
                }
                jahFlag = false;
            } catch (Exception)
            {
                Console.WriteLine("Value is not acceptable, please try again.");
            }
        }

        return rvalue;
    }
    public static void Display(string s)
    {
        Console.WriteLine(s);
    }
    public static void Display(string s, Boolean noNewLine)
    {
        Console.Write(s);
    }
}