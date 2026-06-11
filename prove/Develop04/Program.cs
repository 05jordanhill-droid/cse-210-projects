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


Source:
	ChatGPT >>> https://chatgpt.com/share/6a2adf07-1f70-83e8-bd51-b2caf74e89ca
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");

		Breathing jahBreathing = new Breathing("Breathing", "Breathing Description");
		jahBreathing.Run();
    }
}