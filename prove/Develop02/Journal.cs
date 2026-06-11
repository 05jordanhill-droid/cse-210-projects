using System.Globalization;
using System.IO;

// Class Name	                Journal	                                Entry	                    Prompt
// class methods	    _jahEntriesList : list<Entry>	        _jahResponse : string	           _jahPrompt : string
// 		                _jahDate : DateTime	                    _jahEntry : string                 _jahPromptList : list<string> 
//                      	                                    _jahDate : string                  _random : Random
//          
// class functions	    SaveEntry(): void	                    ToString(): string	               GeneratePrompt(): string
// 	                    SaveJournal(string username): void		ToFile(): string
// 	                    LoadJournal(string username): Entry		ToCSV(): string
// 	                    ToString(): string	                    FromCSV(): void
public class Journal
{
    public List<Entry> _jahEntriesList = new List<Entry>();
    public DateTime _jahDate;

    public void SaveEntry(Entry entry)
    {
        _jahEntriesList.Add(entry);
    }
    
    public void SaveJournal(string username)
    {
        string filename = $"{username}.csv";
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine("Date, Prompt, Response");
            foreach(Entry entry in _jahEntriesList)
            {
                outputFile.WriteLine($"{entry.ToFile()}");
            }
        }
    }

    public void LoadJournal(string username)
    {
        string filename = $"{username}.csv";
        string[] lines = System.IO.File.ReadAllLines(filename);

        _jahEntriesList = [];

        foreach (string rawLine in lines)
        {
            if(rawLine != "Date, Prompt, Response")
            {
                string line = rawLine.Substring(1, rawLine.Length - 2);

                line = line.Replace("\"\",\"\"", "~~|ascii|~~");

                string[] parts = line.Split("\",\"");

                string date = parts[0];
                string prompt = parts[1];
                string response = parts[2];

                Entry entry = new Entry();
                entry._jahDate = date;
                entry._jahPrompt._jahPrompt = prompt;
                entry._jahResponse = response;

                entry.FromCSV();

                this.SaveEntry(entry);
            }
        }
    }

    public override string ToString()
    {
        string rvalue = "";

        foreach(Entry entry in _jahEntriesList)
        {
            rvalue += $"{entry}\n";
        }

        return rvalue;
    }
}