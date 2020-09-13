using System;
using System.Collections.Generic;
using System.IO;

namespace Jumbled_API.Services
{
    public class Jumbled
    {
        Dictionary<string, List<string>> dictionary;
        public Jumbled() 
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
            string[] words = File.ReadAllLines("Resources/words_en.txt");
            foreach (string word in words)
            {
                string wordKey = GenerateWordKey(word);
                List<string> wordList = dictionary.ContainsKey(wordKey) ? dictionary[wordKey] : new List<string>();
                wordList.Add(word);
                dictionary[wordKey] = wordList;
            }
            return dictionary;
        }

        private String GenerateWordKey(String inputString)
        {
            char[] chars = inputString.ToCharArray();
            Array.Sort(chars);
            return new String(chars);
        }
    }
}
