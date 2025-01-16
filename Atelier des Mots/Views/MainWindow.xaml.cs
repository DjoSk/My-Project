using System.Windows;
using Atelier_des_Mots.Views;

namespace Atelier_des_Mots.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Opens the Syllable Exercise View for teacher to prepare syllables exercise
        private void SyllablesExercise_Click(object sender, RoutedEventArgs e)
        {
            SyllableExercisePreparationView syllablePreparationView = new SyllableExercisePreparationView();
            syllablePreparationView.Show();
        }

        // Opens the Disordered Phrase Exercise View for teacher to prepare phrase exercise
        private void DisorderedPhraseExercise_Click(object sender, RoutedEventArgs e)
        {
            PhraseExercisePreparationView phraseView = new PhraseExercisePreparationView();
            phraseView.Show();
        }

        // Opens the Syllables Only Exercise View for teacher to prepare syllables only exercise
        private void SyllablesOnlyExercise_Click(object sender, RoutedEventArgs e)
        {
            SyllablesOnlyExercisePreparationView syllablesOnlyView = new SyllablesOnlyExercisePreparationView();
            syllablesOnlyView.Show();
        }
    }
}
