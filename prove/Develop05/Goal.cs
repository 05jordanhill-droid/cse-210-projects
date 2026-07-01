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

public abstract class Goal
{
    private int _jahValue;
    private string _jahName;
    private string _jahDescription;    
    private string _jahChecked;

    protected Goal(string jahName, string jahDescription, int jahValue, string jahChecked=" ")
    {
        _jahValue = jahValue;
        _jahDescription = jahDescription;
        _jahName = jahName;
        _jahChecked = jahChecked;
    }
    protected Goal(List<Object> jahBundledInfo)
    {
        SetBundledInfo(jahBundledInfo);
    }
    public string GetName()
    {
        return _jahName;
    }
    public string GetDescription()
    {
        return _jahDescription;
    }
    public string GetStatus()
    {
        return _jahChecked;
    }
    protected void SetName(string jahName)
    {
        _jahName = jahName;
    }
    protected void SetDescription(string jahDescription)
    {
        _jahDescription = jahDescription;
    }
    protected void SetValue(int jahValue)
    {
        _jahValue = jahValue;
    }
    protected void SetStatus(string jahStatus)
    {
        _jahChecked = jahStatus;
    }
    public int GetValue()
    {
        return _jahValue;
    }
    public virtual string GetInfo()
    {
        return $"[{GetStatus()}] {GetName()} ({GetDescription()})";
    }
    public virtual int Check()
    {
        _jahChecked = "X";

        return GetValue();
    }

    public virtual List<Object> GetBundledInfo()
    {
        List<Object> jahList = new List<Object>();
        jahList.Add(GetName());
        jahList.Add(GetDescription());
        jahList.Add(GetValue());
        jahList.Add(GetStatus()); 

        return jahList;
    }

    public abstract string GetTypeName();

    protected virtual void SetBundledInfo(List<Object> jahBundledInfo)
    {
        SetName((string)jahBundledInfo[0]);
        SetDescription((string)jahBundledInfo[1]);
        SetValue((int)jahBundledInfo[2]);
        SetStatus((string)jahBundledInfo[3]);
    }

// 		                GetDescription(): string			                                                                                                                                                                                            override Check(score): Abstract int
// 		                GetStatus(): string			
// 		                GetInfo(): Abstract string			
// 		                Check(score): Virtual int	

}