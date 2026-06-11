using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");

        Console.Write("What is your first name? ");
        string jah_first_name = Console.ReadLine();

        Console.Write("What is your last name? ");
        string jah_last_name = Console.ReadLine();

        Console.WriteLine($"Your name is {jah_last_name}, {jah_first_name} {jah_last_name}.");
    }
}