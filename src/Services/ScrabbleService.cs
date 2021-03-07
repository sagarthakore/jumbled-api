using System.Collections.Generic;
using System.IO;
using System.Linq;
using Jumbled_API.Models;
using Jumbled_API.Services.Interfaces;

namespace Jumbled_API.Services
{
    public class ScrabbleService : IScrabbleService
    {
        private readonly Dictionary<char, int> letterScores;
        private string[] scrabbleWords;

        public ScrabbleService()
        {
            letterScores = GetLetterScores();
            scrabbleWords = File.ReadAllLines("Resources/scrabblewords.txt");
        }

        public List<ScrabbleResult> GetScrabbleWordsWithScores(string rack)
        {
            List<ScrabbleResult> scrabbleResult = new List<ScrabbleResult>();

            foreach (string word in scrabbleWords)
            {
                bool candidate = true;
                List<char> rackLetters = rack.ToUpper().ToList();

                foreach (char letter in word)
                {
                    if (!rackLetters.Contains(letter))
                    {
                        candidate = false;
                        break;
                    }
                    else
                    {
                        rackLetters.Remove(letter);
                    }
                }

                if (candidate)
                {
                    int total = 0;

                    foreach (char letter in word)
                    {
                        total = total + letterScores[letter];
                    }

                    scrabbleResult.Add(new ScrabbleResult() { word = word, score = total });
                }
            }

            return scrabbleResult.OrderByDescending(sr => sr.score).ToList();
        }

        private Dictionary<char, int> GetLetterScores()
        {
            return new Dictionary<char, int>()
            {
                {'A', 1}, {'B', 3}, {'C', 3}, {'D', 2}, {'E', 1}, {'F', 4},
                {'G', 2}, {'H', 4}, {'I', 1}, {'J', 8}, {'K', 5}, {'L', 1},
                {'M', 3}, {'N', 1}, {'O', 1}, {'P', 3}, {'Q', 10}, {'R', 1},
                {'S', 1}, {'T', 1}, {'U', 1}, {'V', 4}, {'W', 4}, {'X', 8},
                {'Y', 4}, {'Z', 10}
            };
        }
    }
}
