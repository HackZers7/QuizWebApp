namespace QuizWebApp.Models;

public abstract class QuestionNode
{
    protected QuestionNode(string question)
    {
        Question = question;
    }

    public string Question { get; }
}