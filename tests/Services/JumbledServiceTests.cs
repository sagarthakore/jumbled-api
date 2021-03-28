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
        [InlineData("cess", 6)]
        public void GetDictionaryWordsFromPartWord_WordsExist_GetWords(string value, int length)
        {
            List<string> result = _jumbledService.GetDictionaryWords(value, length);
            List<string> expected = new List<string>
            {
                "access",
                "cessed",
                "cesses",
                "excess",
                "recess"
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
        [InlineData("cess", 90)]
        public void GetDictionaryWordsFromPart_WordsDontExist_GetEmptyArray(string value, int length)
        {
            List<string> result = _jumbledService.GetDictionaryWords(value, length);
            Assert.Empty(result);
        }
    }
}