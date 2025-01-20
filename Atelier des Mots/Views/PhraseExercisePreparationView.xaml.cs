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
            string correctPhrase = CorrectPhraseInput.Text;
            string disorderedPhrase = DisorderedPhraseOutput.Text;

            // Store the correct and disordered phrases in the ViewModel
            _viewModel.CorrectPhrase = correctPhrase;
            _viewModel.DisorderedWords = disorderedPhrase.Split(' ');

            // Show student view
            StudentPhraseExerciseView studentView = new StudentPhraseExerciseView(_viewModel);
            studentView.Show();
        }
    }
}
