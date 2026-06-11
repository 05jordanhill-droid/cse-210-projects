/*
Class Name	        Program	                Word()	                Scripture()	                Reference()
class methods		                        _word: string	        _textList: list<Word>	    _book: string
		                                    _visibility: boolean		                        _chapter: int
				                                                                                _first: int
				                                                                                _last: int
				                                                                                _jahFormat: string

class functions	    Clear(): void	        Word(string word)	    Scripture(string text)	    Reference(string book, int chapter, int first, int last)
	                Display(): void	        IsVisible(): boolean	HideRandom(): void	        Reference(string book, int chapter, int first)
		                                    Hide():void	            ToString(): string	        ToString(): string
		                                    ToString(): string		
		                                    GetLen(): int				
*/

using System.Globalization;

public class Scripture
{
    private List<Word> _jahTextList;
    public Scripture(string jahText)
    {
        _jahTextList = new List<Word>();

        foreach (string jahWord in jahText.Split())
        {
            Word jahVar = new Word(jahWord);

            _jahTextList.Add(jahVar);
        }
    }
    public void HideRandom()
    {
        Random jahRandom = new Random();
        int jahIndex = -1;

        do
        {
            jahIndex = jahRandom.Next(_jahTextList.Count);
        }while((! _jahTextList[jahIndex].IsVisible()) || jahIndex == -1);

        _jahTextList[jahIndex].Hide();
    }
    public Boolean IsVisible()
    {
        Boolean jahVisibility = false;
        foreach (Word jahWord in _jahTextList)
        {
            if (jahWord.IsVisible())
            {
                jahVisibility = true;
            }
        }
        return jahVisibility;
    }
    public override string ToString()
    {
        string jahrvalue = "";
        foreach (Word jahWord in _jahTextList)
        {
            jahrvalue += $" {jahWord.ToString()}";
        }

        return jahrvalue;
    }
}