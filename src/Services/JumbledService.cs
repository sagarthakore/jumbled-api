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
            words = File.ReadAllLines("Resources/words_en.txt").ToList();
            dictionary = CreateDictionary();
        }

        public List<string> GetDictionaryWords(string jumbledWord)
        {
            string jumbledWordKey = GenerateWordKey(jumbledWord.ToLower());
            return this.dictionary.ContainsKey(jumbledWordKey) ? this.dictionary[jumbledWordKey] : new List<string>();
        }

        public List<string> GetDictionaryWordsFromLetters(string letters)
        {
            if (letters.Length == 0) return new List<string>();
            List<string> result = new List<string>();

            foreach (string word in this.words.Where(word => word.Length == letters.Length)?.ToList())
            {
                bool candidate = true;
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i] != '_' && letters[i] != word[i])
                    {
                        candidate = false;
                        break;
                    }
                }

                if (candidate) result.Add(word);
            }

            return result;
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
