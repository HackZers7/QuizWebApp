using System;
using System.Collections.Generic;

namespace QuizWebApp.Models;

public abstract class QuestionBase : ICloneable
{
    private int _lastId;

    public int Id { get; set; }
    public List<AnswerBase> Answers { get; } = new();
    public string QuestionText { get; set; } = string.Empty;

    public abstract object Clone();

    public virtual int CheckAnswers(List<AnswerBase> answers)
    {
        var correctCount = 0;

        foreach (var answer in answers) correctCount = CheckAnswer(answer) ? correctCount + 1 : correctCount;

        return correctCount;
    }

    public abstract AnswerBase CreateAnswer();

    public abstract bool CheckAnswer(AnswerBase answer);

    protected int GetNextAnswersId()
    {
        return _lastId++;
    }
}