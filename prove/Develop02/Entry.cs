using System.Globalization;

// Class Name	                Journal	                                Entry	                    Prompt
// class methods	    _jahEntriesList : list<Entry>	        _jahResponse : string	           _jahPrompt : string
// 		                _jahDate : DateTime	                    _jahEntry : string                 _jahPromptList : list<string> 
//                      	                                    _jahDate : string                  _random : Random
//          
// class functions	    SaveEntry(): void	                    ToString(): string	               GeneratePrompt(): string
// 	                    SaveJournal(string username): void		ToFile(): string
// 	                    LoadJournal(string username): Entry		ToCSV(): string
// 	                    ToString(): string	                    FromCSV(): void
public class Entry
{
    public string _jahResponse;
    public Prompt _jahPrompt = new Prompt();
    public string _jahDate;

    public Entry()
    {
        _jahPrompt.GeneratePrompt();

        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        _jahDate = dateText;
    }

    public string ToFile()
    {
        string rvalue = $"\"{ToCSV(_jahDate)}\",\"{ToCSV(_jahPrompt._jahPrompt)}\",\"{ToCSV(_jahResponse)}\"";
        return rvalue;
    }

    public string ToCSV(string element)
    {
        element = element.Replace("\"", "\"\"");
        // element = element.Replace(",", ",,");

        return element;
    }

    public void FromCSV()
    {
        this._jahDate = this._jahDate.Replace("~~|ascii|~~", "\"\",\"\"");
        this._jahDate =_jahDate.Replace("\"\"", "\"");

        this._jahPrompt._jahPrompt = this._jahPrompt._jahPrompt.Replace("~~|ascii|~~", "\"\",\"\"");
        this._jahPrompt._jahPrompt = _jahPrompt._jahPrompt.Replace("\"\"", "\"");

        this._jahResponse = this._jahResponse.Replace("~~|ascii|~~", "\"\",\"\"");
        this._jahResponse =_jahResponse.Replace("\"\"", "\"");
    }

    public override string ToString()
    {
        string rvalue = $"Date: {_jahDate} - Prompt: {_jahPrompt._jahPrompt}\n{_jahResponse}\n";
        return rvalue;
    }
}