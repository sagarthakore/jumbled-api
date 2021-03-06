using System.Collections.Generic;
using Xunit;
using Jumbled_API.Services;
using Jumbled_API.Services.Interfaces;

namespace Jumbled_API_TESTS
{
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
            List<string> expected = new List<string>
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
        [InlineData("f______rk")]
        public void GetDictionaryWordsFromPartWord_WordsExist_GetWords(string value)
        {
            List<string> result = _jumbledService.GetDictionaryWordsFromLetters(value);
            List<string> expected = new List<string>
            {
                "fancywork",
                "fieldwork",
                "framework",
                "frostwork"
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
        [InlineData("kl__fd__h_la")]
        public void GetDictionaryWordsFromPart_WordsDontExist_GetEmptyArray(string value)
        {
            List<string> result = _jumbledService.GetDictionaryWords(value);
            Assert.Empty(result);
        }
    }
}