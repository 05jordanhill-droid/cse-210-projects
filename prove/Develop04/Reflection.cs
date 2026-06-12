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

class Reflection : Activity
{
	private List<string> _jahPromptList;
	private List<string> _jahQuestionList;
	private List<string> _jahUsedPromptList;
	private List<string> _jahUsedQuestionList;

    public Reflection(string name, string description):base(name, description)
	{
		_jahPromptList = [
			"Think of a time when you stood up for someone else.",
			"Think of a time when you did something really difficult.",
			"Think of a time when you helped someone in need.",
			"Think of a time when you did something truly selfless."
		];
		_jahQuestionList = [
			"Why was this experience meaningful to you?",
			"Have you ever done anything like this before?",
			"How did you get started?",
			"How did you feel when it was complete?",
			"What made this time different than other times when you were not as successful?",
			"What is your favorite thing about this experience?",
			"What could you learn from this experience that applies to other situations?",
			"What did you learn about yourself through this experience?",
			"How can you keep this experience in mind in the future?"
		];
		_jahUsedPromptList = [];
		_jahUsedQuestionList = [];
	}

	public void Run()
	{
		StartingMessage();
		Middle();
		EndingMessage();
	}

	private void Middle()
	{
		Support.Display("Consider the following prompt:\n");

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

		Support.Display("\nWhen you have something in mind, please press enter to continue.");
		Support.GetEmptyInput();

		Support.Display("Now think on the following questions as they relate to this experience.");
		Support.Display("You may begin in: ");
		CountDown(5);

		Support.Clear();

		DateTime jahStartTime = DateTime.Now;
        DateTime jahFutureTime = jahStartTime.AddSeconds(GetDuration());
        DateTime jahCurrectTime = DateTime.Now;
        while (jahCurrectTime < jahFutureTime)
        {
            jahCurrectTime = DateTime.Now;


            string jahQuestion = Support.GetRandomString(_jahQuestionList);
			if (jahQuestion == "ERROR: EMPTY LIST")
			{
				_jahQuestionList = _jahUsedQuestionList;
				_jahUsedQuestionList.Clear();
	            jahQuestion = Support.GetRandomString(_jahQuestionList);
			}
			else
			{
				_jahQuestionList.Remove(jahQuestion);
				_jahUsedQuestionList.Add(jahQuestion);
			}

			Support.Display($"> {jahQuestion} ", true);

			Load(10);

			Support.Display("");
        }
	}
}