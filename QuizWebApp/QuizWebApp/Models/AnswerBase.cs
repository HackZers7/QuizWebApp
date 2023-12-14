using System;

namespace QuizWebApp.Models;

public abstract class AnswerBase : ICloneable
{
    public int Id { get; set; }
    public bool IsCorrect { get; set; } = false;
    public abstract object Clone();

    public abstract bool CheckAnswer(AnswerBase answer);
}