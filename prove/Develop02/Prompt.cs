using System.Globalization;

// Class Name	                Journal	                                Entry	                    Prompt
// class methods	    _jahEntriesList : list<Entry>	        _jahResponse : string	           _jahPrompt : string
// 		                _jahDate : DateTime	                    _jahEntry : string                 _jahPromptList : list<string> 
//                      	                                    _jahDate : string                  _random : Random
//          
// class functions	    SaveEntry(): void	                    ToString(): string	               GeneratePrompt(): string
// 	                    SaveJournal(string username): void		ToFile(): string
// 	                    LoadJournal(string username): Entry		ToCSV(): string
// 	                    ToString(): string	                    FromCSV(): void
public class Prompt
{
    public List<string> _jahPromptList = new List<string>()
    {
        "What emotion dominated your day today?",
        "What are you avoiding thinking about?",
        "What do you wish people understood about you?",
        "What part of yourself have you been neglecting?",
        "What motivates you lately?",
        "What drains your energy most?",
        "What do you need more of in your life?",
        "What are you pretending not to know?",
        "What belief about yourself has changed over time?",
        "What does your ideal version of yourself look like?",
        "Describe your day in detail.",
        "What was the best moment today?",
        "What frustrated you today?",
        "What made you laugh recently?",
        "What small thing are you grateful for?",
        "What did you learn today?",
        "What conversation stuck with you?",
        "What would you change about today?",
        "What are you looking forward to tomorrow?",
        "Describe today using only five words.",
        "Invent a fictional city.",
        "Describe a dream you remember.",
        "Write about a door that should never be opened.",
        "Create a character based on your current mood.",
        "Write a scene with no dialogue.",
        "Describe a world where memories are currency.",
        "What would happen if time suddenly froze?",
        "Write from the perspective of a shadow.",
        "Invent a new holiday and its traditions.",
        "Describe the ocean to someone who has never seen water.",
        "What gives life meaning to you?",
        "Is happiness a goal or a byproduct?",
        "What does freedom mean?",
        "What would you do if failure were impossible?",
        "What is something society gets wrong?",
        "Are people fundamentally good?",
        "What would make you feel fulfilled?",
        "What legacy do you want to leave?",
        "When have you felt most alive?",
        "What truths are difficult to accept?",
        "What thoughts keep repeating in your mind?",
        "What helps you feel calm?",
        "What emotion do you struggle expressing?",
        "What are your emotional triggers?",
        "What would healing look like for you?",
        "What habits improve your mental state?",
        "What boundaries do you need?",
        "What fear has too much control over you?",
        "What do you need to forgive yourself for?",
        "What does rest mean to you?",
        "Who has influenced you most?",
        "What qualities do you value in friendships?",
        "Describe someone you miss.",
        "What makes you feel understood?",
        "What relationship changed you permanently?",
        "What do you appreciate about your family?",
        "What kind of partner or friend do you want to be?",
        "What conversation do you wish you could have?",
        "When did you last feel truly connected to someone?",
        "What does trust mean to you?",
        "What are your current goals?",
        "What is stopping your progress?",
        "What would your future self thank you for?",
        "What skill do you want to develop?",
        "What does success look like to you?",
        "What are your priorities right now?",
        "What would improve your life by 1 percent daily?",
        "What are you procrastinating on?",
        "What achievement are you proud of?",
        "What risks are worth taking?",
        "List three good things from today.",
        "What comfort are you thankful for?",
        "What memory always makes you smile?",
        "Who deserves more appreciation?",
        "What place makes you feel peaceful?",
        "What ability are you grateful to have?",
        "What challenge helped you grow?",
        "What simple pleasure do you love?",
        "What is beautiful about your current life?",
        "What gives you hope?",
        "What are you jealous of?",
        "What insecurity affects you most?",
        "When were you recently dishonest?",
        "What do you regret?",
        "What criticism hurt because it was true?",
        "What are you afraid people will discover about you?",
        "What do you need to let go of?",
        "Where are you wasting your time?",
        "What responsibility are you avoiding?",
        "What truth keeps resurfacing?",
        "If your life had a soundtrack, what songs would be on it?",
        "Which fictional world would you live in?",
        "What superpower would become annoying?",
        "What would your younger self think of you?",
        "Describe your perfect rainy day.",
        "If you could relive one day, which would it be?",
        "What food perfectly represents your personality?",
        "What would your autobiography be titled?",
        "What object best represents your current life?",
        "If your thoughts became visible, what would people see?"
    };
    public string _jahPrompt;
    public Random _random = new Random();

    public Prompt()
    {
        _jahPrompt = GeneratePrompt();
    }

    public string GeneratePrompt()
    {
        _jahPrompt = _jahPromptList[_random.Next(_jahPromptList.Count)];
        return _jahPrompt;
    }
}