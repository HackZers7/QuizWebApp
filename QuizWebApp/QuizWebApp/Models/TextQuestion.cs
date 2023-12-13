namespace QuizWebApp.Models;

public class TextQuestion : QuestionBase
{
    public override AnswerBase CreateAnswer()
    {
        var newAnswer = new TextAnswer
        {
            Id = GetNextAnswersId()
        };
        Answers.Add(newAnswer);
        return newAnswer;
    }

    public override bool CheckAnswer(AnswerBase answer)
    {
        if (answer is not TextAnswer validAnswer) return false;
        foreach (var thisAnswer in Answers)
            return thisAnswer.CheckAnswer(validAnswer);

        return false;
    }
}