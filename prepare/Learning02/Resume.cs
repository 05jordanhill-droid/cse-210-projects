using System.Globalization;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public override string ToString()
    {
        string rvalue = "";
        rvalue += $"Name: {_name}\n";
        rvalue += "Jobs:\n";

        foreach (Job job in _jobs)
        {
            rvalue += job.ToString();
        }

        return rvalue;
    }
}