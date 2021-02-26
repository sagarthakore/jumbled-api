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
            Assert.Contains("danger", result);
            Assert.Contains("gander", result);
            Assert.Contains("garden", result);
            Assert.Contains("grande", result);
            Assert.Contains("ranged", result);
            Assert.Equal(5, result.Count);
        }

        [Theory]
        [InlineData("klsjfdkfhfla")]
        public void GetDictionaryWords_WordsDontExist_GetEmptyArray(string value)
        {
            List<string> result = _jumbledService.GetDictionaryWords(value);
            Assert.Empty(result);
        }
    }
}