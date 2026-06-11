public class Job
{
    public string _company;
    public string _jobTitle;
    public double _startYear;
    public double _endYear;

    public override string ToString()
    {
        string rvalue = $"{_jobTitle} ({_company}) {_startYear}-{_endYear}\n";

        return rvalue;
    }
}