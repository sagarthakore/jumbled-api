using System;
using System.Collections.Generic;
using System.IO;
using Jumbled_API.Services.Interfaces;
using System.Linq;

namespace Jumbled_API.Services;

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
        return dictionary.ContainsKey(jumbledWordKey) ? dictionary[jumbledWordKey] : new List<string>();
    }

    public List<string> GetWordleGuess(string guess, string exclude, string include)
    {
        if (guess.Length == 0) return new List<string>();

        List<string> result = new();
        List<string> filteredWords = words.Where(word => word.Length == guess.Length)?.ToList();

        if (!string.IsNullOrEmpty(exclude))
        {
            foreach (string word in words.Where(word => word.Length == guess.Length)?.ToList())
            {
                bool candidate = false;
                for (int i = 0; i < exclude.Length; i++)
                {
                    if (word.Contains(exclude[i]))
                    {
                        candidate = true;
                        break;
                    }
                }

                if (candidate) filteredWords.RemoveAll(w => w == word);
            }
        }

        if (!string.IsNullOrEmpty(include) && include.Length == guess.Length)
        {
            foreach (string word in words.Where(word => word.Length == guess.Length)?.ToList())
            {
                bool candidate = false;
                for (int i = 0; i < include.Length; i++)
                {
                    if (include[i] != '_' && (!word.Contains(include[i]) || include[i] == word[i]))
                    {
                        candidate = true;
                        break;
                    }
                }

                if (candidate) filteredWords.RemoveAll(w => w == word);
            }
        }

        foreach (string word in filteredWords)
        {
            bool candidate = true;
            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] != '_' && guess[i] != word[i])
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
        Dictionary<string, List<string>> dictionary = new();
        foreach (string word in words)
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
