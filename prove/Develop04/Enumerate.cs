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

class Enumerate : Activity
{
    List<string> _jahPromptList;
    List<string> _jahResponseList;
    List<string> _jahUsedPromptList;

	public Enumerate(string name, string description):base(name, description)
	{
		_jahPromptList = [
			"Who are people that you appreciate?",
			"What are personal strengths of yours?",
			"Who are people that you have helped this week?",
			"When have you felt the Holy Ghost this month?",
			"Who are some of your personal heroes?"
		];

		_jahResponseList = [];

		_jahUsedPromptList = [];
	}

	public void Run()
	{
		StartingMessage();
		Middle();
		EndingMessage();
	}

	public void Middle()
	{
		_jahResponseList = [];

		Support.Display("List as many responses as you can to the following prompt:");

		string jahPrompt = Support.GetRandomString(_jahPromptList);
		if (jahPrompt == "ERROR: EMPTY LIST")
		{
			_jahPromptList = _jahUsedPromptList;
			_jahUsedPromptList.Clear();
			jahPrompt = Support.GetRandomString(_jahPromptList);
		}
		else
		{
			_jahPromptList.Remove(jahPrompt);
			_jahUsedPromptList.Add(jahPrompt);
		}

		Support.Display($" --- {jahPrompt} --- ");

		Support.Display("You may begin in: ", true);
		CountDown(5);

		Support.Display("");

		DateTime jahStartTime = DateTime.Now;
        DateTime jahFutureTime = jahStartTime.AddSeconds(GetDuration());
        DateTime jahCurrectTime = DateTime.Now;
        while (jahCurrectTime < jahFutureTime)
        {
            jahCurrectTime = DateTime.Now;

            string jahResponse = Support.GetUserInputString("> ", true);
			_jahResponseList.Add(jahResponse);
        }

		Support.Display("");
		Support.Display($"You listed {_jahResponseList.Count} items! ");
	}
}