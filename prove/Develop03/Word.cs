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

public class Word
{
    private string _jahWord;
    private Boolean _jahVisibility;

	public Word(string jahWord){
		_jahWord = jahWord;
		_jahVisibility = true;
	}
	public Boolean IsVisible()
	{
		return _jahVisibility;
	}
	public void Hide()
	{
		_jahVisibility = false;
	}
	public int GetLen()
	{
		return _jahWord.Length;
	}
    public override string ToString()
    {
		if (IsVisible())
		{
        	return _jahWord;
		}
		else
		{
			return new string('_', GetLen());
		}
    }
}