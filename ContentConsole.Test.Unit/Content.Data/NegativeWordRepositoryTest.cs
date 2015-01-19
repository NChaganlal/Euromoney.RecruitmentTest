using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Data;
using NUnit.Framework;

namespace ContentConsole.Test.Unit.Content.Data
{
    [TestFixture]
    public class NegativeWordRepositoryTest
    {
        private NegativeWordRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new NegativeWordRepository();

        }

        [Test]
        public void Verify_Negative_Words_Are_Returned()
        {
            //Arrange
            _repository.NegativeWordList = new List<string> {"swine", "bad", "nasty", "horrible"};

            //Act
            var wordList = _repository.GetNegativeWords();

            //Assert
            Assert.IsNotNull(wordList);
            Assert.IsTrue(wordList.Count > 0, "List is not expected to be empty");
        }

        [Test]
        public void Save_Negative_Words_List()
        {
            //Arrange
            List<string> listToCreate = new List<string> {"bad", "horrible"};

            //Act
            _repository.SaveNegativeWords(listToCreate);

            //Assert
            Assert.AreEqual(2, _repository.GetNegativeWords().Count);
            Assert.AreEqual("bad", _repository.GetNegativeWords()[0]);
            Assert.AreEqual("horrible", _repository.GetNegativeWords()[1]);
        }
    }
}
