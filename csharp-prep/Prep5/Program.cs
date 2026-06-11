using System;

// DisplayWelcome - Displays the message, "Welcome to the Program!"
// PromptUserName - Asks for and returns the user's name (as a string)
// PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
// PromtUserBirthYear - Accepts out integer parameter and prompts the user for the year they were born. The out parameter is set to their birth year. This function does not return a value. The user's birth year is given back from the function via the out parameter.
// SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
// DisplayResult - Accepts the user's name, the squared number, and the user's birth year. Display the user's name and squared number. Calculate hold many years old they will turn this year and display that.

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string jahName = Console.ReadLine();

        return jahName;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string jahRawNum = Console.ReadLine();
        int jahNum = int.Parse(jahRawNum);

        return jahNum;
    }

    static void PromptUserBirthYear(out int jahBirthYear)
    {
        Console.Write("Please enter the year you were born: ");
        string jahRawBirthYear = Console.ReadLine();
        jahBirthYear = int.Parse(jahRawBirthYear);
    }

    static int SquareNumber(int userNum)
    {
        int jahNumSquared = userNum * userNum;

        return jahNumSquared;
    }

    static void DisplayResult(string jahName, int jahBirthYear, int jahNumSquared)
    {
        Console.WriteLine($"{jahName}, the square of your number is {jahNumSquared}.");

        int jahCurrentYear = DateTime.Now.Year;
        int jahAge = jahCurrentYear - jahBirthYear;

        Console.WriteLine($"{jahName}, you will turn {jahAge} this year.");
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");

        int jahBirthYear = 0;

        DisplayWelcome();
        string jahName = PromptUserName();
        int jahNum = PromptUserNumber();
        PromptUserBirthYear(out jahBirthYear);
        int jahNumSquared = SquareNumber(jahNum);
        DisplayResult(jahName,jahBirthYear, jahNumSquared);
    }
}