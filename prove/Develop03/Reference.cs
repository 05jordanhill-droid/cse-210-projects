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

public class Reference
{
    private string _jahBook;
    private int _jahChapter;
    private int _jahFirst;
    private int _jahLast;
    private string _jahFormat;

    public Reference(string jahBook, int jahChapter, int jahFirst, int jahLast)
    {
        _jahBook = jahBook;
        _jahChapter = jahChapter;
        _jahFirst = jahFirst;
        _jahLast = jahLast;

        _jahFormat = $"{_jahBook} {_jahChapter}:{_jahFirst}-{_jahLast}";
    }
    public Reference(string jahBook, int jahChapter, int jahFirst)
    {
        _jahBook = jahBook;
        _jahChapter = jahChapter;
        _jahFirst = jahFirst;

        _jahFormat = $"{_jahBook} {_jahChapter}:{_jahFirst}";
    }
    public override string ToString()
    {
        return _jahFormat;
    }
}