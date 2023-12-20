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
        foreach (var answer in Question.Answers)
        {
            
        }
    }
}