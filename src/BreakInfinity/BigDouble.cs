namespace BreakInfinity;

public sealed class BigDouble
{
    public double Mantissa { get; set; }

    public int Exponent { get; set; }

    public BigDouble()
    {
        Mantissa = 0;
        Exponent = 0;
    }

    public BigDouble(double value)
    {
        if (value < 0) throw new NotImplementedException("negative numbers not supported yet");
        if (value == 0)
        {
            Mantissa = 0;
            Exponent = 0;
        }

        Exponent = (int)Math.Floor(Math.Log10(value));
        Mantissa = Math.Round((value / Math.Pow(10, Exponent)), 2);
    }

    public override string ToString()
    {
        return $"{Mantissa}e{Exponent}";
    }
}
