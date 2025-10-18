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
        negativeBigDouble.CalculatedValue.Should().BeApproximately(negativeValue, precision);
    }
}
