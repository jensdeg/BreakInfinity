using System.Numerics;

namespace BreakInfinity;

public readonly partial struct BigDouble
    : IAdditionOperators<BigDouble, BigDouble, BigDouble>, IAdditiveIdentity<BigDouble, BigDouble>,
      IMultiplyOperators<BigDouble, BigDouble, BigDouble>, IMultiplicativeIdentity<BigDouble, BigDouble>,
      IDivisionOperators<BigDouble, BigDouble, BigDouble>,
      ISubtractionOperators<BigDouble, BigDouble, BigDouble>,
      IModulusOperators<BigDouble, BigDouble, BigDouble>,
      IDecrementOperators<BigDouble>,
      IIncrementOperators<BigDouble>,
      IMinMaxValue<BigDouble>,
      IUnaryNegationOperators<BigDouble, BigDouble>
{
    public static BigDouble AdditiveIdentity => new();

    public static BigDouble MultiplicativeIdentity => new(1);

    public static BigDouble MaxValue => new(9.99, uint.MaxValue);

    public static BigDouble MinValue => new(0);

    public static BigDouble operator +(BigDouble left, BigDouble right)
    {
        if (!left.IsBroken && !right.IsBroken)
        {
            double value = left.CalculatedValue + right.CalculatedValue;
            if (!double.IsInfinity(value)) return new(value);
        }
        if (left.Exponent == right.Exponent)
        {
            var mantissa = left.Mantissa + right.Mantissa;
            return new(mantissa, left.Exponent);
        }
        throw new NotImplementedException();
    }

    public static BigDouble operator -(BigDouble value)
        => new(-value.Mantissa, value.Exponent);

    public static BigDouble operator -(BigDouble left, BigDouble right)
    {
        if (!left.IsBroken && !right.IsBroken)
        {
            double value = left.CalculatedValue - right.CalculatedValue;
            if (!double.IsInfinity(value)) return new(value);
        }
        if (left.Exponent == right.Exponent)
        {
            var mantissa = left.Mantissa - right.Mantissa;
            return new(mantissa, left.Exponent);
        }

        throw new NotImplementedException();
    }

    public static BigDouble operator ++(BigDouble value)
    {
        if (!value.IsBroken)
            return new BigDouble(value.CalculatedValue + 1);

        throw new NotImplementedException();
    }

    public static BigDouble operator --(BigDouble value)
    {
        if (!value.IsBroken)
            return new BigDouble(value.CalculatedValue - 1);
        throw new NotImplementedException();
    }

    public static BigDouble operator *(BigDouble left, BigDouble right)
    {
        if (!left.IsBroken && !right.IsBroken)
        {
            double value = left.CalculatedValue * right.CalculatedValue;
            if (!double.IsInfinity(value)) return new(value);
        }

        var exponent = left.Exponent + right.Exponent;
        var mantissa = left.Mantissa * right.Mantissa;
        return new(mantissa, exponent);
    }

    public static BigDouble operator /(BigDouble left, BigDouble right)
    {
        if (!left.IsBroken && !right.IsBroken)
        {
            double value = left.CalculatedValue / right.CalculatedValue;
            if (!double.IsInfinity(value)) return new(value);
        }

        var exponent = left.Exponent - right.Exponent;
        var mantissa = left.Mantissa / right.Mantissa;
        return new(mantissa, exponent);
    }

    public static BigDouble operator %(BigDouble left, BigDouble right)
    {
        throw new NotImplementedException();
    }
}
