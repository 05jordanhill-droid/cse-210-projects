// Class Name	    Program	                Goal	                Simple : Goal	    Eternal : Goal	Checklist : Goal
// class methods	goalList: List<Goal>	_value: int			                                        _bonus: int
// 	                score: int	            _checked: boolean	                                        _length: int
// 		                                    _name: string			                                    _progress: int
// 		                                    _description: string			
				
// class functions		Goal(string name, string description, int value)	Simple(string name, string description, int value):base(name, description, value)	Eternal(string name, string description, int value):base(name, description, value)	    Checklist(string name, string description, int value, int bonus, int length):base(name, description, value)
// 		                GetName(): string		                                                                                                                override Check(score): Abstract int	                                                    override GetInfo(): string
// 		                GetDescription(): string			                                                                                                                                                                                            override Check(score): Abstract int
// 		                GetStatus(): string			
// 		                GetInfo(): Abstract string			
// 		                Check(score): Virtual int	

using System.Globalization;

class Checklist : Goal
{
    private int _jahBonus;
    private int _jahLength;
    private int _jahProgress;
    public Checklist(string jahName, string jahDescription, int jahValue, int jahBonus, int jahLength, string jahChecked=" ", int jahProgress=0):base(jahName, jahDescription, jahValue, jahChecked)
    {
        _jahBonus = jahBonus;
        _jahLength = jahLength;
        _jahProgress = jahProgress;
    }
    public Checklist(List<Object> jahBundledInfo):base(jahBundledInfo){}

    public override string GetInfo()
    {
        return $"[{GetStatus()}] {GetName()} ({GetDescription()}) -- Currently Completed: {_jahProgress}/{_jahLength}";
    }
    public override int Check()
    {
        _jahProgress += 1;

        if((double)_jahProgress % (double)_jahLength == 0)
        {
            SetStatus("X");
            return GetValue()+_jahBonus;
        }
        else
        {
            return GetValue();
        }
    }

    public int GetBonus()
    {
        return _jahBonus;
    }
    public int GetLength()
    {
        return _jahLength;
    }
    public int GetProgress()
    {
        return _jahProgress;
    }

    public override List<Object> GetBundledInfo()
    {
        List<Object> jahList = new List<Object>();
        jahList.Add(GetName());
        jahList.Add(GetDescription());
        jahList.Add(GetValue());
        jahList.Add(GetBonus());
        jahList.Add(GetLength());
        jahList.Add(GetStatus()); 
        jahList.Add(GetProgress());

        return jahList;
    }
    public override string GetTypeName()
    {
        return "checklist";
    }
    // override GetInfo(): string
    // override Check(score): Abstract int

    protected override void SetBundledInfo(List<Object> jahBundledInfo)
    {
        SetName((string)jahBundledInfo[0]);
        SetDescription((string)jahBundledInfo[1]);
        SetValue((int)jahBundledInfo[2]);
        _jahBonus = (int)jahBundledInfo[3];
        _jahLength = (int)jahBundledInfo[4];
        SetStatus((string)jahBundledInfo[5]);
        _jahProgress = (int)jahBundledInfo[6];
    }
}