namespace Jumbled_API_TESTS;

public class JumbledServiceTests
{
    private readonly IJumbledService _jumbledService;

    public JumbledServiceTests()
    {
        _jumbledService = new JumbledService();
    }

    [Theory]
    [InlineData("danger")]
    public void GetDictionaryWords_WordsExist_GetWords(string value)
    {
        List<string> result = _jumbledService.GetDictionaryWords(value);
        List<string> expected = new()
        {
            "danger",
            "gander",
            "garden",
            "grande",
            "ranged"
        };

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("f______rk", "", "")]
    public void GetWordleGuessWord_WordsExist_GetWords(string value, string exclude, string include)
    {
        List<string> result = _jumbledService.GetWordleGuess(value, exclude, include);
        List<string> expected = new()
        {
            "fancywork",
            "fieldwork",
            "framework",
            "frostwork"
        };

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("_rick", "tb", "")]
    public void GetWordleGuessWordExcludeLetters_WordsExist_GetWords(string value, string exclude, string include)
    {
        List<string> result = _jumbledService.GetWordleGuess(value, exclude, include);
        List<string> expected = new()
        {
            "crick",
            "prick"
        };

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("_ric_", "", "____b")]
    public void GetWordleGuessWordIncludeLetters_WordsExist_GetWords(string value, string exclude, string include)
    {
        List<string> result = _jumbledService.GetWordleGuess(value, exclude, include);
        List<string> expected = new()
        {
            "brick"
        };

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("_o___", "ad", "b__r_")]
    public void GetWordleGuessWordIncludeExcludeLetters_WordsExist_GetWords(string value, string exclude, string include)
    {
        List<string> result = _jumbledService.GetWordleGuess(value, exclude, include);
        List<string> expected = new()
        {
            "robes",
            "robin",
            "roble",
            "robot",
            "sober"
        };

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("klsjfdkfhfla")]
    public void GetDictionaryWords_WordsDontExist_GetEmptyArray(string value)
    {
        List<string> result = _jumbledService.GetDictionaryWords(value);
        Assert.Empty(result);
    }

    [Theory]
    [InlineData("kl__fd__h_la", "", "")]
    public void GetWordleGuess_WordsDontExist_GetEmptyArray(string value, string exclude, string include)
    {
        List<string> result = _jumbledService.GetWordleGuess(value, exclude, include);
        Assert.Empty(result);
    }
}