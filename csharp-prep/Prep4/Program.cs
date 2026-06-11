using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> jahNumberList = new List<int>();

        string jahRawNum;

        do
        {
            Console.Write("Enter number: ");
            jahRawNum = Console.ReadLine();
            if(jahRawNum != "0")
            {
                int jahNum = int.Parse(jahRawNum);
                jahNumberList.Add(jahNum);
            }
        }while(jahRawNum != "0");

        float jahTotal = 0;
        int jahLargestNum = -1;
        int jahSmallestPosNum = 999999;
        foreach(int num in jahNumberList)
        {
            jahTotal += num;
            
            if(num > jahLargestNum)
            {
                jahLargestNum = num;
            }
            
            if((num > 0) && (num < jahSmallestPosNum))
            {
                jahSmallestPosNum = num;
            }
        }
        float jahAvgNum = jahTotal / jahNumberList.Count;

        jahNumberList.Sort();

        Console.WriteLine($"The sum is: {jahTotal}");
        Console.WriteLine($"The average is: {jahAvgNum}");
        Console.WriteLine($"The largest number is: {jahLargestNum}");
        Console.WriteLine($"The smallest positive number is: {jahSmallestPosNum}");
        Console.WriteLine($"The sorted list is:");

        foreach(int num in jahNumberList)
        {
            Console.WriteLine(num);
        }
    }
}