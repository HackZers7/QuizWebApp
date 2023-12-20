using System;
using System.Collections.Generic;

namespace QuizWebApp.Models;

[Serializable]
public class Quiz : ICloneable
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<QuestionBase> Questions { get; } = new();

    public object Clone()
    {
        var output = new Quiz
        {
            Id = Id,
            Name = Name
        };

        foreach (var value in Questions) output.Questions.Add((QuestionBase)value.Clone());

        return output;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Quiz value) return value.Id.Equals(Id);

        return false;
    }
}