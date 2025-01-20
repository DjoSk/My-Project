using Atelier_des_Mots.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Atelier_des_Mots.Views
{
    public partial class SyllableExercisePreparationView : Window
    {
        private TeacherViewModel _viewModel;

        public SyllableExercisePreparationView()
        {
            InitializeComponent();
            _viewModel = new TeacherViewModel();
            DataContext = _viewModel;


        }

        // Update the WordOutput text box as the teacher types
        private void SyllableInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            string syllables = SyllableInput.Text;

            // Process each word separated by space
            var words = syllables.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // For each word, remove the hyphens
            var wordsWithoutHyphens = words.Select(word => word.Replace("-", "")).ToArray();

            // Set the WordOutput TextBox to show the words without hyphens
            WordOutput.Text = string.Join(" ", wordsWithoutHyphens);
        }

        // Method to shuffle the syllables of a word
        private string[] ShuffleSyllables(string[] syllables)
        {
            Random rng = new Random();
            int n = syllables.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = syllables[k];
                syllables[k] = syllables[n];
                syllables[n] = value;
            }
            return syllables;
        }


        // Prepare the syllables exercise and display to students
        private void DisplayToStudents_Click(object sender, RoutedEventArgs e)
        {
            string syllables = SyllableInput.Text;

            if (string.IsNullOrWhiteSpace(syllables))
            {
                MessageBox.Show("Please enter words in syllables before displaying to students.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Process each word separated by space
            var words = syllables.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Flatten syllables and shuffle them
            var syllablesList = words.SelectMany(word => word.Split('-')).ToArray();
            var shuffledSyllables = ShuffleSyllables(syllablesList);

            // Update ViewModel with correct words and shuffled syllables
            _viewModel.Words = words; // Store all words
            _viewModel.SetCurrentWord(0); // Start with the first word
            _viewModel.CorrectWord = string.Join(" ", words.Select(word => word.Replace("-", ""))); // Words without hyphens

            // Show the student view and pass the ViewModel
            StudentSyllableExerciseView studentView = new StudentSyllableExerciseView(_viewModel);
            studentView.Show();

            // Optionally clear input after displaying
            SyllableInput.Clear();
        }





    }
}
