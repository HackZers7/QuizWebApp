namespace QuizWebApp.Services;

public interface IAbstractFactory<T>
{
    T Create();
}