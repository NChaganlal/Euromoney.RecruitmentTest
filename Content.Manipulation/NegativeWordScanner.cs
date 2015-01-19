using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Content.Data;

namespace Content.Manipulation
{
    /// <summary>
    /// This class provides information about negative words scanned in a content
    /// </summary>
    public class NegativeWordScanner : INegativeWordScanner
    {
        public INegativeWordRepository NegativeWordRepository { get; set; }

        public NegativeWordScanner(INegativeWordRepository negativeWordRepository)
        {
            NegativeWordRepository = negativeWordRepository;
        }

        public int CountNegativeWords(string contentToScan)
        {
            if (!string.IsNullOrWhiteSpace(contentToScan))
            {
                var negativeWordList = NegativeWordRepository.GetNegativeWords();

                if (negativeWordList != null && negativeWordList.Any())
                {
                    return negativeWordList
                        .Select(negativeWord => @"\b" + negativeWord + @"\b")
                        .Select(pattern => Regex.Matches(contentToScan, pattern).Count)
                        .Sum();
                }
            }
            return 0;
        }

        public string MaskNegativeWord(string word)
        {
            var negativeWordList = NegativeWordRepository.GetNegativeWords();

            if (!string.IsNullOrWhiteSpace(word) && negativeWordList != null)
            {
                if (negativeWordList.Any(negativeWord => word.Equals(negativeWord, StringComparison.InvariantCultureIgnoreCase)))
                {
                    return new string(word.Select((c, i) => i > 0 && i < (word.Length - 1) ? '#' : c).ToArray());
                }
            }

            return word;
        }

        public string FilterNegativeWordsFromContent(string contentToScan)
        {
            if (!string.IsNullOrWhiteSpace(contentToScan))
            {
                var negativeWordList = NegativeWordRepository.GetNegativeWords();

                if (negativeWordList != null && negativeWordList.Any())
                {
                    foreach (var negativeWord in negativeWordList)
                    {
                        string pattern = @"\b" + negativeWord + @"\b";
                        contentToScan = Regex.Replace(contentToScan, pattern, MaskNegativeWord(negativeWord), RegexOptions.IgnoreCase);
                    }
                }
            }
            return contentToScan;
        }
    }
}
