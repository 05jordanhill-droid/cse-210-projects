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

using System;

class Program
{
    static void Main(string[] args)
    {
		Breathing jahBreathing = new Breathing("Breathing", "Breathing Description");
		Reflection jahReflection = new Reflection("Reflecting", "Reflecting Description");
		Enumerate jahEnumerate = new Enumerate("Listing", "Listing Description");

		string jahChoice = "";

		while (jahChoice != "4")
		{
			Support.Display("Menu Options:");
			Support.Display("  1. Start breathing activity");
			Support.Display("  2. Start reflection activity");
			Support.Display("  3. Start listing activity");
			Support.Display("  4. Quit");
			jahChoice = Support.GetUserInputString("Select a choice from the menu: ", true);

			if (jahChoice == "1")
			{
				jahBreathing.Run();
			}
			else if (jahChoice == "2")
			{
				jahReflection.Run();
			}
			else if (jahChoice == "3")
			{
				jahEnumerate.Run();
			}
		}
    }
}