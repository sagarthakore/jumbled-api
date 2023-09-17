namespace Jumbled_API_TESTS;

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
        List<ScrabbleResult> expectedResult = new()
        {
            new ScrabbleResult { Word = "AA", Score = 2 },
            new ScrabbleResult { Word = "AA", Score = 2 },
            new ScrabbleResult { Word = "AA", Score = 2 },
            new ScrabbleResult { Word = "AA", Score = 2 },
            new ScrabbleResult { Word = "AA", Score = 2 }
        };

        List<ScrabbleResult> result = _scrabbleService.GetScrabbleWordsWithScores(value);

        Assert.Contains(result, result => result.Word == "AA" && result.Score == 2);
        Assert.Contains(result, result => result.Word == "AH" && result.Score == 5);
        Assert.Contains(result, result => result.Word == "HA" && result.Score == 5);
        Assert.Contains(result, result => result.Word == "AAH" && result.Score == 6);
        Assert.Contains(result, result => result.Word == "AHA" && result.Score == 6);
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