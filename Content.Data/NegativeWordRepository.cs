using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Data
{
    public class NegativeWordRepository : INegativeWordRepository
    {
        private List<string> _negativeWordsList;

        public List<string> NegativeWordList
        {
            set { _negativeWordsList = value; }
        }

        public List<string> GetNegativeWords()
        {            
            return _negativeWordsList;
        }

        public void SaveNegativeWords(List<string> listToCreate)
        {
            _negativeWordsList = listToCreate;
        }
    }
}
