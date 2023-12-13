namespace QuizWebApp.Models;

public abstract class AnswerBase
{
    public int Id { get; set; }
    public bool IsCorrect { get; set; } = false;

    public abstract bool CheckAnswer(AnswerBase answer);
}