using Atelier_des_Mots.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Atelier_des_Mots.Views
{
    public partial class SyllableExercisePreparationView : Window
    {
        private TeacherViewModel _viewModel;
        private string SyllableExerciseData = "";

        public SyllableExercisePreparationView()
        {
            InitializeComponent();
            _viewModel = new TeacherViewModel();
            DataContext = _viewModel;

            LoadSyllableExerciseData();
        }

        private void LoadSyllableExerciseData()
        {
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Atelier Des Mots");
            string filePath = Path.Combine(appDataPath, "Exercices.txt");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                bool isSyllableExerciseSection = false;
                List<string> syllableLines = new List<string>();

                foreach (string line in lines)
                {
                    string trimmedLine = line.Trim();

                    if (trimmedLine.StartsWith("# Phrase Exercise") ||
                        trimmedLine.StartsWith("# Syllables Only Exercise"))
                    {
                        isSyllableExerciseSection = false;
                    }

                    if (isSyllableExerciseSection && !string.IsNullOrWhiteSpace(trimmedLine))
                    {
                        syllableLines.Add(trimmedLine);
                    }

                    if (trimmedLine.StartsWith("# Syllable Exercise"))
                    {
                        isSyllableExerciseSection = true;
                    }
                }

                SyllableExerciseData = syllableLines.Count > 0 ? string.Join(" ", syllableLines) : "No syllable exercise found.";
                SyllableInput.Text = SyllableExerciseData;
            }
        }

        private void SyllableInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            string syllables = SyllableInput.Text;
            var words = syllables.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var wordsWithoutHyphens = words.Select(word => word.Replace("-", "")).ToArray();
            WordOutput.Text = string.Join(" ", wordsWithoutHyphens);
        }

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

        private void DisplayToStudents_Click(object sender, RoutedEventArgs e)
        {
            string syllables = SyllableInput.Text;

            if (string.IsNullOrWhiteSpace(syllables))
            {
                MessageBox.Show("Please enter words in syllables before displaying to students.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var words = syllables.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var syllablesList = words.SelectMany(word => word.Split('-')).ToArray();
            var shuffledSyllables = ShuffleSyllables(syllablesList);

            _viewModel.Words = words;
            _viewModel.SetCurrentWord(0);
            _viewModel.CorrectWord = string.Join(" ", words.Select(word => word.Replace("-", "")));

            StudentSyllableExerciseView studentView = new StudentSyllableExerciseView(_viewModel);
            studentView.Show();

            SyllableInput.Clear();
        }
    }
}