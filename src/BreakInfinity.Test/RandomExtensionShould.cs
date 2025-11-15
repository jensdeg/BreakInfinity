using AwesomeAssertions;

namespace BreakInfinity.Test;

public class RandomExtensionShould
{
    private const int TestIterations = 1000;

    public static TheoryData<BigDouble, BigDouble> BigDoubleValues => new()
    {
        { new(0), new(1) }, { new(1e6), new(1e12) }, { new(0.5), new(42.0) },
        { new(1.2345e10), new(9.9e20) }, { new(3.14), new(2.71828e5) },
        { new(2.5e100), new(3.0e150) }, { new(9.1e3), new(1.0e4) },
        { new(7.77e50), new(2.22e120) }, { new(6.0), new(1e308) },
        { new(1e200), new(8e250) }, { new(123.456), new(9.99e9) },
        { new(4.2e75), new(9.1e140) }, { new(5e2), new(5e30) },
        { new(8.88e100), new(9.99e200) }, { new(1e8), new(3.3e50) },

        { new(1.0, 309), new(1.0, 310) }, { new(5.5, 320), new(8.1, 320) }, 
        { new(9.99, 400), new(1.1, 401) }, { new(2.2, 350), new(9.8, 350) },
        { new(7.0, 500), new(7.1, 500) }, { new(1.2345, 600), new(9.99, 600) },
        { new(3.0, 700), new(3.0, 701) }, { new(8.8, 450), new(9.9, 450) },
        { new(4.0, 1000), new(9.0, 1000) }, { new(1.0, 1200), new(1.5, 1200) },
        { new(6.2, 800), new(7.3, 800) }, { new(2.5, 900), new(3.6, 900) },
        { new(9.1, 1500), new(9.2, 1500) }, { new(3.14, 2000), new(6.28, 2000) },
        { new(1.0, 2500), new(5.0, 2500) }, {  new(1.0, 2500), new(5.0, 2500) }
    };

    [Theory]
    [MemberData(nameof(BigDoubleValues))]
    public void GenerateBigDoubleWithinRange(BigDouble min, BigDouble max)
    {
        // Arrange
        var random = new Random();
        var negativeMin = -min;
        var negativeMax = -max;

        var test = random.NextBigDouble(1e20, 6e25);

        for (int i = 0; i < TestIterations; i++)
        {
            // Act
            var bigDouble = random.NextBigDouble(min, max);
            var bigDoubleNegative = random.NextBigDouble(negativeMax, negativeMin);
            var BigDoubleMixed = random.NextBigDouble(negativeMin, max);

            // Assert
            bigDouble.Should().BeInRange(min, max);
            bigDoubleNegative.Should().BeInRange(negativeMax, negativeMin);
            BigDoubleMixed.Should().BeInRange(negativeMin, max);
        }
    }
}
