using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");

        Console.Write("What is your grade percentage? ");
        string jahUserInputGradePercentage = Console.ReadLine();
        float jahGradePercentage = float.Parse(jahUserInputGradePercentage);

        string jahGradeLetter = "";
        string jahGradeSign = "";

        if (jahGradePercentage >= 90)
        {
            jahGradeLetter = "A";
        }
        else if (jahGradePercentage >= 80)
        {
            jahGradeLetter = "B";
        }
        else if (jahGradePercentage >= 70)
        {
            jahGradeLetter = "C";
        }
        else if (jahGradePercentage >= 60)
        {
            jahGradeLetter = "D";
        }
        else if (jahGradePercentage < 60)
        {
            jahGradeLetter = "F";
        }

        if (jahGradePercentage % 10 >= 7 && jahGradeLetter != "A" && jahGradeLetter != "F")
        {
            jahGradeSign = "+";
        }
        else if (jahGradePercentage % 10 < 3 && jahGradeLetter != "F")
        {
            jahGradeSign = "-";
        }

        Console.WriteLine($"Your grade is {jahGradeLetter}{jahGradeSign}.");

        if (jahGradePercentage < 60)
        {
            Console.WriteLine("You failed. Better luck next time!");
        }
        else if (jahGradePercentage >= 60)
        {
            Console.WriteLine("You passed.");
        }
    }
}