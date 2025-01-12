using Atelier_des_Mots.ViewModels;
using System.Windows;

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
        private void SyllableInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string syllables = SyllableInput.Text;

            // Remove hyphens to display the word without them
            string wordWithoutHyphens = syllables.Replace("-", "");

            // Set the WordOutput TextBox to show the word without hyphens
            WordOutput.Text = wordWithoutHyphens;
        }

        // Prepare the syllables exercise and display to students
        private void DisplayToStudents_Click(object sender, RoutedEventArgs e)
        {
            string syllables = SyllableInput.Text;

            // Store the word and syllables in the ViewModel
            _viewModel.CorrectWord = syllables.Replace("-", ""); // Word without hyphens
            _viewModel.DisplaySyllables = syllables.Split('-'); // Syllables are split by hyphens

            // Show student view, passing the ViewModel
            StudentExerciseView studentView = new StudentExerciseView(_viewModel);
            studentView.Show();
        }
    }
}
