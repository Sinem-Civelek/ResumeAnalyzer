using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class ResumeAnalyzerService
{
    private static readonly string[] ImportantSkills = new string[]
    {
        "C#", "Java", "Python", "React", "ASP.NET", "SQL", "Machine Learning", "NLP", "AWS", "Docker"
    };

    public static List<string> ExtractKeywords(string content)
    {
        if (string.IsNullOrEmpty(content))
            return new List<string>();

        var words = Regex.Split(content, @"\W+"); 
        var found = ImportantSkills.Where(skill => words.Any(w =>
            string.Equals(w, skill, StringComparison.OrdinalIgnoreCase)))
            .ToList();

        return found;
    }
}