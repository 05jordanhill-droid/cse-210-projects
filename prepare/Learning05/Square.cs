using System.Globalization;

public class Square : Shape
{
    private double _jahSide;
    public Square(string jahColor, double jahSide) : base(jahColor)
    {
        _jahSide = jahSide;
    }

    public override double GetArea()
    {
        return _jahSide * _jahSide;
    }

    public void SetSide(double jahSide)
    {
        _jahSide = jahSide;
    }
}