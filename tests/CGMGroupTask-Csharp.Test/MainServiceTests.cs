
using CGMGroupTask_Csharp.Services;

namespace CGMGroupTask_Csharp.Test;

public class MainServiceTests
{
    private MainService _mainService;

    public MainServiceTests()
    {
        _mainService = new MainService();
    }

    [Fact]
    public void AddQuestion_Successful()
    {
        // Arrange
        string input = "What is Peters favorite food? \"Pizza\" \"Spaghetti\" \"Ice cream\"";

        // Act
        _mainService.AddQuestion(input);

        // Assert
        var qa = _mainService.questionAnswers.FirstOrDefault(q => q.Question == "What is Peters favorite food?");
        Assert.NotNull(qa);
        Assert.Equal(3, qa.Answers.Count);
        Assert.Contains("Pizza", qa.Answers);
        Assert.Contains("Spaghetti", qa.Answers);
        Assert.Contains("Ice cream", qa.Answers);
    }

    [Fact]
    public void AddQuestion_InvalidFormat()
    {
        // Arrange
        string input = "Invalid question format";

        // Act
        _mainService.AddQuestion(input);

        // Assert
        var qa = _mainService.questionAnswers.FirstOrDefault(q => q.Question == "Invalid question format");
        Assert.Null(qa);
    }

    [Fact]
    public void GetQuestion_ExistingQuestion()
    {
        // Arrange
        string input = "What is Peters favorite food? \"Pizza\" \"Spaghetti\"";
        _mainService.AddQuestion(input);

        // Act
        var qa = _mainService.questionAnswers.FirstOrDefault(q => q.Question == "What is Peters favorite food?");

        // Assert
        Assert.NotNull(qa);
        Assert.Equal(2, qa.Answers.Count);
    }

    [Fact]
    public void GetQuestion_NonExistingQuestion()
    {
        // Arrange
        string question = "What is Peters favorite book?";

        // Act
        var qa = _mainService.questionAnswers.FirstOrDefault(q => q.Question == question);

        // Assert
        Assert.Null(qa);
    }
}