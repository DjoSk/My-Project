using Atelier_des_Mots.ViewModels;
using System.IO;
using System.Linq;
using System.Windows;
using System;
using System.Text;

namespace Atelier_des_Mots.Views
{
    public partial class SyllablesOnlyExercisePreparationView : Window
    {
        private TeacherViewModel _viewModel;
        private const string FilePath = "Views/Resources/Data/Exercices.txt"; // Path to your exercises file

        public SyllablesOnlyExercisePreparationView()
        {
            InitializeComponent();
            _viewModel = new TeacherViewModel();
            DataContext = _viewModel;

            LoadSyllablesFromFile();
        }


        // Load syllables from the file upon opening
        private void LoadSyllablesFromFile()
        {
            // Use absolute path for file location
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Views/Resources/Data/Exercices.txt");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

                bool isSyllablesOnlyExerciseSection = false;
                string syllablesData = "";

                foreach (string line in lines)
                {
                    string trimmedLine = line.Trim();

                    // Look for the section starting with "# Syllables Only Exercise"
                    if (trimmedLine.StartsWith("# Syllables Only Exercise"))
                    {
                        isSyllablesOnlyExerciseSection = true;
                        continue; // Skip the header line
                    }

                    // Once inside the section, gather syllable data
                    if (isSyllablesOnlyExerciseSection)
                    {
                        if (string.IsNullOrWhiteSpace(trimmedLine)) // Stop if an empty line is found (end of section)
                        {
                            break;
                        }
                        syllablesData += trimmedLine + " "; // Accumulate syllables data
                    }
                }

                // Check if syllables data was collected
                if (!string.IsNullOrEmpty(syllablesData))
                {
                    syllablesData = syllablesData.Trim(); // Remove any trailing spaces
                    SyllablesInput.Text = syllablesData;

                    // Update the syllables preview
                    string[] syllablesArray = syllablesData.Split('-');
                    SyllablesPreview.Text = string.Join(" | ", syllablesArray);
                }
                else
                {
                    // Debugging message to show what was captured
                    MessageBox.Show($"No syllables data found in the file for the 'Syllables Only Exercise' section. Captured content: {syllablesData}", "Data Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("The file does not exist at the specified location.", "File Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        // Update the syllables preview as the teacher types
        private void SyllablesInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string syllablesInput = SyllablesInput.Text;

            // Validate the input (allow only letters and hyphens, including accented characters)
            if (System.Text.RegularExpressions.Regex.IsMatch(syllablesInput, @"[^-\p{L}]"))
            {
                MessageBox.Show("Please enter only letters (including accented characters) and hyphens (-).", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                SyllablesInput.Text = ""; // Clear invalid input
                return;
            }

            // Update the preview with the entered syllables
            string[] syllablesArray = syllablesInput.Split('-');
            SyllablesPreview.Text = string.Join(" | ", syllablesArray);
        }


        // Prepare the syllables exercise and display to students
        public void DisplayToStudents_Click(object sender, RoutedEventArgs e)
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
            Close();
        }
    }
}
