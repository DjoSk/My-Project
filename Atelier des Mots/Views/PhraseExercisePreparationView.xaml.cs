using Atelier_des_Mots.ViewModels;
using System;
using System.Linq;
using System.Windows;

namespace Atelier_des_Mots.Views
{
    public partial class PhraseExercisePreparationView : Window
    {
        private TeacherViewModel _viewModel;

        public PhraseExercisePreparationView()
        {
            InitializeComponent();
            _viewModel = new TeacherViewModel();
            DataContext = _viewModel;
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
        private void DisplayToStudents_Click(object sender, RoutedEventArgs e)
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

            // Shuffle words within each phrase and store data in the ViewModel
            
            _viewModel.Phrases = phrases.ToList(); // Convert string[] to List<string>
            _viewModel.SetCurrentPhraseIndex(0); // Start with the first phrase
            _viewModel.CorrectPhrase = phrases[0]; // First phrase is the current one

            // Disordered words for the first phrase
            var words = phrases[0].Split(' ');
            _viewModel.DisorderedWords = words.OrderBy(x => Guid.NewGuid()).ToArray();

            // Show student view
            var studentView = new StudentPhraseExerciseView(_viewModel);
            studentView.Show();

            // Optionally clear input
            CorrectPhraseInput.Clear();
        }

    }
}
