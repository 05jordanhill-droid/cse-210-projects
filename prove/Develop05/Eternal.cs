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

class Eternal : Goal
{
    public Eternal(string jahName, string jahDescription, int jahValue, string jahChecked=" "):base(jahName, jahDescription, jahValue, jahChecked){}
    public Eternal(List<Object> jahBundledInfo):base(jahBundledInfo){}

    public override int Check()
    {
        return GetValue();
    }
    public override string GetTypeName()
    {
        return "eternal";
    }
    // override Check(score): Abstract int	
}