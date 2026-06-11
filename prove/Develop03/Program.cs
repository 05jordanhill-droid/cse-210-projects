/*
Class Name	        Program	                Word()	                Scripture()	                Reference()
class methods		                        _word: string	        _textList: list<Word>	    _book: string
		                                    _visibility: boolean		                        _chapter: int
				                                                                                _first: int
				                                                                                _last: int
				                                                                                _jahFormat: string

class functions	    Display(): void	        Word(string word)	    Scripture(string text)	    Reference(string book, int chapter, int first, int last)
	                	                    IsVisible(): boolean	HideRandom(): void	        Reference(string book, int chapter, int first)
		                                    Hide():void	            ToString(): string	        ToString(): string
		                                    ToString(): string		
		                                    GetLen(): int		


Stretch: Randomly select from only words that are not already hidden		
*/
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");

        // Store a Scripture
        string jahBook = "Proverbs";
        int jahChapter = 3;
        int jahFirst = 5;
        int jahLast = 6;
        string jahText = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";

        Scripture jahScripture = new Scripture(jahText);
        Reference jahReference = new Reference(jahBook, jahChapter, jahFirst, jahLast);

        string jahUserInput = "";

        while(jahUserInput != "quit")
        {
            Display(jahReference, jahScripture);

            Console.WriteLine("Press enter to continue or type 'quit' to finish.");
            jahUserInput = Console.ReadLine();

            if (! jahScripture.IsVisible())
            {
                jahUserInput = "quit";
            }

            if (jahUserInput != "quit")
            {
                jahScripture.HideRandom();
            }
        }
    }
    static void Display(Reference jahReference, Scripture jahScripture)
    {
        Console.Clear();
        Console.Write(jahReference.ToString());
        Console.WriteLine(jahScripture.ToString());
        Console.WriteLine();
    }
}