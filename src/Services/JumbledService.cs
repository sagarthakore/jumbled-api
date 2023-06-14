using System;
using System.Collections.Generic;
using System.IO;
using Jumbled_API.Services.Interfaces;
using System.Linq;

namespace Jumbled_API.Services;

public class JumbledService : IJumbledService
{
    private readonly Dictionary<string, HashSet<string>> dictionary;
    private readonly List<string> words;

    public JumbledService()
    {
        words = File.ReadAllLines("Resources/words_en.txt").ToList();
        dictionary = CreateDictionary();
    }

    public HashSet<string> GetDictionaryWords(string jumbledWord)
    {
        string jumbledWordKey = GenerateWordKey(jumbledWord.ToLower());
        return dictionary.ContainsKey(jumbledWordKey) ? dictionary[jumbledWordKey] : new HashSet<string>();
    }

    public List<string> GetWordleGuess(string guess, string exclude, string include)
    {
        if (guess.Length == 0) return new List<string>();

        var result = new List<string>();
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

    private Dictionary<string, HashSet<string>> CreateDictionary()
    {
        Dictionary<string, HashSet<string>> dictionary = new();
        foreach (string word in words)
        {
            string wordKey = GenerateWordKey(word);
            if (!dictionary.TryGetValue(wordKey, out HashSet<string> wordList))
            {
                wordList = new HashSet<string>();
                dictionary[wordKey] = wordList;
            }
            wordList.Add(word);
        }
        return dictionary;
    }

    private static string GenerateWordKey(string inputString)
    {
        char[] chars = inputString.ToCharArray();
        Array.Sort(chars);
        return string.Concat(chars);
    }
}
