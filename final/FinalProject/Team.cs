using System.Globalization;

class Team
{
   private List<Character> _jahCharacterList;
   private double _jahHealth;
   private int _jahStrength;

    public Team()
    {
        _jahHealth = 0;
        _jahStrength = 0;
    }
    public Team(List<Character> jahCharacterList)
    {
        SetStats(jahCharacterList);
        SetCharacterList(jahCharacterList);
    }

/*
    Getters / Setters
*/
    public double GetHealth()
    {
        return _jahHealth;
    }
    public void SetHealth(double jahHealth)
    {
        _jahHealth = jahHealth;
    }
    public void ChangeHealth(double jahHealth)
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

    public void SetStats(List<Character> jahCharacterList)
    {
        ChangeHealth(0);
        ChangeStrength(0);

        foreach (Character jahCharacter in jahCharacterList)
        {
            ChangeHealth(jahCharacter.GetHealth());
            ChangeStrength(jahCharacter.GetStrength());
        }
    }
    public void SetStats()
    {
        ChangeHealth(0);
        ChangeStrength(0);

        foreach (Character jahCharacter in GetCharacterList())
        {
            ChangeHealth(jahCharacter.GetHealth());
            ChangeStrength(jahCharacter.GetStrength());
        }
    }

    public List<Character> GetCharacterList()
    {
        return _jahCharacterList;
    }
    public void SetCharacterList(List<Character> jahCharacterList)
    {
        _jahCharacterList = jahCharacterList;
    }

    public void AddTeammate(Character jahCharacter)
    {
        if (!GetCharacterList().Contains(jahCharacter))
        {
            GetCharacterList().Add(jahCharacter);
        }
    }
    public void RemoveTeammate(Character jahCharacter)
    {
        if (GetCharacterList().Contains(jahCharacter))
        {
            GetCharacterList().Remove(jahCharacter);
        }
    }
    public Boolean AreTeammates(Character jahCharacter, Character jahOtherCharacter)
    {
        if (GetCharacterList().Contains(jahCharacter) && GetCharacterList().Contains(jahOtherCharacter))
        {
            return true;
        } else
        {
            return false;
        }
    }
    public Boolean AreTeammates(Character jahCharacter)
    {
        if (GetCharacterList().Contains(jahCharacter))
        {
            return true;
        } else
        {
            return false;
        }
    }
}