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
            SyllableExercisePreparationView syllableView = new SyllableExercisePreparationView();
            syllableView.Show();
        }

        // Opens the Disordered Phrase Exercise View for teacher to prepare phrase exercise
        private void DisorderedPhraseExercise_Click(object sender, RoutedEventArgs e)
        {
            PhraseExercisePreparationView phraseView = new PhraseExercisePreparationView();
            phraseView.Show();
        }
    }
}
