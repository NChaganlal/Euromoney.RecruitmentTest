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

        [Test, TestCaseSource(typeof(TestDataFactory), "MaskNegativeWordTestCases")]
        public void Verify_Negative_Words_Are_Masked(List<string> negativeWords, string content, string maskedContent)
        {
            //Arrange
            Mock<INegativeWordRepository> wordRepositoryMock = new Mock<INegativeWordRepository>();
            NegativeWordScanner wordAnalyzer = new NegativeWordScanner(wordRepositoryMock.Object);
            wordRepositoryMock.Setup(x => x.GetNegativeWords()).Returns(negativeWords);

            //Act
            var maskedWord = wordAnalyzer.MaskNegativeWord(content);

            //Assert
            Assert.AreEqual(maskedContent, maskedWord);
        }

        [Test, TestCaseSource(typeof(TestDataFactory), "MaskNegativeWordsInContentTestCases")]
        public void Verify_Negative_Words_Are_Masked_In_Content(List<string> negativeWords, string contentToScan, string maskedContent)
        {
            //Arrange
            Mock<INegativeWordRepository> wordRepositoryMock = new Mock<INegativeWordRepository>();
            NegativeWordScanner wordAnalyzer = new NegativeWordScanner(wordRepositoryMock.Object);
            wordRepositoryMock.Setup(x => x.GetNegativeWords()).Returns(negativeWords);

            //Act
            var result = wordAnalyzer.FilterNegativeWordsFromContent(contentToScan);

            //Assert
            Assert.AreEqual(maskedContent, result);
        }
    }
}
