using Atelier_des_Mots.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Atelier_des_Mots.Views
{
    public partial class StudentSyllableExerciseView : Window
    {
        private TeacherViewModel _viewModel;
        private MediaPlayer _player;
        private Random _random;
        private Border _currentVisibleBorder;

        public StudentSyllableExerciseView(TeacherViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _player = new MediaPlayer();

            SetupSyllableExercise();
        }

        private void PlayBackgroundMusic()
        {
            try
            {
                // Open the music file
                _player.Open(new Uri("D:/Project1/Atelier des Mots/Views/Resources/Sounds/Music.mp3"));

                // Play the music once without looping
                _player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing background music: {ex.Message}");
            }
        }


        private void SetupSyllableExercise()
        {
            // Shuffle the syllables before displaying
            ShuffleSyllables();

            // Clear the previous syllable container to remove old syllables
            SyllableContainer.Children.Clear();

            // Add the syllables of the current word
            foreach (var syllable in _viewModel.DisplaySyllables1)
            {
                var card = CreateVisibleSyllableCard(syllable);
                SyllableContainer.Children.Add(card);
            }

            // Clear the assembled word text when starting a new word
            SyllableAssembledWordText.Text = string.Empty;

            // Ensure the current word is set correctly
            _viewModel.SetCurrentWord(_viewModel.CurrentWordIndex);
        }


        private void ShuffleSyllables()
        {
            _random = new Random();
            _viewModel.DisplaySyllables1 = _viewModel.DisplaySyllables1.OrderBy(x => _random.Next()).ToList();
        }

        private Border CreateVisibleSyllableCard(string syllable)
        {
            var border = new Border
            {
                Background = Brushes.LightGray,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),
                Width = 220,
                Height = 160,
                Margin = new Thickness(5),
                Tag = syllable
            };

            var textBlock = new TextBlock
            {
                Text = syllable,
                FontSize = 70,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            border.Child = textBlock;
            border.MouseDown += (s, e) => PlayClickSound();
            return border;
        }

        private void PlayClickSound()
        {
            try
            {
                var clickPlayer = new MediaPlayer();
                clickPlayer.Open(new Uri("D:/Project1/Atelier des Mots/Views/Resources/Sounds/Music.mp3"));
                clickPlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing click sound: {ex.Message}");
            }
        }

        // Assemble syllables into a word
        // Assemble syllables into a word
        private void AssembleSyllable_Click(object sender, RoutedEventArgs e)
        {
            // Ensure the CorrectWord is properly set for the current word
            if (string.IsNullOrEmpty(_viewModel.CorrectWord))
            {
                MessageBox.Show("No word selected. Please go to the next word.");
                return;
            }

            // Use the correct word for the current word (the syllables for the current word)
            _viewModel.AssembledWord = _viewModel.CorrectWord;

            // Display the correct word in the yellow box (only the current word)
            SyllableAssembledWordText.Text = _viewModel.AssembledWord;

            // Play the background music once
            PlayBackgroundMusic();
        }



        private void NextWord_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SetNextWord();
            SetupSyllableExercise(); // Update the UI to show the next word's syllables
        }
    }
}
