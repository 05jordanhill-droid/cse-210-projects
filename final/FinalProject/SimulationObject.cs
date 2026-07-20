using System.Globalization;
class SimulationObject
{
    private string _jahPriority;
    private double _jahHealth;
    private int _jahDefense;
    private int _jahSpeed;
    private double _jahSpeedBuildUp;
    private int _jahEvasion;
    private int _jahPerception;
    private List<int> _jahLocation;
    private List<List<int>> _jahFieldOfView;
    private int _jahFieldOfViewRadius;
    private string _jahAvatar;
    private Boolean _jahCanStepOn;

/*
    Getters / Setters
*/
    public SimulationObject(int jahHealth, int jahDefense, int jahSpeed, int jahEvasion, int jahPerception, string jahPriority, int jahPositionX, int jahPositionY, int jahFieldOfViewRadius=1)
    {
        SetHealth(jahHealth);
        SetDefense(jahDefense);
        SetSpeed(jahSpeed);
        SetEvasion(jahEvasion);
        SetPerception(jahPerception);
        SetPriority(jahPriority);
        SetLocation(jahPositionX, jahPositionY);

        SetStepOn(false);

        ResetFieldOfView(jahFieldOfViewRadius);
        SetFieldOfViewRadius(jahFieldOfViewRadius);
    }
    public SimulationObject(int jahHealth, int jahDefense, int jahSpeed, int jahEvasion, int jahPerception, string jahPriority, List<int> jahLocation, int jahFieldOfViewRadius=1)
    {
        SetHealth(jahHealth);
        SetDefense(jahDefense);
        SetSpeed(jahSpeed);
        SetEvasion(jahEvasion);
        SetPerception(jahPerception);
        SetPriority(jahPriority);
        SetLocation(jahLocation);

        SetStepOn(false);

        ResetFieldOfView(jahFieldOfViewRadius);
        SetFieldOfViewRadius(jahFieldOfViewRadius);
    }
    public SimulationObject(int jahPositionX, int jahPositionY, string jahPriority="empty")
    {
        SetHealth(1);
        SetDefense(0);
        SetSpeed(0);
        SetEvasion(0);

        SetPerception(0);
        SetPriority(jahPriority);
        SetLocation(jahPositionX, jahPositionY);

        SetStepOn(true);
        SetAvatar(" ");

        ResetFieldOfView(1);
        SetFieldOfViewRadius(1);
    }
    
    public SimulationObject(List<int> jahLocation, string jahPriority="empty")
    {
        SetHealth(0);
        SetDefense(0);
        SetSpeed(0);
        SetEvasion(0);

        SetPerception(0);
        SetPriority(jahPriority);
        SetLocation(jahLocation);

        SetStepOn(false);
        SetAvatar(" ");

        ResetFieldOfView(0);
        SetFieldOfViewRadius(0);
    }
    
    public double GetHealth()
    {
        return _jahHealth;
    }
    public void SetHealth(double jahHealth)
    {
        _jahHealth = jahHealth;
    }

    public int GetDefense()
    {
        return _jahDefense;
    }
    public void SetDefense(int jahDefense)
    {
        _jahDefense = jahDefense;
    }

    public int GetSpeed()
    {
        return _jahSpeed;
    }
    public void SetSpeed(int jahSpeed)
    {
        _jahSpeed = jahSpeed;
    }

    public double GetSpeedBuildUp()
    {
        return _jahSpeedBuildUp;
    }
    public void SetSpeedBuildUp(double jahSpeedBuildUp)
    {
        _jahSpeedBuildUp = jahSpeedBuildUp;
    }
    public void ChangeSpeedBuildUp(double jahChange)
    {
        if(GetSpeedBuildUp() >= 10)
        {
            double jahSpeedBuildUp = GetSpeedBuildUp() % 10;
            SetSpeedBuildUp(jahSpeedBuildUp);
        }
        SetSpeedBuildUp(GetSpeedBuildUp() + jahChange);
    }

    public int GetEvasion()
    {
        return _jahEvasion;
    }
    public void SetEvasion(int jahEvasion)
    {
        _jahEvasion = jahEvasion;
    }

    public int GetPerception()
    {
        return _jahPerception;
    }
    public void SetPerception(int jahPerception)
    {
        _jahPerception = jahPerception;
    }

    public string GetPriority()
    {
        return _jahPriority;
    }
    public void SetPriority(string jahPriority)
    {
        _jahPriority = jahPriority;
    }

    public List<int> GetLocation()
    {
        return _jahLocation;
    }
    public int GetPositionX()
    {
        return _jahLocation[0];
    }
    public int GetPositionY()
    {
        return _jahLocation[1];
    }
    public void SetLocation(List<int> jahLocation)
    {
        _jahLocation = jahLocation;
    }
    public void SetLocation(int jahPositionX, int jahPositionY)
    {
        try
        {
            _jahLocation[0] = jahPositionX;
            _jahLocation[1] = jahPositionY;
        } catch
        {
            _jahLocation = new();
            _jahLocation.Add(jahPositionX);
            _jahLocation.Add(jahPositionY);
        }
    }
    public void SetPositionX(int jahPositionX)
    {
        try
        {
            _jahLocation[0] = jahPositionX;
        } catch
        {
            _jahLocation.Add(jahPositionX);
        }
    }
    public void SetPositionY(int jahPositionY)
    {
        try
        {
            _jahLocation[1] = jahPositionY;
        } catch
        {
            _jahLocation.Add(jahPositionY);
        }
    }

