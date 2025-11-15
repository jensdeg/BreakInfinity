namespace BreakInfinity;

public static class RandomExtension
{
    public static BigDouble NextBigDouble(this Random random, BigDouble minValue, BigDouble maxValue)
    {
        if (minValue > maxValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), "minValue must be less than or equal to maxValue.");
        if (minValue == maxValue) return minValue;

        var range = maxValue - minValue;
        var sample = random.NextDouble();
        var result = minValue + range * sample;
        return result;
    }
}
