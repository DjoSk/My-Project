using Atelier_des_Mots.ViewModels;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Atelier_des_Mots.Views
{
    public partial class StudentExerciseView : Window
    {
        private TeacherViewModel _viewModel;

        public StudentExerciseView(TeacherViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;

            DisplaySyllables();
        }

        // Display syllables as flipping cards
        private void DisplaySyllables()
        {
            SyllableContainer.Children.Clear();

            foreach (var syllable in _viewModel.DisplaySyllables)
            {
                // Create a border to represent the card
                var border = new Border
                {
                    Background = Brushes.LightGray, // Face-down color
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(2),
                    Width = 80,
                    Height = 80,
                    Margin = new Thickness(5),
                    Tag = syllable // Store the syllable in the Tag
                };

                var textBlock = new TextBlock
                {
                    Text = "?", // Initially show question mark
                    FontSize = 16,
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                border.Child = textBlock;

                // Add click event for flipping the card
                border.MouseLeftButtonUp += (s, e) => FlipCard(border);

                SyllableContainer.Children.Add(border);
            }
        }

        // Flip a card face-up
        private void FlipCard(Border card)
        {
            if (card.Background != Brushes.LightGray) return; // Already flipped

            var syllable = card.Tag.ToString();
            var textBlock = (TextBlock)card.Child;

            // Reveal the syllable
            textBlock.Text = syllable;

            // Change card background to a light blue shade
            card.Background = new SolidColorBrush(Color.FromRgb(173, 216, 230));

            // Display the syllable in the larger selected area
            SelectedSyllableText.Text = syllable;

            // Play tonality for flipping syllables
            System.Media.SystemSounds.Asterisk.Play();
        }

        // Assemble the word and flip all remaining cards
        private void AssembleWord_Click(object sender, RoutedEventArgs e)
        {
            string assembledWord = string.Join("", _viewModel.DisplaySyllables);

            foreach (Border card in SyllableContainer.Children)
            {
                if (card.Background == Brushes.LightGray)
                {
                    // Flip all unflipped cards
                    var syllable = card.Tag.ToString();
                    var textBlock = (TextBlock)card.Child;

                    textBlock.Text = syllable;
                    card.Background = new SolidColorBrush(Color.FromRgb(173, 216, 230));
                }
            }

            // Display the assembled word
            AssembledWordText.Text = assembledWord;

            // Play tonality for assembling the word
            System.Media.SystemSounds.Beep.Play();
        }
    }
}
