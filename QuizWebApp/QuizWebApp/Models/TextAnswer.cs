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

    public override bool CheckAnswer(AnswerBase answer)
    {
        if (answer is TextAnswer validAnswer) return Value.Equals(validAnswer.Value);

        return false;
    }
}