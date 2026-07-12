using System.Globalization;

class Team
{
   private List<Character> _jahCharacterList;
   private int _jahMoral;
   private int _jahHealth;
   private int _jahStrength;

    Team()
    {
        _jahMoral = 0;
        _jahHealth = 0;
        _jahStrength = 0;
    }
    Team(List<Character> jahCharacterList)
    {
        foreach (Character jahCharacter in jahCharacterList)
        {
            ChangeHealth(jahCharacter.GetHealth());
            ChangeStrength(jahCharacter.GetStrength());
            ChangeMoral(jahCharacter.GetHealth() + jahCharacter.GetStrength());
        }
    }

/*
    Getters / Setters
*/
    public int GetMoral()
    {
        return _jahMoral;
    }
    public void SetMoral(int jahMoral)
    {
        _jahMoral = jahMoral;
    }
    public void ChangeMoral(int jahMoral)
    {
        SetMoral(GetMoral() + jahMoral);
    }

    public int GetHealth()
    {
        return _jahHealth;
    }
    public void SetHealth(int jahHealth)
    {
        _jahHealth = jahHealth;
    }
    public void ChangeHealth(int jahHealth)
    {
        SetHealth(GetHealth() + jahHealth);
    }

    public int GetStrength()
    {
        return _jahStrength;
    }
    public void SetStrength(int jahStrength)
    {
        _jahStrength = jahStrength;
    }
    public void ChangeStrength(int jahStrength)
    {
        SetStrength(GetStrength() + jahStrength);
    }

/*
    Functions
*/
    public void AssessTarget()
    {
        
    }
    public void Target(Character jahCharacter)
    {
        
    }
    public void Target(Team jahTeam)
    {
        
    }
    public void CoordinateMove()
    {
        
    }
}