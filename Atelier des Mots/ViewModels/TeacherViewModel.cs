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
        public List<string> DisplaySyllables { get; set; }

        // Property for storing the correct phrase
        public string CorrectPhrase { get; set; }

        // Property for storing the disordered words (for phrase exercises)
        public string[] DisorderedWords { get; set; }

        // Property for storing selected syllables
        public List<string> SelectedSyllables { get; set; } = new List<string>();

        // Property for storing the assembled word from selected syllables
        public string AssembledWord { get; set; }

        // Property for displaying the syllables of the current word
        public List<string> DisplaySyllables1 { get; set; }

        // Property to store the correct word for the current word index
        public string CorrectWord1 { get; set; }

        // Property to store the assembled word for the current word
        public string AssembledWord1 { get; set; }

        // Array of all words (used to traverse the exercise)
        public string[] Words { get; set; }

        // Index to track the current word being displayed
        public int CurrentWordIndex { get; set; }
        public List<string> Phrases { get; set; } = new List<string>();
        public int CurrentPhraseIndex { get; private set; } = 0;


        // Constructor to initialize the ViewModel with empty data
        public TeacherViewModel()
        {
            DisplaySyllables1 = new List<string>(); // Initialize as an empty list
            DisorderedWords = Array.Empty<string>(); // Keep this as an empty array

        }

        // Method to set the next word in the sequence
        public void SetNextWord()
        {
            if (CurrentWordIndex < Words.Length - 1)
            {
                CurrentWordIndex++;
                var syllables = Words[CurrentWordIndex].Split('-').ToList();
                DisplaySyllables1 = syllables; // Set the new syllables for the current word
                CorrectWord = string.Join("", syllables); // Correct word for the current word
                CorrectWord1 = CorrectWord; // Store the correct word for the current word (renamed to CorrectWord1)
                AssembledWord1 = CorrectWord; // Set the assembled word to the correct word
            }
        }
        public void SetCurrentPhraseIndex(int index)
        {
            if (index >= 0 && index < Phrases.Count)
            {
                CorrectPhrase = Phrases[index]; // Update the current phrase
                DisorderedWords = CorrectPhrase.Split(' ')
                                                .OrderBy(x => Guid.NewGuid())
                                                .ToArray(); // Shuffle the words
            }
        }

        // Method to set the current word based on index
        public void SetCurrentWord(int index)
        {
            CurrentWordIndex = index;
            var syllables = Words[CurrentWordIndex].Split('-');
            DisplaySyllables1 = syllables.ToList(); // Convert to List<string>
            CorrectWord = string.Join("", syllables); // Set the correct word
            AssembledWord = CorrectWord; // Store the assembled word
        }
        public void SetNextPhrase()
        {
            if (HasNextPhrase())
            {
                CurrentPhraseIndex++; // Increment to the next phrase
                SetCurrentPhraseIndex(CurrentPhraseIndex); // Update the CorrectPhrase and DisorderedWords
            }
        }

        public bool HasNextPhrase()
        {
            return CurrentPhraseIndex + 1 < Phrases.Count;
        }
        // Method to assemble the word by joining selected syllables
        public void AssembleWord()
        {
            AssembledWord = string.Join("", SelectedSyllables);
        }
    }
}
