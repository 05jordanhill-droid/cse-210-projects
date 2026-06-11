using System.Globalization;

public class MathAssignment : Assignment
{
    private string _jahTextbookSection;
    private string _jahProblems;

    public MathAssignment(string jahName, string jahTopic, string jahTextbookSection, string jahProblems) : base(jahName, jahTopic)
    {
        _jahTextbookSection = jahTextbookSection;
        _jahProblems = jahProblems;
    }
    public string GetHomeworkList()
    {
        return $"Section {_jahTextbookSection} Problems {_jahProblems}";
    }
}