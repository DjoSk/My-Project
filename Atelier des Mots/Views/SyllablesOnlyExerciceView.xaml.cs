using Atelier_des_Mots.ViewModels;
using System.Linq;
using System.Windows;

namespace Atelier_des_Mots.Views
{
    public partial class SyllablesOnlyExercisePreparationView : Window
    {
        private TeacherViewModel _viewModel;

        public SyllablesOnlyExercisePreparationView()
        {
            InitializeComponent();
            _viewModel = new TeacherViewModel();
            DataContext = _viewModel;
        }

        // Update the syllables preview as the teacher types
        private void SyllablesInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string syllablesInput = SyllablesInput.Text;

            // Validate the input (allow only letters and hyphens)
            if (System.Text.RegularExpressions.Regex.IsMatch(syllablesInput, @"[^a-zA-Z\-]"))
            {
                MessageBox.Show("Please enter only letters and hyphens (-).", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                SyllablesInput.Text = ""; // Clear invalid input
                return;
            }

            // Update the preview with the entered syllables
            string[] syllablesArray = syllablesInput.Split('-');
            SyllablesPreview.Text = string.Join(" | ", syllablesArray);
        }

        // Prepare the syllables exercise and display to students
        // Prepare the syllables exercise and display to students
        private void DisplayToStudents_Click(object sender, RoutedEventArgs e)
        {
            string syllablesInput = SyllablesInput.Text;

            // Ensure valid input before proceeding
            if (string.IsNullOrWhiteSpace(syllablesInput))
            {
                MessageBox.Show("Please enter syllables separated by hyphens (-) before displaying.", "Empty Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Split syllables and store in the ViewModel as a List<string>
            _viewModel.DisplaySyllables = syllablesInput.Split('-').ToList();

            // Show the student view
            StudentSyllablesOnlyExerciseView studentView = new StudentSyllablesOnlyExerciseView(_viewModel);
            studentView.Show();
        }

    }
}
