using System;
using System.Collections.Generic;
using System.IO;
using Jumbled_API.Services.Interfaces;

namespace Jumbled_API.Services
{
    public class JumbledService : IJumbledService
    {
        private readonly Dictionary<string, List<string>> dictionary;

        public JumbledService()
        {
            this.dictionary = CreateDictionary();
        }

        public List<string> GetDictionaryWords(string jumbledWord)
        {
            string jumbledWordKey = GenerateWordKey(jumbledWord.ToLower());
            return this.dictionary.ContainsKey(jumbledWordKey) ? this.dictionary[jumbledWordKey] : new List<string>();
        }

        private Dictionary<string, List<string>> CreateDictionary()
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            foreach (string word in File.ReadAllLines("Resources/words_en.txt"))
            {
                string wordKey = GenerateWordKey(word);
                List<string> wordList = dictionary.ContainsKey(wordKey) ? dictionary[wordKey] : new List<string>();
                wordList.Add(word);
                dictionary[wordKey] = wordList;
            }
            return dictionary;
        }

        private string GenerateWordKey(string inputString)
        {
            char[] chars = inputString.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
    }
}
