namespace SoftwareDesign.sd1_5;

public class GradeCalculator
{
    private const int MinGrade = 1;
    private const int MaxGrade = 5;
    
    public static double CalculateAverage(List<int> grades)
    {
        ArgumentNullException.ThrowIfNull(grades);

        if (grades.Count == 0)
        {
            throw new ArgumentException("List is empty");
        }

        var averageRating = 0.0;

        foreach (var grade in grades)
        {
            if (grade is < MinGrade or > MaxGrade)
            {
                throw new ArgumentOutOfRangeException(nameof(grade));
            }
            
            averageRating += grade;
        }
        
        return averageRating / grades.Count;
    }
}