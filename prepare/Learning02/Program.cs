using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");

        Job jahJob1 = new Job();
        jahJob1._company = "Microsoft";
        jahJob1._jobTitle = "Engineer";
        jahJob1._startYear = 2000;
        jahJob1._endYear = 2015;

        Job jahJob2 = new Job();
        jahJob2._company = "Google";
        jahJob2._jobTitle = "HR";
        jahJob2._startYear = 2005;
        jahJob2._endYear = 2007;

        Resume jahJobs = new Resume();

        jahJobs._name = "Jordan Hill";

        jahJobs._jobs.Add(jahJob1);
        jahJobs._jobs.Add(jahJob2);
        
        Console.WriteLine(jahJob1);
        Console.WriteLine(jahJob2);
        Console.WriteLine(jahJobs);
    }
}