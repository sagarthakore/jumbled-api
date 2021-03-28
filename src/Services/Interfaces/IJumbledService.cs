using System.Collections.Generic;

namespace Jumbled_API.Services.Interfaces
{
    public interface IJumbledService
    {
        List<string> GetDictionaryWords(string jumbledWord);
        List<string> GetDictionaryWords(string wordPart, int wordLength);
    }
}