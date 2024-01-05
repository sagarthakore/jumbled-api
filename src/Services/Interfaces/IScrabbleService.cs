namespace Jumbled_API.Services.Interfaces;

public interface IScrabbleService
{
    List<ScrabbleResult> GetScrabbleWordsWithScores(string rack);
}