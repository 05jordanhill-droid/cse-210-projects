/*
Exceeding the Requirements: 
Asks for username rather than file name and saves the name to .csv
Accounts for commas and quotation marks to properly display in the .csv file and display into Excel

Sources:
   In person and online class material
   AI: https://chatgpt.com/share/6a063589-4bd4-83e8-96e6-bc0496385289
       https://chatgpt.com/share/6a063625-6570-83e8-86fd-bbd2d3894d08
*/

using System;
using System.Net;

// Class Name	                Journal	                                Entry	                    Prompt
// class methods	    _jahEntriesList : list<Entry>	        _jahResponse : string	           _jahPrompt : string
// 		                _jahDate : DateTime	                    _jahEntry : string                 _jahPromptList : list<string> 
//                      	                                    _jahDate : string                  _random : Random
//          
// class functions	    SaveEntry(): void	                    ToString(): string	               GeneratePrompt(): string
// 	                    SaveJournal(string username): void		ToFile(): string
// 	                    LoadJournal(string username): Entry		ToCSV(): string
// 	                    ToString(): string	                    FromCSV(): void

class Program
{
    static void Main(string[] args)
    {
        Journal jahJournal = new Journal();

        string jahMenu = "\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit\nWhat would you like to do? ";

        string jahChoice = "";

        while(jahChoice != "5")
        {
            Console.Write(jahMenu);
            jahChoice = Console.ReadLine();

            Console.WriteLine();

            if (jahChoice == "1")
            {
                Entry entry = new Entry();
                Console.Write($"{entry._jahPrompt._jahPrompt}\n>");
                entry._jahResponse = Console.ReadLine();

                jahJournal.SaveEntry(entry);
            }
            else if(jahChoice == "2")
            {
                Console.WriteLine(jahJournal);
            }
            else if (jahChoice == "3")
            {
                Console.WriteLine("What is your Username?");
                string username = Console.ReadLine();
                jahJournal.LoadJournal(username);
            }
            else if (jahChoice == "4")
            {
                Console.WriteLine("What is your Username?");
                string username = Console.ReadLine();
                jahJournal.SaveJournal(username);
            }
        }
    }
}