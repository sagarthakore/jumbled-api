using System.Collections.Generic;
using Jumbled_API.Models;

namespace Jumbled_API.Services.Interfaces;

public interface IScrabbleService
{
    List<ScrabbleResult> GetScrabbleWordsWithScores(string rack);
}