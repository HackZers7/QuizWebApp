namespace QuizWebApp.Models;

public class TextNode : QuestionNode
{
    public TextNode(string question) : base(question)
    {
    }

    public string Value { get; set; }
}