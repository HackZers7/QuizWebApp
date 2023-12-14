using System.Collections.Generic;
using System.Linq;
using QuizWebApp.Models;

namespace QuizWebApp.Services;

public class GetQuizService : IGetQuiz
{
    private readonly List<Quiz> _quizzes = new();
    private int _last_value;

    public Quiz? GetQuiz(int id)
    {
        return (Quiz)_quizzes.FirstOrDefault(v => v.Id.Equals(id))?.Clone();
    }

    public List<Quiz> GetAllQuiz()
    {
        return _quizzes.Select(quiz => (Quiz)quiz.Clone()).ToList();
    }

    public void Add(Quiz quiz)
    {
        var i = _quizzes.FindIndex(v => v.Equals(quiz));

        if (i == -1)
        {
            quiz.Id = ++_last_value;
            _quizzes.Add(quiz);
            return;
        }

        _quizzes[i] = quiz;
    }
}