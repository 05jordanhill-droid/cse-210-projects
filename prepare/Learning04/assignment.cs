using System.Globalization;

public class Assignment
{
    private string _jahStudentName;
    private string _jahTopic;

    public Assignment(string jahName, string jahTopic)
    {
        _jahStudentName = jahName;
        _jahTopic = jahTopic;
    }
    public string GetStudentName()
    {
        return _jahStudentName;
    }
    public string GetSummary()
    {
        return $"{_jahStudentName} - {_jahTopic}";
    }
}