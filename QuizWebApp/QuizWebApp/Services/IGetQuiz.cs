using System.Collections.Generic;
using QuizWebApp.Models;

namespace QuizWebApp.Services;

public interface IGetQuiz
{
    Quiz? GetQuiz(int id);
    List<Quiz> GetAllQuiz();
    void Add(Quiz quiz);
}