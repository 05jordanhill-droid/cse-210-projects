using System.Globalization;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

class Simulation
{
    private Battlefield _jahBattlefield;
    private List<SimulationObject> _jahSimulationObjectList;
    private int _jahInterval;

    public Simulation(int jahGridWidth, int jahGridHeight, List<SimulationObject> jahSimulationObjectList)
    {
        SetBattlefield(new Battlefield(jahGridWidth, jahGridHeight, jahSimulationObjectList));
        SetSimulationObjectList(jahSimulationObjectList);
    }
    public Simulation(int jahGridWidth, int jahGridHeight)
    {
        SetBattlefield(new Battlefield(jahGridWidth, jahGridHeight));
        SetSimulationObjectList(new());
    }
/*
    Getters / Setters
*/
    public Battlefield GetBattlefield()
    {
        return _jahBattlefield;
    }
    public void SetBattlefield(Battlefield jahBattlefield)
    {
        _jahBattlefield = jahBattlefield;
    }

    public List<SimulationObject> GetSimulationObjectList()
    {
        return _jahSimulationObjectList;
    }
    public void SetSimulationObjectList(List<SimulationObject> jahSimulationObjectList)
    {
        _jahSimulationObjectList = jahSimulationObjectList;
    }
    public void AddSimulationObject(SimulationObject jahSimulationObject)
    {
        try
        {
            GetSimulationObjectList().Add(jahSimulationObject);
        } catch
        {
            _jahSimulationObjectList = new();
            GetSimulationObjectList().Add(jahSimulationObject);
        }
        GetBattlefield().GetSimulationObjectList().Add(jahSimulationObject);
        GetBattlefield().SetGridPiece(jahSimulationObject);
    }
    public List<Character> GetCharacterList()
    {
        List<Character> jahCharacterList = new();

        foreach (SimulationObject jahObject in GetSimulationObjectList())
        {
            if(jahObject is Character)
            {
                jahCharacterList.Add((Character)jahObject);
            }
        }
        return jahCharacterList;
    }
    public void SetTimeInterval(int jahInterval)
    {
        _jahInterval = jahInterval;
    }
    public int GetTimeInterval()
    {
        return _jahInterval;
    }
/*
    Functions
*/
    public Simulation DetermineTimeInterval()
    {
        Support.Clear();
        _jahInterval = Support.GetUserInputInteger("How many seconds would you like the simulation to run freely? (ex: 10) \n>", true);
        Support.Erase(2);
        return this;
    }
    public void Resume(Character jahCharacter=null)
    {
		DateTime jahStartTime = DateTime.Now;
        DateTime jahFutureTime = jahStartTime.AddSeconds(GetTimeInterval());
        DateTime jahCurrectTime = DateTime.Now;

        while (jahCurrectTime < jahFutureTime)
        {
            jahCurrectTime = DateTime.Now;

            Support.Clear();
            TerminalDisplay.DisplayGrid<SimulationObject>(GetBattlefield().GetGrid(), var => var.GetAvatar());
            
            if(jahCharacter != null)
            {
                TerminalDisplay.DisplayStats(jahCharacter);
            }
            Support.Display($"Teams Left: {GetBattlefield().CountTeams()}\n");
            RunRound();
            Thread.Sleep(100);
        }
    }
    private void RunRound()
    {
        SetSimulationObjectList(GetTurnOrder());

        foreach(SimulationObject jahSimulationObject in GetSimulationObjectList())
        {
            jahSimulationObject.TakeTurn(GetBattlefield());
        }
        CheckForDead();
    }
    private List<SimulationObject> GetTurnOrder()
    {
        return Support.ReorderList<SimulationObject>(GetSimulationObjectList(), var => var.GetSpeed());
    }
    private void CheckForDead()
    {
        List<SimulationObject> jahRemoveList = new();

        foreach(SimulationObject jahObject in GetSimulationObjectList())
        {
            if(jahObject.GetHealth() <= 0)
            {
                SimulationObject jahEmpty = new(jahObject.GetLocation());
                GetBattlefield().SetGridPiece(jahEmpty);
                jahRemoveList.Add(jahObject);
            }
        }
        foreach(SimulationObject jahRemove in jahRemoveList)
        {
            GetSimulationObjectList().Remove(jahRemove);
            GetBattlefield().GetSimulationObjectList().Remove(jahRemove);
        }
    }
    public Mine MakeMine(Boolean rValue, string jahAvatar="X")
    {
        List<int> jahCoord = Support.GetRandomCoord<Character, SimulationObject>(
            GetBattlefield().GetGrid(),
            GetBattlefield().GetGrid()[0].Count,
            GetBattlefield().GetGrid().Count
        );
        Mine jahObject = new(jahCoord);
        AddSimulationObject(jahObject);
        jahObject.SetAvatar(jahAvatar);

        return jahObject;
    }
    public void MakeMine(string jahAvatar="X")
    {
        List<int> jahCoord = Support.GetRandomCoord<Character, SimulationObject>(
            GetBattlefield().GetGrid(),
            GetBattlefield().GetGrid()[0].Count,
            GetBattlefield().GetGrid().Count
        );
        Mine jahObject = new(jahCoord);
        AddSimulationObject(jahObject);
        jahObject.SetAvatar(jahAvatar);
    }
    public Boulder MakeBoulder(Boolean rValue, string jahAvatar="O")
    {
        List<int> jahCoord = Support.GetRandomCoord<Character, SimulationObject>(
            GetBattlefield().GetGrid(),
            GetBattlefield().GetGrid()[0].Count,
            GetBattlefield().GetGrid().Count
        );
        Boulder jahObject = new(jahCoord);
        AddSimulationObject(jahObject);
        jahObject.SetAvatar(jahAvatar);

        return jahObject;
    }
    public void MakeBoulder(string jahAvatar="O")
    {
        List<int> jahCoord = Support.GetRandomCoord<Character, SimulationObject>(
            GetBattlefield().GetGrid(),
            GetBattlefield().GetGrid()[0].Count,
            GetBattlefield().GetGrid().Count
        );
        Boulder jahObject = new(jahCoord);
        AddSimulationObject(jahObject);
        jahObject.SetAvatar(jahAvatar);
    }
    public Fighter MakeFighter(Boolean rValue, string jahAvatar="F")
    {
        List<int> jahCoord = Support.GetRandomCoord<Character, SimulationObject>(
            GetBattlefield().GetGrid(),
            GetBattlefield().GetGrid()[0].Count,
            GetBattlefield().GetGrid().Count
        );
        Fighter jahCharacter = new(jahCoord);
        AddSimulationObject(jahCharacter);
        jahCharacter.SetAvatar(jahAvatar);

        return jahCharacter;
    }
    public Rogue MakeRogue(Boolean rValue, string jahAvatar="R")
    {
        List<int> jahCoord = Support.GetRandomCoord<Character, SimulationObject>(
            GetBattlefield().GetGrid(),
            GetBattlefield().GetGrid()[0].Count,
            GetBattlefield().GetGrid().Count
        );
        Rogue jahCharacter = new(jahCoord);
        AddSimulationObject(jahCharacter);
        jahCharacter.SetAvatar(jahAvatar);

        return jahCharacter;
    }
    public Mage MakeMage(Boolean rValue, string jahAvatar="M")
    {
        List<int> jahCoord = Support.GetRandomCoord<Character, SimulationObject>(
            GetBattlefield().GetGrid(),
            GetBattlefield().GetGrid()[0].Count,
            GetBattlefield().GetGrid().Count
        );
        Mage jahCharacter = new(jahCoord);
        AddSimulationObject(jahCharacter);
        jahCharacter.SetAvatar(jahAvatar);
        
        return jahCharacter;
    }
    public void MakeFighter(string jahAvatar="F")
    {
        List<int> jahCoord = Support.GetRandomCoord<Character, SimulationObject>(
            GetBattlefield().GetGrid(),
            GetBattlefield().GetGrid()[0].Count,
            GetBattlefield().GetGrid().Count
        );
        Fighter jahCharacter = new(jahCoord);
        AddSimulationObject(jahCharacter);
        
        jahCharacter.SetAvatar(jahAvatar);
    }
    public void MakeRogue(string jahAvatar="R")
    {
        List<int> jahCoord = Support.GetRandomCoord<Character, SimulationObject>(
            GetBattlefield().GetGrid(),
            GetBattlefield().GetGrid()[0].Count,
            GetBattlefield().GetGrid().Count
        );
        Rogue jahCharacter = new(jahCoord);
        AddSimulationObject(jahCharacter);
        jahCharacter.SetAvatar(jahAvatar);
    }
    public void MakeMage(string jahAvatar="M")
    {
        List<int> jahCoord = Support.GetRandomCoord<Character, SimulationObject>(
            GetBattlefield().GetGrid(),
            GetBattlefield().GetGrid()[0].Count,
            GetBattlefield().GetGrid().Count
        );
        Mage jahCharacter = new(jahCoord);
        AddSimulationObject(jahCharacter);
        jahCharacter.SetAvatar(jahAvatar);
    }
    public void MakeMine(int jahX, int jahY, string jahAvatar="F")
    {
        Mine jahCharacter = new(jahX, jahY);
        AddSimulationObject(jahCharacter);
        jahCharacter.SetAvatar(jahAvatar);
    }
    public void MakeBoulder(int jahX, int jahY, string jahAvatar="F")
    {
        Boulder jahCharacter = new(jahX, jahY);
        AddSimulationObject(jahCharacter);
        jahCharacter.SetAvatar(jahAvatar);
    }
    
