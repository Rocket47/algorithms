using SoftwareDesign.sd1_4;
using SoftwareDesign.sd1_5;
using Xunit;
using Assert = Xunit.Assert;

namespace Task3AppTests.sd1_5;

public class GradeCalculatorTests
{
    [Fact]
    public void WhenGradesLengthZero_ReturnArgumentException()
    {
        var result = GradeCalculator.CalculateAverage;
        
        // Arrange
        var exceptionType = typeof(ArgumentException);
        
        Assert.Throws(exceptionType, () => result.Invoke([])); 
    }
    
    [Fact]
    public void WhenGradesIsNull_ReturnArgumentNullException()
    {
        var result = GradeCalculator.CalculateAverage;
        
        // Arrange
        var exceptionType = typeof(ArgumentNullException);
        
        Assert.Throws(exceptionType, () => result.Invoke(null)); 
    }
    
    [Fact]
    public void WhenGradeNotValid_ReturnArgumentOutOfRangeException()
    {
        var result = GradeCalculator.CalculateAverage;
        
        // Arrange
        var exceptionType = typeof(ArgumentOutOfRangeException);
        
        Assert.Throws(exceptionType, () => result.Invoke([-3, 3, 4, 1, 2])); 
    }
    
    [Fact]
    public void CalculateAverage_ValidInput_ReturnsCorrectValue()
    {
        // Arrange
        var grades = new List<int> { 5, 3, 2, 2, 3, 4 };
        var expected = 3.16;

        // Act
        var actual = GradeCalculator.CalculateAverage(grades);

        // Assert
        Assert.Equal(expected, actual, 0.01);
    }
    
    [Fact]
    public void CalculateAverage_MinMaxAverage_ReturnsCorrectAverage()
    {
        // Arrange
        var expected = 3.0;

        // Act
        var actual = GradeCalculator.CalculateAverage([1, 5]);

        // Assert
        Assert.Equal(expected, actual);
    }
}