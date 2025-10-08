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
      IMinMaxValue<BigDouble>
{
    public static BigDouble AdditiveIdentity => new();

    public static BigDouble MultiplicativeIdentity => new(1);

    public static BigDouble MaxValue => new(9.99, 9999);

    public static BigDouble MinValue => new(0);

    public static BigDouble operator +(BigDouble left, BigDouble right)
    {
        throw new NotImplementedException();
    }

    public static BigDouble operator -(BigDouble left, BigDouble right)
    {
        throw new NotImplementedException();
    }

    public static BigDouble operator ++(BigDouble value)
    {
        throw new NotImplementedException();
    }

    public static BigDouble operator --(BigDouble value)
    {
        throw new NotImplementedException();
    }

    public static BigDouble operator *(BigDouble left, BigDouble right)
    {
        throw new NotImplementedException();
    }

    public static BigDouble operator /(BigDouble left, BigDouble right)
    {
        throw new NotImplementedException();
    }

    public static BigDouble operator %(BigDouble left, BigDouble right)
    {
        throw new NotImplementedException();
    }
}
