using System.Globalization;
using System.Net;

class Support{
    public static int GetUserInputInteger(string Prompt, Boolean noNewLine=false)
    {
        int rvalue = 0;
        bool jahFlag = true;
        while (jahFlag)
        {
            try
            {
                Display(Prompt, noNewLine);
                string jahUserInputStr = Console.ReadLine();
                rvalue = int.Parse(jahUserInputStr);
                jahFlag = false;
            } catch (Exception)
            {
                Display("Value is not acceptable, please try again.", noNewLine);
            }
        }

        return rvalue;
    }

    public static float GetUserInputFloat(string Prompt, Boolean noNewLine=false)
    {
        float rvalue = 0;
        bool jahFlag = true;
        while (jahFlag)
        {
            try
            {
                Display(Prompt, noNewLine);
                string jahUserInputStr = Console.ReadLine();
                rvalue = float.Parse(jahUserInputStr);
                jahFlag = false;
            } catch (Exception)
            {
                Display("Value is not acceptable, please try again.", noNewLine);
            }
        }

        return rvalue;
    }

    public static string GetUserInputString(string Prompt, Boolean noNewLine=false)
    {
        string jahUserInputStr = "";
        bool jahFlag = true;
        while (jahFlag)
        {
            try
            {
                Display(Prompt, noNewLine);
                jahUserInputStr = Console.ReadLine();
                if (string.IsNullOrEmpty(jahUserInputStr) == true)
                {
                    throw new Exception();
                }
                jahFlag = false;
            } catch (Exception)
            {
                Display("Value is not acceptable, please try again.", noNewLine);
            }
        }

        return jahUserInputStr;
    }

    public static float GetUserInputRealNumber(string Prompt, Boolean noNewLine=false)
    {
        float rvalue = 0;
        bool jahFlag = true;
        while (jahFlag)
        {
            try
            {
                Display(Prompt, noNewLine);
                string jahUserInputStr = Console.ReadLine();
                rvalue = float.Parse(jahUserInputStr);
                if (float.IsRealNumber(rvalue))
                {
                    throw new Exception();
                }
                jahFlag = false;
            } catch (Exception)
            {
                Display("Value is not acceptable, please try again.", noNewLine);
            }
        }

        return rvalue;
    }
    public static void GetEmptyInput()
    {
        Console.ReadLine();
    }
    public static void Display(string s)
    {
        Console.WriteLine(s);
    }
    public static void Display(string s, Boolean noNewLine)
    {
        if (noNewLine){
            Console.Write(s);
        }
        else
        {
            Console.WriteLine(s);
        }
    }

    public static void Clear()
    {
        Console.Clear();
    }

    public static string GetRandomString(List<string> stringList)
    {
        if (stringList.Count == 0)
        {
            return "ERROR: EMPTY LIST";
        }

        string rvalue = stringList[GetRandomInt(stringList.Count)];

        return rvalue;
    }
    public static int GetRandomInt(int length)
    {
        Random random = new Random();
        int index = random.Next(length);

        return index;
    }
}