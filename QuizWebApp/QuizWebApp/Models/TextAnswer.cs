namespace QuizWebApp.Models;

public class TextAnswer : AnswerBase
{
    public string Value { get; set; }

    public override object Clone()
    {
        return new TextAnswer
        {
            Id = Id,
            IsCorrect = IsCorrect,
            Value = Value
        };
    }
}