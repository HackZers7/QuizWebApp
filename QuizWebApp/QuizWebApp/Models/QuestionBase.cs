using System.Collections.Generic;

namespace QuizWebApp.Models;

public abstract class QuestionBase
{
    public List<AnswerBase> Answers { get; } = new();
    public string QuestionText { get; set; } = string.Empty;

    public virtual void AddAnswer(AnswerBase answer)
    {
        Answers.Add(answer);
    }

    public virtual int CheckAnswers(List<AnswerBase> answers)
    {
        var correctCount = 0;

        foreach (var answer in answers) correctCount = CheckAnswer(answer) ? correctCount + 1 : correctCount;

        return correctCount;
    }

    public abstract bool CheckAnswer(AnswerBase answer);
}