    public void MakeFighter(int jahX, int jahY, string jahAvatar="F")
    {
        Fighter jahCharacter = new(jahX, jahY);
        AddSimulationObject(jahCharacter);
        jahCharacter.SetAvatar(jahAvatar);
    }
    public void MakeRogue(int jahX, int jahY, string jahAvatar="R")
    {
        Rogue jahCharacter = new(jahX, jahY);
        AddSimulationObject(jahCharacter);
        jahCharacter.SetAvatar(jahAvatar);
    }
    public void MakeMage(int jahX, int jahY, string jahAvatar="M")
    {
        Mage jahCharacter = new(jahX, jahY);
        AddSimulationObject(jahCharacter);
        jahCharacter.SetAvatar(jahAvatar);
    }
    public void MakeRandomCharacter(string jahAvatar)
    {
        Action<string> jahAction = Support.GetRandom<Action<string>>(
            new()
            {
                (jahAvatar) => MakeFighter(),
                (jahAvatar) => MakeRogue(),
                (jahAvatar) => MakeMage()
            }
        );
        jahAction(jahAvatar);
    }
    public void MakeRandomCharacter()
    {
        Action jahAction = Support.GetRandom<Action>(
            new()
            {
                () => MakeFighter(),
                () => MakeRogue(),
                () => MakeMage()
            }
        );
        jahAction();
    }
    public Character MakeRandomCharacter(Boolean rValue)
    {
        int jahChoice = Support.GetRandomInt(3);
        
        if (jahChoice == 0)
        {
            Fighter jahCharacter = MakeFighter(true);
            return jahCharacter;

        } else if (jahChoice == 1)
        {
            Rogue jahCharacter = MakeRogue(true);
            return jahCharacter;

        } else if (jahChoice == 2)
        {
            Mage jahCharacter = MakeMage(true);
            return jahCharacter;
        }

        return null;
    }
    
