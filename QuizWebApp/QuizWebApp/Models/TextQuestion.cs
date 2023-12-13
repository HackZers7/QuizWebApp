namespace QuizWebApp.Models;

public class TextQuestion : QuestionBase
{
    public string Value { get; set; }

    public override bool CheckAnswer(AnswerBase answer)
    {
        if (answer is not TextAnswer validAnswer) return false;
        foreach (var thisAnswer in Answers)
            return thisAnswer.CheckAnswer(validAnswer);

        return false;
    }
}