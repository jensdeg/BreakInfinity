namespace BreakInfinity;

public readonly partial struct BigDouble
    : IEquatable<BigDouble>,
      IComparable<BigDouble>
{
    public readonly double Mantissa { get; }

    public readonly uint Exponent { get; }

    public readonly double CalculatedValue
        => Mantissa * Math.Pow(10, Exponent);

    public readonly bool IsBroken
        => double.IsInfinity(CalculatedValue);

    private readonly double MantissaRounded
        => Math.Round(Mantissa, 2);

    public override string ToString()
        => $"{MantissaRounded}e{Exponent}";

    public BigDouble()
    {
        Mantissa = 0;
        Exponent = 0;
    }

    public BigDouble(double value)
    {
        if (double.IsInfinity(value)) value = double.MaxValue;
        if (value == 0)
        {
            Mantissa = 0;
            Exponent = 0;
            return;
        }
        if(value < 0)
        {
            Exponent = (uint)Math.Floor(Math.Log10(-value));
            Mantissa = -(-value / Math.Pow(10, Exponent));
            return;
        }

        Exponent = (uint)Math.Floor(Math.Log10(value));
        Mantissa = (value / Math.Pow(10, Exponent));
    }

    public BigDouble(double mantissa, uint exponent)
    {
        if (mantissa > 10)
        {
            var leftover = new BigDouble(mantissa);
            Mantissa = leftover.Mantissa;
            Exponent = leftover.Exponent + exponent;
            return;
        }
        if (mantissa < -10)
        {
            var leftover = new BigDouble(mantissa);
            Mantissa = leftover.Mantissa;
            Exponent = leftover.Exponent + exponent;
            return;
        }

        Mantissa = mantissa;
        Exponent = exponent;
    }

    public bool Equals(BigDouble other)
        => Mantissa == other.Mantissa &&
           Exponent == other.Exponent;

    public override bool Equals(object? obj)
        => obj is BigDouble other &&
           Equals(other);

    public override int GetHashCode()
        => HashCode.Combine(Mantissa, Exponent);

    public int CompareTo(BigDouble other)
    {
        if (Exponent != other.Exponent) return Exponent.CompareTo(other.Exponent);
        return Mantissa.CompareTo(other.Mantissa);
    }

    public static bool operator ==(BigDouble left, BigDouble right)
        => left.Equals(right);

    public static bool operator !=(BigDouble left, BigDouble right)
        => !(left == right);
}
