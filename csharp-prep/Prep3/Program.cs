using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");
        string playAgain;

        do
        {
            Random randomGenerator = new Random();
            int jah_number = randomGenerator.Next(1, 101);
            int jah_guess;

            int jah_counter = 0;

            // Console.WriteLine(jah_number);

            do
            {
                Console.Write("What is your guess? ");
                string jah_raw_guess = Console.ReadLine();
                jah_guess = int.Parse(jah_raw_guess);
                
                if (jah_guess > jah_number)
                {
                    Console.WriteLine("Lower.");
                }
                else if (jah_guess < jah_number)
                {
                    Console.WriteLine("Higher.");
                }

                jah_counter ++;
            } while(jah_guess != jah_number);

            Console.WriteLine($"You guessed it in {jah_counter} attempts. Good job!");
            Console.Write("Would you like to play again? ");
            playAgain = Console.ReadLine();
        }while (playAgain == "yes");

    }
}