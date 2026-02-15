using FindJobsByKnowledge.Domain.Entities;

namespace FindJobsByKnowledge.Api.Services;

/// <summary>
/// Calculates skill levels per tag based on questionary answers.
/// The determined level is the highest level where the user scored >= 60%.
/// </summary>
public static class AssessmentCalculator
{
    private const double PassThreshold = 60.0;

    /// <summary>
    /// Calculates the assessment results for each tag in the questionary.
    /// </summary>
    public static List<TagResult> CalculateResults(Questionary questionary)
    {
        var results = new List<TagResult>();

        foreach (var tag in questionary.Tags)
        {
            var tagItems = questionary.Items
                .Where(i => i.Question.Tag.Equals(tag, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (tagItems.Count == 0) continue;

            var percentagePerLevel = new Dictionary<int, double>();
            var determinedLevel = 1;

            for (int level = 1; level <= 5; level++)
            {
                var levelItems = tagItems.Where(i => i.Question.Level == level).ToList();
                if (levelItems.Count == 0) continue;

                var correctCount = levelItems.Count(i => i.IsCorrect == true);
                var percentage = (double)correctCount / levelItems.Count * 100;
                percentagePerLevel[level] = Math.Round(percentage, 1);

                // User passes a level if they score >= threshold
                if (percentage >= PassThreshold)
                {
                    determinedLevel = level;
                }
            }

            var totalCorrect = tagItems.Count(i => i.IsCorrect == true);
            var overallPercentage = (double)totalCorrect / tagItems.Count * 100;

            results.Add(new TagResult
            {
                Id = Guid.NewGuid(),
                QuestionaryId = questionary.Id,
                Tag = tag,
                DeterminedLevel = determinedLevel,
                CorrectPercentage = Math.Round(overallPercentage, 1),
                PercentagePerLevel = percentagePerLevel
            });
        }

        return results;
    }
}
