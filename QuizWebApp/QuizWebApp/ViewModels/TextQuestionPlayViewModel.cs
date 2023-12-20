using Avalonia.Controls;
using QuizWebApp.Models;

namespace QuizWebApp.ViewModels;

public class TextQuestionPlayViewModel : QuestionPlayViewModel
{
    public TextQuestionPlayViewModel(TextQuestion question) : base(question)
    {
    }

    public string Answer { get; set; }

    public override Control View { get; }

    public override int CheckQuestion()
    {
        var count = 0;
        foreach (var answer in _question.Answers)
            if (answer is TextAnswer textAnswer)
                if (textAnswer.Value.ToLower().Trim().Equals(Answer.ToLower().Trim()))
                    count = 1;

        return count;
    }
}