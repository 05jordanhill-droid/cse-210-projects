using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning04 World!");
        Assignment jahSam = new Assignment("Samuel Bennett", "Multiplication");
        MathAssignment jahRob = new MathAssignment("Robert Rodriguez", "Fractions", "7.3", "8-19");
        WritingAssignment jahMary = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");

        print(jahSam.GetSummary());

        print(jahRob.GetSummary());
        print(jahRob.GetHomeworkList());
        
        print(jahMary.GetSummary());
        print(jahMary.GetWritingInformation());
    }
    public static void print(string s)
    {
        Support.Display(s);
    }
}