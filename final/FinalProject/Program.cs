using System;

class Program
{
    static void Main(string[] args)
    {
        Support.Clear();
        
        Simulation jahSimulation = new Simulation(30, 20);

        List<string> jahKeyList = new()
        {
            "Resume",
            "Set Time Intervals",
            "Set Battlefield"
        };
        List<Func<Object, Object>> jahValueList = new()
        {
            (jahSimulation) => Resume((Simulation)jahSimulation),
            (jahSimulation) => DetermineTimeInterval((Simulation)jahSimulation),
            (jahSimulation) => BattleFieldMenu((Simulation)jahSimulation)
        };

        Support.RunMenu(jahKeyList, jahValueList, jahSimulation);
        Support.Clear();
    }
    static Simulation Resume(Simulation jahSimulation)
    {
        Support.Clear();

        if(jahSimulation.GetTimeInterval() <= 0)
        {
            Support.Display("Please provide a valid time interval. ");
        }
        if(jahSimulation.GetSimulationObjectList().Count <= 0)
        {
            Support.Display("Please set objects to the battlefield. ");
        }
        if(jahSimulation.GetSimulationObjectList().Count > 0 && jahSimulation.GetTimeInterval() > 0)
        {            
            jahSimulation.Resume();
        }
        return jahSimulation;
    }
    static Simulation DetermineTimeInterval(Simulation jahSimulation)
    {
        jahSimulation.DetermineTimeInterval();
        return jahSimulation;
    }
    static Simulation BattleFieldMenu(Simulation jahSimulation)
    {
        Support.Clear();

        List<string> jahKeyList = new()
        {
            "Add Character",
            "Add Team",
            "Add Object"
        };
        List<Func<Object, Object>> jahValueList = new()
        {
            (jahSimulation) => AddCharacterMenu((Simulation)jahSimulation),
            (jahSimulation) => AddTeamMenu((Simulation)jahSimulation),
            (jahSimulation) => AddObjectMenu((Simulation)jahSimulation)
        };

        Support.RunMenu(jahKeyList, jahValueList, jahSimulation);
        Support.Clear();

        return jahSimulation;
    }

