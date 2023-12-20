namespace QuizWebApp.Models;

public class TextQuestion : QuestionBase
{
    public override object Clone()
    {
        var output = new TextQuestion
        {
            Id = Id,
            QuestionText = QuestionText
        };

        foreach (var value in Answers) output.Answers.Add((AnswerBase)value.Clone());

        return output;
    }

    public override AnswerBase CreateAnswer()
    {
        var newAnswer = new TextAnswer
        {
            Id = GetNextAnswersId()
        };
        Answers.Add(newAnswer);
        return newAnswer;
    }
}