    public void MakeRandomObject(string jahAvatar)
    {
        Action<string> jahAction = Support.GetRandom<Action<string>>(
            new()
            {
                (jahAvatar) => MakeMine(),
                (jahAvatar) => MakeBoulder()
            }
        );
        jahAction(jahAvatar);
    }
    public void MakeRandomObject()
    {
        Action jahAction = Support.GetRandom<Action>(
            new()
            {
                () => MakeMine(),
                () => MakeBoulder(),
            }
        );
        jahAction();
    }
    public FieldObject MakeRandomObject(Boolean rValue)
    {
        int jahChoice = Support.GetRandomInt(2);
        
        if (jahChoice == 0)
        {
            Mine jahCharacter = MakeMine(true);
            return jahCharacter;

        } else if (jahChoice == 1)
        {
            Boulder jahCharacter = MakeBoulder(true);
            return jahCharacter;

        }

        return null;
    }
    
    public void MakeRandomTeam(int jahQuantity=0)
    {
        while(jahQuantity == 0)
        {
            jahQuantity = Support.GetRandomInt(20);
        }
        Character jahPreviousCharacter = null;
        for(int i = 0; i<jahQuantity; i++)
        {
            Character jahCharacter = MakeRandomCharacter(true);
            if(jahPreviousCharacter != null)
            {
                jahCharacter.AlignWith(jahPreviousCharacter);
            }
            jahPreviousCharacter = jahCharacter;
        }
    }
}