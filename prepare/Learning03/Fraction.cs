using System.Globalization;

public class Fraction
{
    private int _jahTop;
    private int _jahBottom;

    public Fraction()
    {
        _jahTop = 1;
        _jahBottom = 1;
    }
    public Fraction(int jahWholeNumber)
    {
        _jahTop = jahWholeNumber;
        _jahBottom = 1;
    }
    public Fraction(int jahTop, int jahBottom)
    {
        SetTop(jahTop);
        SetBottom(jahBottom);
    }

    public int GetTop()
    {
        return _jahTop;
    }
    public void SetTop(int jahTop)
    {
        _jahTop = jahTop;
    }
    public int GetBottom()
    {
        return _jahBottom;
    }
    public void SetBottom(int jahBottom)
    {
        if (jahBottom != 0){
            _jahBottom = jahBottom;
        }
        else
        {
            _jahBottom = 1;
        }
    }

    public string GetFractionString()
    {
        return $"{_jahTop}/{_jahBottom}";
    }
    public double GetDecimalValue()
    {
        return (double)_jahTop /_jahBottom;
    }
}