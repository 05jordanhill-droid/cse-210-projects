// Class Name	    Program	Goal	        Simple : Goal	    Eternal : Goal	Checklist : Goal
// class methods	goalList: List<Goal>	_value: int			                _bonus: int
// 	                score: int	            _checked: boolean			        _length: int
// 		            _name: string			_progress: int
// 		            _description: string			
				
// class functions		Goal(string name, string description, int value)	Simple(string name, string description, int value):base(name, description, value)	Eternal(string name, string description, int value):base(name, description, value)	    Checklist(string name, string description, int value, int bonus, int length):base(name, description, value)
// 		                GetName(): string		                                                                                                                override Check(score): Abstract int	                                                    override GetInfo(): string
// 		                GetDescription(): string			                                                                                                                                                                                            override Check(score): Abstract int
// 		                GetStatus(): string			
// 		                GetInfo(): Abstract string			
// 		                Check(score): Virtual int			
					
// Name: Jordan Hill
// Class: CSE-210
// Sources:
// 	ChatGPT (General help) >>> https://chatgpt.com/share/6a455f3b-c7a0-83e8-b269-a701057565ed
//  ChatGPT (Support Class help) >>> https://chatgpt.com/share/6a455eec-0bdc-83e8-be60-65997fc82051

// Stretch:
//      I took into account the usage of commas in the entries when saving and loading. 
//      I also spents a VEHEMENT amount of hours working on Support functions to get them to be able to load and 
//         save the data in a manner that wasn't simply specific to this program but to future programs as well. 
//      Getting it to the point where it started to actually work was extremely gratifying at 1 in the morning.

using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> jahGoalList = new List<Goal>();

        int jahScore = 0;
        string jahChoice = "";
        while(jahChoice != "6")
        {
            jahChoice = DisplayMenu(jahScore);
            
            if(jahChoice == "1")
            {
                string jahGChoice = DisplayGoalTypes();

                string jahName = Support.GetUserInputString("What is the name of your goal? ", true);
                string jahDescription = Support.GetUserInputString("What is a short description of it? ", true);
                int jahValue = Support.GetUserInputInteger("What is the amount of points associated with this goal? ", true);

                if(jahGChoice == "1")
                {
                    Simple jahGoal = new Simple(jahName, jahDescription, jahValue);
                    jahGoalList.Add(jahGoal);
                } else if(jahGChoice == "2")
                {
                    Eternal jahGoal = new Eternal(jahName, jahDescription, jahValue);  
                    jahGoalList.Add(jahGoal);
                }
                else if (jahGChoice == "3")
                {
                    int jahLength = Support.GetUserInputInteger("How many times does this goal need to be accomplished for a bonus? ", true);
                    int jahBonus = Support.GetUserInputInteger("What is the bonus for accomplishing it that many times? ", true);
                    Checklist jahGoal = new Checklist(jahName, jahDescription, jahValue, jahBonus, jahLength);
                    jahGoalList.Add(jahGoal);
                }
            } else if (jahChoice == "2")
            {
                Support.Display("The goals are: ");
                
                for(int i = 0; i < jahGoalList.Count; i++)
                {
                    Support.Display($"{i+1}. {jahGoalList[i].GetInfo()}");
                }
            } else if (jahChoice == "3")
            {
                string jahFileName = Support.GetUserInputString("What is your username? ", true);

                Dictionary<string, Object> jahDict = new Dictionary<string, Object>();
                jahDict["score"] = jahScore;
                jahDict["simple"] = new List<Object>();
                jahDict["eternal"] = new List<Object>();
                jahDict["checklist"] = new List<Object>();

                foreach(Goal jahGoal in jahGoalList){
                    ((List<Object>)jahDict
                    [
                        jahGoal.GetTypeName()
                    ]
                    ).Add(jahGoal.GetBundledInfo());
                }

                Support.SaveAsFile(jahDict, jahFileName);

            } else if (jahChoice == "4")
            {
                string jahFileName = Support.GetUserInputString("What is your username? ", true);
                Dictionary<string, Object> jahDict = Support.LoadDictFile(jahFileName);
                jahGoalList.Clear();
                
                foreach(string jahKey in jahDict.Keys){
                    if (jahKey == "score")
                    {
                        jahScore = (int)jahDict["score"];
                    } else if (jahKey == "simple")
                    {
                        foreach (List<Object> jahBundledInfo in (List<Object>)jahDict[jahKey])
                        {
                            Simple jahGoal = new Simple(jahBundledInfo);
                            jahGoalList.Add(jahGoal);
                        }
                    } else if (jahKey == "eternal")
                    {
                        foreach (List<Object> jahBundledInfo in (List<Object>)jahDict[jahKey])
                        {
                            Eternal jahGoal = new Eternal(jahBundledInfo);
                            jahGoalList.Add(jahGoal);
                        }
                    } else if (jahKey == "checklist")
                    {
                        foreach (List<Object> jahBundledInfo in (List<Object>)jahDict[jahKey])
                        {
                            Checklist jahGoal = new Checklist(jahBundledInfo);
                            jahGoalList.Add(jahGoal);
                        }
                    }
                }
            } else if (jahChoice == "5")
            {
                Support.Display("The goals are: ");
                
                for(int i = 0; i < jahGoalList.Count; i++)
                {
                    Support.Display($"{i+1}. {jahGoalList[i].GetName()}");
                }

                int jahChecked = Support.GetUserInputInteger("Which goal did you accomplish? ", true) - 1;

                int jahIncrease = jahGoalList[jahChecked].Check();
                jahScore += jahIncrease;

                Support.Display($"Congratulations! You have earned {jahIncrease} points!");
                Support.Display($"You now have {jahScore} points.");
            }
        }
    }

    static string DisplayMenu(int jahScore)
    {
        Support.Display($"\nYou have {jahScore} points.\n");
        Support.Display($"Menu Options: ");
        Support.Display($"  1. Create New Goal");
        Support.Display($"  2. List Goals");
        Support.Display($"  3. Save Goals");
        Support.Display($"  4. Load Goals");
        Support.Display($"  5. Record Event");
        Support.Display($"  6. Quit");
        return Support.GetUserInputString($"Select a choice from the menu: ", true);
    }
    static string DisplayGoalTypes()
    {
        Support.Display($"The Types of Goals are: ");
        Support.Display($"  1. Simple Goal");
        Support.Display($"  2. Eternal Goal");
        Support.Display($"  3. Checklist Goal");
        return Support.GetUserInputString($"Which type of goal would you like to create? ", true);
    }
}