using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    /// <summary>
    /// This class is responsible for generating data for testing
    /// </summary>
    public class TestDataFactory
    {
        private static readonly List<string> NegativeWords = new List<string> { "swine", "bad", "nasty", "horrible" };

        public static IEnumerable CountNegativeWordsTestCases
        {
            get
            {
                yield return new TestCaseData(NegativeWords
                    , "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.")
                    .Returns(2)
                    .SetName("Negative words found");
                yield return new TestCaseData(NegativeWords
                    , "The weather in Manchester in winter is fantastic. It is sunny all the time - it must be nice for people visiting.")
                    .Returns(0)
                    .SetName("There are no negative words");
                yield return new TestCaseData(NegativeWords
                    , null)
                    .Returns(0)
                    .SetName("Null input is provided");
                yield return new TestCaseData(NegativeWords
                    , string.Empty)
                    .Returns(0)
                    .SetName("Empty input is provided");
                yield return new TestCaseData(NegativeWords
                    , " ")
                    .Returns(0)
                    .SetName("Whitespace input is provided");
            }
        }
    }
}
