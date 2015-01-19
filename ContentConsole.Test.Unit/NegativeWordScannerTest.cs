using System.Collections.Generic;
using Content.Manipulation;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class NegativeWordScannerTest
    {
        [Test, TestCaseSource(typeof(TestDataFactory), "CountNegativeWordsTestCases")]
        public int Verify_Negative_Word_Count_Is_Correct(List<string> negativeWords, string contentToScan)
        {
            //Arrange
            NegativeWordScanner wordAnalyzer = new NegativeWordScanner();

            //Act and Assert
            return wordAnalyzer.CountNegativeWords(contentToScan);
        }
    }
}
