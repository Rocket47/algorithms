using SoftwareDesign.sd1_4;
using Xunit;
using Assert = Xunit.Assert;

namespace Task3AppTests.sd1_4;

public class AverageCalculatorTests
{
    [Fact]
    public void WhenNumbersLengthZero_ReturnZero()
    {
        var result = AverageCalculator.CalculateAverage([]);
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void WhenNumbersSumEven_ReturnSuccess()
    {
        var result = AverageCalculator.CalculateAverage([5, 10, 15, 30]);
        Assert.Equal(15, result);
    }
    
    [Fact]
    public void WhenNumbersSumOdd_ReturnSuccess()
    {
        var result = AverageCalculator.CalculateAverage([5, 10, 15, 20]);
        Assert.Equal(12.5, result);
    }
    
    [Fact]
    public void WhenNumbersSumNegative_ReturnSuccess()
    {
        var result = AverageCalculator.CalculateAverage([5, 15, -50]);
        Assert.Equal(-10, result);
    }
}