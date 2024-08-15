using CGMGroupTask_Csharp.Models;


namespace CGMGroupTask_Csharp.Services;

public class MainService
{
    public List<QuestionAnswer> questionAnswers;

    public MainService()
    {
        questionAnswers = new List<QuestionAnswer>();
    }
    /// <summary>
    /// Add new question to list of questions
    /// </summary>
    /// <param name="input"></param>
    public void AddQuestion(string input)
    {
        // Ensure the input is valid and split by '?'
        string[] parts = input.Split(new[] { '?' }, 2);
        if (parts.Length != 2)
        {
            Console.WriteLine("Invalid input format. Use the format: <question>? \"<answer1>\" \"<answer2>\" ...");
            return;
        }

        string question = parts[0].Trim() + "?";
        if (question.Length > 255)
        {
            Console.WriteLine("Question exceeds the maximum allowed length of 255 characters.");
            return;
        }

        string[] rawAnswers = parts[1].Split(new[] { '"' }, StringSplitOptions.RemoveEmptyEntries);

        if (rawAnswers.Length == 0)
        {
            Console.WriteLine("Every question must have at least one answer.");
            return;
        }

        QuestionAnswer questionAnswer = new();
        questionAnswer.Question = question;

        if (questionAnswers.Any(x => x.Question == question))
            questionAnswer = questionAnswers.FirstOrDefault(x => x.Question == question)!;

        foreach (string answer in rawAnswers)
        {
            string trimmedAnswer = answer.Trim();
            if (!string.IsNullOrEmpty(trimmedAnswer) && trimmedAnswer.Length <= 255)
            {
                questionAnswer.Answers.Add(trimmedAnswer);
            }
            else if (trimmedAnswer.Length > 255)
            {
                Console.WriteLine("An answer exceeds the maximum allowed length of 255 characters.");
            }
        }

        questionAnswers.Add(questionAnswer);
        Console.WriteLine("Question added successfully!");
    }

    /// <summary>
    /// Get Question with answer
    /// </summary>
    /// <param name="question"></param>
    public void GetQuestion(string question)
    {
        if (question.Length > 255)
        {
            Console.WriteLine("Question exceeds the maximum allowed length of 255 characters.");
            return;
        }

        var userQuestion = questionAnswers.FirstOrDefault(x => x.Question == question);

        if (questionAnswers.Any(x => x.Question == question))
        {
            foreach (string answer in userQuestion.Answers)
            {
                Console.WriteLine(answer);
            }
        }
        else
        {
            Console.WriteLine("The answer to life, universe and everything is 42");
        }
    }


}
