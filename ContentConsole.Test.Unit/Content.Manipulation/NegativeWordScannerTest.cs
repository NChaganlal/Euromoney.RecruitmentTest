using System.Collections.Generic;
using Content.Data;
using Content.Manipulation;
using Moq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit.Content.Manipulation
{
    [TestFixture]
    public class NegativeWordScannerTest
    {
        [Test, TestCaseSource(typeof(TestDataFactory), "CountNegativeWordsTestCases")]
        public int Verify_Negative_Word_Count_Is_Correct(List<string> negativeWords, string contentToScan)
        {
            //Arrange
            Mock<INegativeWordRepository> wordRepositoryMock = new Mock<INegativeWordRepository>();
            NegativeWordScanner wordAnalyzer = new NegativeWordScanner(wordRepositoryMock.Object);
            wordRepositoryMock.Setup(x => x.GetNegativeWords()).Returns(negativeWords);

            //Act and Assert
            return wordAnalyzer.CountNegativeWords(contentToScan);
        }
    }
}
