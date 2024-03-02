namespace Jumbled_API.Services;

public class ScrabbleService : IScrabbleService
{
    private readonly Dictionary<char, int> letterScores;
    private readonly List<string> scrabbleWords;

    public ScrabbleService()
    {
        scrabbleWords = File.ReadLines("Resources/scrabblewords.txt").ToList();
        letterScores = GetLetterScores();
    }

    public List<ScrabbleResult> GetScrabbleWordsWithScores(string rack)
    {
        return scrabbleWords
            .Where(word => word.Length <= rack.Length && word.All(c => rack.ToUpper().Count(l => l == c) >= word.Count(l => l == c)))
            .Select(word => new ScrabbleResult { Word = word, Score = word.Sum(c => letterScores[c]) })
            .OrderByDescending(sr => sr.Score)
            .ToList();
    }

    private static Dictionary<char, int> GetLetterScores()
    {
        return new Dictionary<char, int>()
        {
            {'A', 1}, {'B', 3}, {'C', 3}, {'D', 2}, {'E', 1}, {'F', 4},
            {'G', 2}, {'H', 4}, {'I', 1}, {'J', 8}, {'K', 5}, {'L', 1},
            {'M', 3}, {'N', 1}, {'O', 1}, {'P', 3}, {'Q', 10}, {'R', 1},
            {'S', 1}, {'T', 1}, {'U', 1}, {'V', 4}, {'W', 4}, {'X', 8},
            {'Y', 4}, {'Z', 10}
        };
    }
}
