using System.Dynamic;
using System.Globalization;

class Character : SimulationObject
{
    private int _jahStrength;
    private int _jahRange;
    private Team _jahTeam;

    public Character(int jahStrength, int jahHealth, int jahDefense, int jahSpeed, int jahEvasion, int jahPerception, string jahPriority, int jahPositionX, int jahPositionY, int jahFieldOfViewRadius=1, int jahRange=1) : base(jahHealth, jahDefense, jahSpeed, jahEvasion, jahPerception, jahPriority, jahPositionX, jahPositionY, jahFieldOfViewRadius)
    {
        SetRange(jahRange);
        SetStrength(jahStrength);
        SetTeam(new(new(){this}));
    }
    public Character(int jahStrength, int jahHealth, int jahDefense, int jahSpeed, int jahEvasion, int jahPerception, string jahPriority, List<int> jahLocation, int jahFieldOfViewRadius=1, int jahRange=1) : base(jahHealth, jahDefense, jahSpeed, jahEvasion, jahPerception, jahPriority, jahLocation, jahFieldOfViewRadius)
    {
        SetRange(jahRange);
        SetStrength(jahStrength);
        SetTeam(new(new(){this}));
    }
    public Character(int jahXPosition, int jahYPosition) : base(jahXPosition, jahYPosition)
    {
        SetRange(0);
        SetStrength(0);
        SetPerception(0);
        SetTeam(new(new(){this}));
    }
    public Character(List<int> jahLocation) : base(jahLocation)
    {
        SetRange(0);
        SetStrength(0);
        SetPerception(0);
        SetTeam(new(new(){this}));
    }

/*
    Getters / Setters
*/
    public int GetStrength()
    {
        return _jahStrength;
    }
    public void SetStrength(int jahStrength)
    {
        _jahStrength = jahStrength;
    }

    public int GetRange()
    {
        return _jahRange;
    }
    public void SetRange(int jahRange)
    {
        _jahRange = jahRange;
    }

    public void SetTeam(Team jahTeam)
    {
        _jahTeam = jahTeam;
    }
    public Team GetTeam()
    {
        return _jahTeam;
    }

    public void AlignWith(Character jahCharacter)
    {
        Team jahOtherTeam = jahCharacter.GetTeam();
        GetTeam().RemoveTeammate(this);
        jahOtherTeam.AddTeammate(this);
        SetTeam(jahOtherTeam);
    }

/*
    Functions
*/
    virtual public string GetStringStats()
    {
        string jahStats = "";
        jahStats += $"\nAvatar: {GetAvatar()}";
        jahStats += $"\tHealth: {GetHealth()}";
        jahStats += $"\tDefense: {GetDefense()}";
        jahStats += $"\tStrength: {GetStrength()}";
        jahStats += $"\nPerception: {GetPerception()}";
        jahStats += $"\tSpeed: {GetSpeed()}";
        jahStats += $"\tEvasion: {GetEvasion()}";
        jahStats += $"\tPriority: {GetPriority()}";
        return jahStats;
    }
    virtual public void Attack(Battlefield jahBattlefield, Character jahEnemy)
    {
        jahEnemy.AssessAttacked(jahBattlefield, this);
    }
    virtual public void Dodge(Character jahAttacker, int jahBuff=0, int jahChance=5)
    {
        if(GetEvasion()+jahBuff < jahAttacker.GetSpeed() || Support.GetRandomInt(jahChance) == 1)
        {
            SetHealth(GetHealth()-jahAttacker.GetStrength());
        }
    }
    public void Defend(Character jahAttacker)
    {
        SetHealth(GetHealth()-((double)jahAttacker.GetStrength() / (double)GetDefense()));
    }
    public override void Assess(Battlefield jahBattlefield)
    {
        AssessPriority(jahBattlefield);
        CheckPriorityActivate(jahBattlefield);

        AssessPriority(jahBattlefield);
        CheckPriorityWander(jahBattlefield);
        
        AssessPriority(jahBattlefield);
        CheckPriorityTarget(jahBattlefield);
        
        AssessPriority(jahBattlefield);
        CheckPriorityFlee(jahBattlefield);
    }
    
