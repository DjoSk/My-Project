using Atelier_des_Mots.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace Atelier_des_Mots.Views
{
    public partial class PhraseExercisePreparationView : Window
    {
        private TeacherViewModel _viewModel;
        private string _phraseData;  // Store phrase exercise data

        // Constructor to accept phrase exercise data
        public PhraseExercisePreparationView(string phraseData)  // Receive data
        {
            InitializeComponent();
            _phraseData = phraseData;  // Store it
            CorrectPhraseInput.Text = _phraseData;  // Directly use the phrase data (no need for Encoding)
        }

        // Shuffle the words in the phrase
        private void DisorderPhrase_Click(object sender, RoutedEventArgs e)
        {
            string phrase = CorrectPhraseInput.Text;
            var words = phrase.Split(' ');

            // Shuffle the words using a random order
            var shuffledWords = words.OrderBy(x => Guid.NewGuid()).ToArray();

            // Update the disordered phrase output in the ViewModel
            DisorderedPhraseOutput.Text = string.Join(" ", shuffledWords);
        }

        // Prepare the disordered phrase exercise and display to students
        public void DisplayToStudents_Click(object sender, RoutedEventArgs e)
        {
            string phrasesInput = CorrectPhraseInput.Text;

            if (string.IsNullOrWhiteSpace(phrasesInput))
            {
                MessageBox.Show("Please enter one or more phrases separated by '/'.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Split input into multiple phrases
            var phrases = phrasesInput.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(p => p.Trim()) // Remove extra spaces
                                      .ToArray();

            if (phrases.Length == 0)
            {
                MessageBox.Show("No valid phrases found. Please check your input.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Initialize ViewModel if it's null
            if (_viewModel == null)
            {
                _viewModel = new TeacherViewModel();
            }

            _viewModel.Phrases = phrases.ToList(); // Store phrases in ViewModel
            _viewModel.SetCurrentPhraseIndex(0); // Start with the first phrase
            _viewModel.CorrectPhrase = phrases[0]; // First phrase is the correct one

            // Shuffle words for the first phrase
            var words = phrases[0].Split(' ');
            _viewModel.DisorderedWords = words.OrderBy(x => Guid.NewGuid()).ToArray();

            // Open Student View with the ViewModel
            var studentView = new StudentPhraseExerciseView(_viewModel);
            studentView.Show();
            Close();
        }

        // Method to read file with UTF-8 encoding
        public static string LoadPhraseData()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Views", "Resources", "Data", "Exercices.txt");

            try
            {
                if (File.Exists(filePath))
                {
                    // Ensure UTF-8 encoding
                    return File.ReadAllText(filePath, Encoding.UTF8);
                }
                else
                {
                    return "⚠️ Fichier introuvable !";
                }
            }
            catch (Exception ex)
            {
                return $"⚠️ Erreur de lecture du fichier : {ex.Message}";
            }
        }
    }
}
