using System.Globalization;

public class Square : Shape
{
    private double _jahSide;

    public override double GetArea()
    {
        return _jahSide * _jahSide;
    }

    public void SetSide(double jahSide)
    {
        _jahSide = jahSide;
    }
}