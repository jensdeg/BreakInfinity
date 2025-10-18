using AwesomeAssertions;

namespace BreakInfinity.Test;

public class ConstructorShould
{
    public static TheoryData<double> DoubleValues =>
    [
        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
        1e0, 1e1, 1e2, 1e3, 1e4, 1e5, 1e6,
        2.43e23, 6.74e69, 5.83e85, 9.20e100, 1.29e48,
        7.48e48, 7.34e290, 73.6e305, 84.3e185, 89e209,
        double.MaxValue, double.Tau, double.Pi, double.E
    ];

    public static TheoryData<double, uint> MantissaExponent => new()
    {
        { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 },
        { 6, 0 }, { 7, 0 }, { 8, 0 }, { 10, 0 }, { 11, 0 }, { 12, 0},
        { 0, 482 }, { 1, 2039485761 }, { 2, 935 }, { 3, 128392039 },
        { 4, 58 },{ 5, 18439204 }, { 6, 234 }, { 7, 1732049823 },
        { 8, 914 }, { 9, 483920 },{ 10, 2039485760 }, { 11, 72 },
        { 12, 1023948576 }, { 3, 12 }, { 5, 2384029 },{ 4, 958 },
        { 6, 1939485762 }, { 7, 823 }, { 8, 102 }, { 9, 1948203920 },
        { 10, 345 }, { 11, 1002 }, { 12, 23984 }, { 13, 1823948573 }, {2,4},
        { 9, 87 },{ 5, 999 }, { 8, 2039485762 }, { 11, 45 }, { 12, 1839201 },
        { 14, 239 },{1023, 3012 }, {45324, 65465 },{234, 34 },{3245, 3242 },
        {double.MaxValue, 10 }, {1, uint.MaxValue}, {double.MaxValue, uint.MaxValue}
    };

    [Theory]
    [MemberData(nameof(DoubleValues))]
    public void CreateBigDoubleFromDouble(double value)
    {
        // Arrange
        var negativeValue = -value;
        var precision = value / 1e10;

        // Act
        var bigdouble = new BigDouble(value);
        var negativeBigDouble = new BigDouble(negativeValue);

        // Assert
        bigdouble.CalculatedValue.Should().BeApproximately(value, precision);
        bigdouble.Mantissa.Should().BeInRange(0, 10);

        negativeBigDouble.CalculatedValue.Should().BeApproximately(negativeValue, precision);
        negativeBigDouble.Mantissa.Should().BeInRange(-10, 0);

        bigdouble.Exponent.Should().Be(negativeBigDouble.Exponent);
    }

    [Theory]
    [MemberData(nameof(MantissaExponent))]
    public void CreateBigDoubleFromMantissaAndExponent(double mantissa, uint exponent)
    {
        // Act
        var bigdouble = new BigDouble(mantissa, exponent);
        var negativeBigDouble = new BigDouble(-mantissa, exponent);

        // Assert
        bigdouble.Mantissa.Should().BeInRange(0, 10);
        negativeBigDouble.Mantissa.Should().BeInRange(-10, 0);
        bigdouble.Exponent.Should().Be(negativeBigDouble.Exponent);
    }
}