    public void AssessPriority(Battlefield jahBattlefield)
    {
        if(GetPriority().Contains("target: "))
        {
            string jahStr = GetPriority().Replace("target: ", "");
            List<int> jahTarget = Support.StrToList(jahStr);
            List<Character> jahEnemies = new();

            List<List<int>> jahCoords = Support.GetFullSquareCoordinates(GetRange(), GetLocation());

            jahCoords = Support.GetOverlap(
                jahCoords,
                Support.ExtractElementsToList<SimulationObject, List<int>>(
                    jahBattlefield.GetSimulationObjectList(), 
                    var => var.GetLocation()
                )
            );

            foreach(List<int> jahCoord in jahCoords)
            {
                SimulationObject jahSimulationObject = jahBattlefield.Inspect(jahCoord);

                if(jahSimulationObject is Character && jahSimulationObject != this)
                {
                    Character jahCharacter = (Character)jahSimulationObject;

                    if(!GetTeam().AreTeammates(jahCharacter, this))
                    {
                        jahEnemies.Add(jahCharacter);
                    }
                }
            }

            if(Support.ListContainsList(jahTarget, Support.GetFullSquareCoordinates(GetRange(), GetLocation()))
                || jahEnemies.Count > 0
                || jahTarget == GetLocation()
            )
            {
                SetPriority("wander");
            }
        }
    }
    public void CheckPriorityWander(Battlefield jahBattlefield)
    {
        if (GetPriority() == "wander")
        {
            SearchForEnemy(jahBattlefield);
        }
    }
    public void CheckPriorityFlee(Battlefield jahBattlefield)
    {
        if (GetPriority() == "flee")
        {
            Flee(jahBattlefield);
        }
    }
    public void AssessAttack(Battlefield jahBattlefield, List<Character> jahEnemies)
    {
        Character jahAttack = null;

        foreach (Character jahEnemy in jahEnemies)
        {
            if (Support.ListContainsList(jahEnemy.GetLocation(), Support.GetFullSquareCoordinates(GetRange(), GetLocation())))
            {
                jahAttack = jahEnemy;
                break;
            }
        }
        if (jahAttack != null)
        {
            Attack(jahBattlefield, jahAttack);
        }
    }
    public override void AssessAttacked(Battlefield jahBattlefield, Character jahAttacker)
    {
        ActivateAbility(jahBattlefield);

        if (
            Support.GetOverlap(
                new(){GetLocation()}, 
                Support.GetFullSquareCoordinates(jahAttacker.GetRange(), jahAttacker.GetLocation())
            ).Count > 0)
        {
            if(GetHealth() < jahAttacker.GetStrength())
            {
                Dodge(jahAttacker);
                SetPriority("flee");
            } else
            {
                Defend(jahAttacker);
            }
        }
    }
    public void Flee(Battlefield jahBattlefield)
    {
        SearchForAlly(jahBattlefield);
        CheckPriorityTarget(jahBattlefield);
    }
    public void SearchForAlly(Battlefield jahBattlefield)
    {
        List<List<int>> jahScan = Support.GetFullSquareCoordinates(GetPerception(), GetLocation());
        List<Character> jahAllies = new();

        foreach(SimulationObject jahCheck in jahBattlefield.GetSimulationObjectList())
        {
            if (jahCheck is Character)
            {
                Character jahCharacter = (Character)jahCheck;

                if(Support.ListContainsList(jahCheck.GetLocation(), jahScan) && jahCheck != this)
                {
                    if (GetTeam().AreTeammates(this, jahCharacter))
                    {
                        jahAllies.Add(jahCharacter);
                    }
                }
            }
        }
        if(jahAllies.Count() == 0)
        {
            AssessMovement(jahBattlefield);
        } else
        {
            Character closestAlly = Support.FindMinimalValueContainer<Character>(
                jahAllies, 
                var => Support.GetDistance(
                    GetLocation(), 
                    var.GetLocation()
                )
            );
            string jahPriority = $"target: {closestAlly.GetPositionX()} {closestAlly.GetPositionY()}";
            SetPriority(jahPriority);
        }
    }
    public void SearchForEnemy(Battlefield jahBattlefield)
    {
        List<List<int>> jahScan = Support.GetFullSquareCoordinates(GetPerception(), GetLocation());

        jahScan = Support.GetOverlap(
            jahScan, 
            Support.ExtractElementsToList<SimulationObject, List<int>>(
                jahBattlefield.GetSimulationObjectList(),
                var => var.GetLocation()
            )
        );
        List<Character> jahEnemies = new();

        // Support.Display("1", true);

        foreach(List<int> jahCheck in jahScan)
        {
            SimulationObject jahObject = (SimulationObject)jahBattlefield.Inspect(jahCheck);
            
            if(jahBattlefield.Inspect(jahCheck) != this)
            {
                if (jahObject is Character)
                {
                    Character jahCharacter = (Character)jahObject;

                    if (!GetTeam().AreTeammates(this, jahCharacter))
                    {
                        jahEnemies.Add(jahCharacter);
                    }
                }
            }
        }

        // Support.Display("2", true);

        if(jahEnemies.Count() == 0)
        {
            AssessMovement(jahBattlefield);
        } else
        {
            Character jahClosestEnemy = Support.FindMinimalValueContainer<Character>(
                jahEnemies, 
                var => Support.GetDistance(
                    GetLocation(), 
                    var.GetLocation()
                )
            );
            AssessAttack(jahBattlefield, new(){jahClosestEnemy});
            string jahPriority = $"target: {jahClosestEnemy.GetPositionX()} {jahClosestEnemy.GetPositionY()}";
            
            SetPriority(jahPriority);
        }
    }
}