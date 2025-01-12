using System;
using System.Collections.Generic;
using System.Linq;

namespace Atelier_des_Mots.ViewModels
{
    public class TeacherViewModel
    {
        // Property for storing the word without hyphens
        public string CorrectWord { get; set; }

        // Property for storing the syllables (split by hyphens)
        public string[] DisplaySyllables { get; set; }

        // Property for storing the correct phrase
        public string CorrectPhrase { get; set; }

        // Property for storing the disordered words (for phrase exercises)
        public string[] DisorderedWords { get; set; }

        // Property for storing selected syllables
        public List<string> SelectedSyllables { get; set; } = new List<string>();

        // Property for storing the assembled word from selected syllables
        public string AssembledWord { get; set; }

        // Constructor to initialize the ViewModel with empty data
        public TeacherViewModel()
        {
            DisplaySyllables = Array.Empty<string>();
            DisorderedWords = Array.Empty<string>();
        }

        // Method to assemble the word by joining selected syllables
        public void AssembleWord()
        {
            AssembledWord = string.Join("", SelectedSyllables);
        }
    }
}