    static Simulation AddTeamMenu(Simulation jahSimulation)
    {
        Support.Clear();

        List<string> jahKeyList = new()
        {
            "Add Random"
        };
        List<Func<Object, Object>> jahValueList = new()
        {
            (jahSimulation) => AddRandomTeam((Simulation)jahSimulation)
        };

        Support.RunMenu(jahKeyList, jahValueList, jahSimulation);
        Support.Clear();

        return jahSimulation;
    }
    static Simulation AddRandomTeam(Simulation jahSimulation)
    {
        jahSimulation.MakeRandomTeam();
        return jahSimulation;
    }
    static Simulation AddCharacterMenu(Simulation jahSimulation)
    {
        Support.Clear();

        List<string> jahKeyList = new()
        {
            "Add Random",
            "Add Fighter",
            "Add Rogue",
            "Add Mage"
        };
        List<Func<Object, Object>> jahValueList = new()
        {
            (jahSimulation) => AddRandom((Simulation)jahSimulation),
            (jahSimulation) => AddFighter((Simulation)jahSimulation),
            (jahSimulation) => AddRogue((Simulation)jahSimulation),
            (jahSimulation) => AddMage((Simulation)jahSimulation),
        };

        Support.RunMenu(jahKeyList, jahValueList, jahSimulation);
        Support.Clear();

        return jahSimulation;
    }
    static Simulation AddRandom(Simulation jahSimulation)
    {
        jahSimulation.MakeRandomCharacter();
        return jahSimulation;
    }
    static Simulation AddObjectMenu(Simulation jahSimulation)
    {
        Support.Clear();

        List<string> jahKeyList = new()
        {
            "Add Random",
            "Add Mine",
            "Add Boulder"
        };
        List<Func<Object, Object>> jahValueList = new()
        {
            (jahSimulation) => AddRandomObject((Simulation)jahSimulation),
            (jahSimulation) => AddMine((Simulation)jahSimulation),
            (jahSimulation) => AddBoulder((Simulation)jahSimulation),
        };

        Support.RunMenu(jahKeyList, jahValueList, jahSimulation);
        Support.Clear();

        return jahSimulation;
    }
    static Simulation AddRandomObject(Simulation jahSimulation)
    {
        jahSimulation.MakeRandomObject();
        return jahSimulation;
    }
    static Simulation AddMine(Simulation jahSimulation)
    {
        Support.Clear();
        int jahX = Support.GetUserInputInteger("What is your desired x-coordinate? ", true);
        int jahY = Support.GetUserInputInteger("What is your desired y-coordinate? ", true);
        string jahAvatar = "  ";

        while(jahAvatar.Length != 1)
        {
            jahAvatar = Support.GetUserInputString("What is your desired Avatar? (Enter a single character) ", true);
            
            if(jahAvatar.Length != 1)
            {
                Support.Display("Invalid Input. Try Again.");
            }
        }
        
        jahSimulation.MakeMine(jahX, jahY, jahAvatar);
        return jahSimulation;
    }
    static Simulation AddBoulder(Simulation jahSimulation)
    {
        Support.Clear();
        int jahX = Support.GetUserInputInteger("What is your desired x-coordinate? ", true);
        int jahY = Support.GetUserInputInteger("What is your desired y-coordinate? ", true);
        string jahAvatar = "  ";

        while(jahAvatar.Length != 1)
        {
            jahAvatar = Support.GetUserInputString("What is your desired Avatar? (Enter a single character) ", true);
            
            if(jahAvatar.Length != 1)
            {
                Support.Display("Invalid Input. Try Again.");
            }
        }
        
        jahSimulation.MakeBoulder(jahX, jahY, jahAvatar);
        return jahSimulation;
    }
    static Simulation AddFighter(Simulation jahSimulation)
    {
        Support.Clear();
        int jahX = Support.GetUserInputInteger("What is your desired x-coordinate? ", true);
        int jahY = Support.GetUserInputInteger("What is your desired y-coordinate? ", true);
        string jahAvatar = "  ";

        while(jahAvatar.Length != 1)
        {
            jahAvatar = Support.GetUserInputString("What is your desired Avatar? (Enter a single character) ", true);
            
            if(jahAvatar.Length != 1)
            {
                Support.Display("Invalid Input. Try Again.");
            }
        }
        
        jahSimulation.MakeFighter(jahX, jahY, jahAvatar);
        return jahSimulation;
    }
    static Simulation AddRogue(Simulation jahSimulation)
    {
        Support.Clear();
        int jahX = Support.GetUserInputInteger("What is your desired x-coordinate? ", true);
        int jahY = Support.GetUserInputInteger("What is your desired y-coordinate? ", true);
        string jahAvatar = "  ";

        while(jahAvatar.Length != 1)
        {
            jahAvatar = Support.GetUserInputString("What is your desired Avatar? (Enter a single character) ", true);
            
            if(jahAvatar.Length != 1)
            {
                Support.Display("Invalid Input. Try Again.");
            }
        }
        
        jahSimulation.MakeRogue(jahX, jahY, jahAvatar);
        return jahSimulation;
    }
    static Simulation AddMage(Simulation jahSimulation)
    {
        Support.Clear();
        int jahX = Support.GetUserInputInteger("What is your desired x-coordinate? ", true);
        int jahY = Support.GetUserInputInteger("What is your desired y-coordinate? ", true);
        string jahAvatar = "  ";

        while(jahAvatar.Length != 1)
        {
            jahAvatar = Support.GetUserInputString("What is your desired Avatar? (Enter a single character) ", true);
            
            if(jahAvatar.Length != 1)
            {
                Support.Display("Invalid Input. Try Again.");
            }
        }
        
        jahSimulation.MakeMage(jahX, jahY, jahAvatar);
        return jahSimulation;
    }
}