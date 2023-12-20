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

    public abstract AnswerBase CreateAnswer();

    protected int GetNextAnswersId()
    {
        return _lastId++;
    }
}