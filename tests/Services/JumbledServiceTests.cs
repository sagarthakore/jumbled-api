namespace Jumbled_API_TESTS;

public class JumbledServiceTests
{
    private readonly JumbledService _jumbledService;

    public JumbledServiceTests()
    {
        _jumbledService = new JumbledService();
    }

    [Theory]
    [InlineData("danger")]
    public void GetDictionaryWords_WordsExist_GetWords(string value)
    {
        HashSet<string> result = _jumbledService.GetDictionaryWords(value);
        HashSet<string> expected =
        [
            "danger",
            "gander",
            "garden",
            "grande",
            "ranged"
        ];

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("f______rk", "", "")]
    public void GetWordGuessWord_WordsExist_GetWords(string value, string exclude, string include)
    {
        List<string> result = _jumbledService.GetWordGuess(value, exclude, include);
        List<string> expected =
        [
            "fancywork",
            "fieldwork",
            "framework",
            "frostwork"
        ];

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("_rick", "tb", "")]
    public void GetWordGuessWordExcludeLetters_WordsExist_GetWords(string value, string exclude, string include)
    {
        List<string> result = _jumbledService.GetWordGuess(value, exclude, include);
        List<string> expected =
        [
            "crick",
            "prick"
        ];

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("_ric_", "", "____b")]
    public void GetWordGuessWordIncludeLetters_WordsExist_GetWords(string value, string exclude, string include)
    {
        List<string> result = _jumbledService.GetWordGuess(value, exclude, include);
        List<string> expected =
        [
            "brick"
        ];

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("_o___", "ad", "b__r_")]
    public void GetWordGuessWordIncludeExcludeLetters_WordsExist_GetWords(string value, string exclude, string include)
    {
        List<string> result = _jumbledService.GetWordGuess(value, exclude, include);
        List<string> expected =
        [
            "robes",
            "robin",
            "roble",
            "robot",
            "sober"
        ];

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("klsjfdkfhfla")]
    public void GetDictionaryWords_WordsDontExist_GetEmptyArray(string value)
    {
        HashSet<string> result = _jumbledService.GetDictionaryWords(value);
        Assert.Empty(result);
    }

    [Theory]
    [InlineData("kl__fd__h_la", "", "")]
    public void GetWordGuess_WordsDontExist_GetEmptyArray(string value, string exclude, string include)
    {
        List<string> result = _jumbledService.GetWordGuess(value, exclude, include);
        Assert.Empty(result);
    }
}