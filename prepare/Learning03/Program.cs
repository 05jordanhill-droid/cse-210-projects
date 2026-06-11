using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");

        Fraction jahFraction = new Fraction();
        Random jahRandom = new Random();

        for (int i = 0; i < 20; i++)
        {
            int jahTop = jahRandom.Next(10);
            int jahBottom = jahRandom.Next(10);

            jahFraction.SetTop(jahTop);
            jahFraction.SetBottom(jahBottom);

            Console.WriteLine($"Fraction {i+1}: string: {jahFraction.GetFractionString()} number: {jahFraction.GetDecimalValue()}");
        }
    }
}