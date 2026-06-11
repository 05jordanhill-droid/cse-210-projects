using System.Globalization;

public class WritingAssignment : Assignment
{
    private string _jahTitle;

    public WritingAssignment(string jahName, string jahTopic, string jahTitle) : base(jahName, jahTopic)
    {
        _jahTitle = jahTitle;
    }
    public string GetWritingInformation()
    {
        string jahAuthor = GetStudentName();
        return $"{_jahTitle} by {jahAuthor}";
    }
}