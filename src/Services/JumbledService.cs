using System;
using System.Collections.Generic;
using System.IO;
using Jumbled_API.Services.Interfaces;
using System.Linq;

namespace Jumbled_API.Services
{
    public class JumbledService : IJumbledService
    {
        private readonly Dictionary<string, List<string>> dictionary;
        private readonly List<string> words;

        public JumbledService()
        {
            this.words = ReadWordsFromFile();
            this.dictionary = CreateDictionary();
        }

        public List<string> GetDictionaryWords(string jumbledWord)
        {
            string jumbledWordKey = GenerateWordKey(jumbledWord.ToLower());
            return this.dictionary.ContainsKey(jumbledWordKey) ? this.dictionary[jumbledWordKey] : new List<string>();
        }

        public List<string> GetDictionaryWords(string wordPart, int wordLength)
        {
            return this.words.Where(word => word.Length == wordLength && word.Contains(wordPart)).ToList() ?? new List<string>();
        }

        private List<string> ReadWordsFromFile()
        {
            return File.ReadAllLines("Resources/words_en.txt").ToList();
        }

        private Dictionary<string, List<string>> CreateDictionary()
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            foreach (string word in this.words)
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
