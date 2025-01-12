using Atelier_des_Mots.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Atelier_des_Mots.ViewModels
{
    internal class StudentViewModel
    {
        // Property to store the disordered syllables or words for the student to reorder
        public List<string> DisorderedSyllables { get; set; }
        public List<string> DisorderedWords { get; set; }

        // Property to store the student's reordered syllables or words
        public List<string> StudentSyllables { get; set; }
        public List<string> StudentWords { get; set; }

        // Method to check if the student has correctly reordered the syllables
        public bool CheckWordAssembly()
        {
            string studentWord = string.Join("", StudentSyllables);
            string correctWord = string.Join("", DisorderedSyllables);
            return studentWord.Equals(correctWord, StringComparison.InvariantCultureIgnoreCase);
        }

        // Method to check if the student has correctly reordered the phrase
        public bool CheckPhraseAssembly()
        {
            string studentPhrase = string.Join(" ", StudentWords);
            string correctPhrase = string.Join(" ", DisorderedWords);
            return studentPhrase.Equals(correctPhrase, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
