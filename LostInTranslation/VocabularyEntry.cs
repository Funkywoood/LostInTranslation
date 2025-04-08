using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostInTranslation
{
    public class VocabularyEntry
    {
        public string Original { get; set; }
        public string Translation { get; set; }
        public int CorrectCount { get; set; } = 0;  // Fortschritt
    }
}


