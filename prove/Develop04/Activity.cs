/*
Class Name	            Program																	Activity	        														Breathing : Activity	            									Reflection : Activity	                								Enumerate : Activity
class methods		    																		_name: string																_messageList: List<string>												_promptList: List<string>												_promptList: List<string>
		                																		_description: string																																_questionList: List<string>												_responseList: List<string>
		                																		_startingMessage: string   >>>   holds _name as part of it																							_transitionMessage: string	
		                																		_duration: int			
		                																		_endingMessage: string   >>>   holds _duration and _name as part of it			
		                																		_animationList: List<string>			
		                																		_durationPrompt: string			
		                																		_genericStart: string			
		                																		_genericEnd: string			

class functions			Display(string s): void													Activity(string name, string description)									Breathing(string name, string description):base(name, description)		Reflection(string name, string description):base(name, description)		Enumerate(string name, string description):base(name, description)
						Load(int length): void													GetStartingMessage(): string   >>>   _startingMessage, _description			GetMessage(int index): string											GetPrompt(): string														GetPrompt(): void
						CountDown(): void														GetEndingMessage(): string   >>>   _endingMessage																									GetQuestion(): string													AddResponse(string response): void
						Start(Activity activity): void											GetFrame(int index): string   >>>   _animationList																									GetTranstionMessage(): string											GetResponseListLen(): int
						End(Activity activity): void											GetDuration(): int																																	Run(): void
																								SetDuration(): void			
																								GetGenericStart(): string			
																								GetGenericEnd(): string			

Name: Jordan Hill
Class: CSE-210
Sources:
	ChatGPT >>> https://chatgpt.com/share/6a2b7088-f2d0-83e8-90d9-2b030d370844
*/

using System.Globalization;

class Activity
{
    private string _jahName;
    private string _jahDescription;
    private string _jahStartingMessage;
    private int _jahDuration;
    private string _jahDurationPrompt;
    private string _jahEndingMessage;
    private List<string> _jahAnimationList;
    private string _jahGenericStart;
    private string _jahGenericEnd; 

    protected Activity(string jahName, string jahDescription)
    {
        _jahName = jahName;
        _jahDescription = jahDescription;
    }

    protected void StartingMessage()
    {
        Support.Clear();
        
        _jahStartingMessage = $"Welcome to the {_jahName} Activity.\n\n{_jahDescription}";
        _jahDurationPrompt = "\nHow long, in seconds, would you like for your session? ";
        _jahGenericStart = "Get Ready...";

        Support.Display(_jahStartingMessage);
        SetDuration(_jahDurationPrompt);

        Support.Clear();

        Support.Display(_jahGenericStart);
        Load(4);
    }

    protected void EndingMessage()
    {
        _jahGenericEnd = "\nWell Done!!";
        _jahEndingMessage = $"\nYou have completed another {_jahDuration} seconds of the {_jahName} Activity.";

        Support.Display(_jahGenericEnd);
        Support.Display(_jahEndingMessage);
        Load(4);

        Support.Clear();
    }

    private void SetDuration(string jahPrompt)
    {
        _jahDuration = Support.GetUserInputInteger(jahPrompt, true);
    }
    protected int GetDuration()
    {
        return _jahDuration;
    }

    protected void Load(int jahLength)
    {
        _jahAnimationList = ["Oo.", "oOo", ".oO", "oOo"];

        for(int i = 0; i<jahLength; i++)
        {
            RunAnimation(_jahAnimationList);
        }
    }
    protected void RunAnimation(List<string> jahAnimationList)
    {
        foreach(string jahFrame in jahAnimationList){
            Support.Display(jahFrame, true);
            Thread.Sleep(250);
            Support.Display(
                new string('\b', jahFrame.Length) +
                new string(' ', jahFrame.Length) +
                new string('\b', jahFrame.Length),
                true
            );
        }
    }

    protected void CountDown(int jahLength)
    {
        for (int i = jahLength; i > 0; i--)
        {
            Support.Display($"{i}", true);
            Thread.Sleep(1000);
            Support.Display("\b \b", true);
        }
    }
}