    public int GetFieldOfViewRadius()
    {
        return _jahFieldOfViewRadius;
    }
    public void SetFieldOfViewRadius(int jahFieldOfViewRadius)
    {
        _jahFieldOfViewRadius = jahFieldOfViewRadius;
    }
    public List<List<int>> GetFieldOfView()
    {
        return _jahFieldOfView;
    }
    public void ResetFieldOfView(int jahFieldOfViewRadius)
    {
        SetFieldOfView(new());

        for(int i = 0; i < jahFieldOfViewRadius+1; i++)
        {
            AddFieldOfView(i);
        }
    }
    public void SetFieldOfView(List<List<int>> jahFieldOfView)
    {
        _jahFieldOfView = jahFieldOfView;
    }
    public void AddFieldOfView(int jahRadius=1)
    {
        List<List<int>> jahAdditionalRange = Support.GetSquareCoordinates(jahRadius, GetLocation());

        SetFieldOfView(Support.IntegrateLists<List<int>>(GetFieldOfView(), jahAdditionalRange));
    }

    public string GetAvatar()
    {
        return _jahAvatar;
    }
    public void SetAvatar(string jahAvatar)
    {
        _jahAvatar = jahAvatar;
    }
    public void SetStepOn(Boolean jahStepOn)
    {
        _jahCanStepOn = jahStepOn;
    }
    public Boolean CanStepOn()
    {
        return _jahCanStepOn;
    }
/*
    Functions
*/
    virtual public void TakeTurn(Battlefield jahBattlefield)
    {
        int jahTurns = TurnEquation();

        for (int i = 0; i < jahTurns; i++)
        {
            Assess(jahBattlefield);
        }
    }
    protected int TurnEquation()
    {
        ChangeSpeedBuildUp(GetSpeed());

        return (int)(GetSpeedBuildUp() / 10);
    }
    virtual public void Assess(Battlefield jahBattlefield)
    {
        CheckPriorityActivate(jahBattlefield);
        CheckPriorityTarget(jahBattlefield);
    }
    public void CheckPriorityActivate(Battlefield jahBattlefield)
    {
        if (GetPriority() == "activate")
        {
            ActivateAbility(jahBattlefield);
        }
    }
    public void CheckPriorityTarget(Battlefield jahBattlefield)
    {
        if (GetPriority().Contains("target: "))
        {
            string jahStr = GetPriority().Replace("target: ", "");

            List<int> jahTarget = Support.StrToList(jahStr);
            List<List<int>> jahPath = Support.GetLineCoordinates(GetLocation(), jahTarget);
            List<List<int>> jahMovementOptions = Support.GetOverlap(GetFieldOfView(), jahPath);

            AssessMovement(jahBattlefield, jahMovementOptions);
        }
    }
    virtual public void AssessMovement(Battlefield jahBattlefield, List<List<int>> jahMovementOptions=null, Boolean secondTry=false)
    {
        jahMovementOptions ??= GetFieldOfView();
        List<List<int>> jahValidMovements = new();

        SimulationObject jahSimulationObject = null;

        if (Support.ListContainsList(GetLocation(), jahMovementOptions) && jahMovementOptions.Count > 1)
        {
            List<int> jahRemove = null;

            foreach (List<int> jahLocation in jahMovementOptions)
            {
                if(Support.IsIdentical<int>(jahLocation, GetLocation()))
                {
                    jahRemove = jahLocation;
                }
            }
            jahMovementOptions.Remove(jahRemove);
        }
        
        foreach (List<int> jahMovementOption in jahMovementOptions)
        {
            jahSimulationObject = jahBattlefield.Inspect(jahMovementOption);

            if (jahSimulationObject != null)
            {
                if (jahSimulationObject.CanStepOn() == true)
                {
                    jahValidMovements.Add(jahMovementOption);
                }
            }
        }
        
        Boolean skip = false;
        if (jahValidMovements.Count() == 0)
        {
            if (!secondTry)
            {            
                AssessMovement(jahBattlefield, null, true);
            }
            skip = true;
        }

        if (!skip)
        {
            List<int> jahMovement = Support.GetRandom<List<int>>(jahValidMovements);

            Move(jahMovement, jahBattlefield);
        }
    }
    virtual public void ActivateAbility(Battlefield jahBattlefield){}
    virtual public void Move(List<int> jahMove, Battlefield jahBattlefield)
    {
        jahBattlefield.AssessActivate(jahMove);

        if(GetHealth() > 0)
        {
            jahBattlefield.SetGridPiece(jahMove[0], jahMove[1], this);
            jahBattlefield.SetGridPiece(new SimulationObject(GetPositionX(), GetPositionY()));
            SetLocation(jahMove);
        }
        ResetFieldOfView(GetFieldOfViewRadius());
    }
    virtual public void AssessAttacked(Battlefield jahBattlefield, Character jahAttacker)
    {
        ActivateAbility(jahBattlefield);
    }
}