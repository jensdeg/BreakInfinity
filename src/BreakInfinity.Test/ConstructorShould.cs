
using AwesomeAssertions;

namespace BreakInfinity.Test;

public class ConstructorShould
{
    public static TheoryData<double> DoubleValues =>
        [
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            1e0, 1e1, 1e2, 1e3, 1e4, 1e5, 1e6,
            2.43e23, 6.74e69, 5.83e85, 9.20e100,
            double.MaxValue, double.Tau, double.Pi
        ];

    [Theory]
    [MemberData(nameof(DoubleValues))]
    public void CreateBigDoubleFromDouble(double value)
    {
        // Act
        var number = new BigDouble(value);
        
        // Assert
        number.CalculatedValue.Should().BeApproximately(value, value / 1e10);
    }
}
