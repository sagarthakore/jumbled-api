using System.Collections.Generic;
using Xunit;
using Jumbled_API.Services;
using Jumbled_API.Services.Interfaces;
using Jumbled_API.Models;

namespace Jumbled_API_TESTS
{
    public class ScrabbleServiceTests
    {
        private readonly IScrabbleService _scrabbleService;

        public ScrabbleServiceTests()
        {
            _scrabbleService = new ScrabbleService();
        }

        [Theory]
        [InlineData("aah")]
        public void GetScrabbleWords_WordsExist_GetWordsWithScore(string value)
        {
            List<ScrabbleResult> expectedResult = new List<ScrabbleResult>()
            {
                new ScrabbleResult { word = "AA", score = 2 },
                new ScrabbleResult { word = "AA", score = 2 },
                new ScrabbleResult { word = "AA", score = 2 },
                new ScrabbleResult { word = "AA", score = 2 },
                new ScrabbleResult { word = "AA", score = 2 }
            };

            List<ScrabbleResult> result = _scrabbleService.GetScrabbleWordsWithScores(value);
            
            Assert.Contains(result, result => result.word == "AA" && result.score == 2);
            Assert.Contains(result, result => result.word == "AH" && result.score == 5);
            Assert.Contains(result, result => result.word == "HA" && result.score == 5);
            Assert.Contains(result, result => result.word == "AAH" && result.score == 6);
            Assert.Contains(result, result => result.word == "AHA" && result.score == 6);
            Assert.Equal(5, result.Count);
        }

        [Theory]
        [InlineData("plplplplplpl")]
        public void GetScrabbleWords_WordsDontExist_GetEmptyArray(string value)
        {
            List<ScrabbleResult> result = _scrabbleService.GetScrabbleWordsWithScores(value);
            Assert.Empty(result);
        }
    }
}