namespace Jumbled_API.Services.Interfaces;

public interface IJumbledService
{
    HashSet<string> GetDictionaryWords(string jumbledWord);
    List<string> GetWordGuess(string guess, string exclude, string include);
}