using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Data
{
    public interface INegativeWordRepository
    {
        List<string> GetNegativeWords();
        
        void SaveNegativeWords(List<string> listToCreate);
    }
}
