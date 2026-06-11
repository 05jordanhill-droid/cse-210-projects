/*
Class Name	            Program							Activity	        														Breathing : Activity	            									Reflection : Activity	                								Enumerate : Activity
class methods		    								_name: string																_messageList: List<string>												_promptList: List<string>												_promptList: List<string>
		                								_description: string																																_questionList: List<string>												_responseList: List<string>
		                								_startingMessage: string   >>>   holds _name as part of it																							_transitionMessage: string	
		                								_duration: int			
		                								_endingMessage: string   >>>   holds _duration and _name as part of it			
		                								_animationList: List<string>			
		                								_durationPrompt: string			
		                								_genericStart: string			
		                								_genericEnd: string			

class functions			Display(string s): void			Activity(string name, string description)									Breathing(string name, string description):base(name, description)		Reflection(string name, string description):base(name, description)		Enumerate(string name, string description):base(name, description)
						Load(int length): void			GetStartingMessage(): string   >>>   _startingMessage, _description			GetMessage(int index): string											GetPrompt(): string														GetPrompt(): void
						CountDown(): void				GetEndingMessage(): string   >>>   _endingMessage																									GetQuestion(): string													AddResponse(string response): void
						Start(Activity activity): void	GetFrame(int index): string   >>>   _animationList																									GetTranstionMessage(): string											GetResponseListLen(): int
						End(Activity activity): void	GetDuration(): int																																	Run(): void
														SetDuration(): void			
														GetGenericStart(): string			
														GetGenericEnd(): string			
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
        _jahStartingMessage = $"Welcome to the {_jahName} Activity.\n\n {_jahDescription}";
        _jahGenericStart = "Get Ready...";
        _jahDurationPrompt = "How long, in seconds, would you like for your session? ";

        Support.Display(_jahStartingMessage);
        SetDuration(_jahDurationPrompt);
        Support.Display(_jahGenericStart);
        Load();
    }

    protected void EndingMessage()
    {
        _jahGenericEnd = "\nWell Done!!\n";
        _jahEndingMessage = $"You have completed another {_jahDuration} seconds of the {_jahName} Activity.";

        Support.Display(_jahGenericEnd);
        Support.Display(_jahEndingMessage);
        Load();
    }

    private void SetDuration(string jahPrompt)
    {
        _jahDuration = Support.GetUserInputInteger(jahPrompt);
    }
    protected int GetDuration()
    {
        return _jahDuration;
    }

    protected void Load()
    {
        _jahAnimationList = ["Oo.", "oOo", ".oO", "oOo"];

        RunAnimation(_jahAnimationList);
        RunAnimation(_jahAnimationList);
    }
    protected void RunAnimation(List<string> jahAnimationList)
    {
        foreach(string jahFrame in jahAnimationList){
            Support.Display(jahFrame, true);
            Thread.Sleep(500);
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