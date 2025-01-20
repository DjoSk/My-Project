using Atelier_des_Mots.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Atelier_des_Mots.Views
{
    public partial class StudentPhraseExerciseView : Window
    {
        private TeacherViewModel _viewModel;
        private MediaPlayer _player;

        public StudentPhraseExerciseView(TeacherViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;

            // Initialize MediaPlayer for background music
            _player = new MediaPlayer();

            // Setup the words to be displayed
            SetupPhraseExercise();
            string imagePath = "D:/Project1/Atelier des Mots/Views/Resources/Images/Kid2.jpg"; // Adjust as needed
            ImageBrush backgroundBrush = new ImageBrush();
            backgroundBrush.ImageSource = new BitmapImage(new Uri(imagePath));
            this.Background = backgroundBrush;
        }
      
        


        private void PlayBackgroundMusic()
        {
            try
            {
                _player.Open(new Uri("D:/Project1/Atelier des Mots/Views/Resources/Sounds/Music.mp3"));
                _player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing background music: {ex.Message}");
            }
        }

        private void SetupPhraseExercise()
        {
            PhraseContainer.Children.Clear(); // Clear any existing children
            foreach (var word in _viewModel.DisorderedWords)
            {
                var card = CreateWordCard(word);
                PhraseContainer.Children.Add(card);
            }
        }

        private Border CreateWordCard(string word)
        {
            return new Border
            {
                Background = Brushes.LightGray,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),
                Width = 240,
                Height = 150,
                Margin = new Thickness(5),
                Child = new TextBlock
                {
                    Text = word,
                    FontSize = 50,
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            };
        }

        private void ShowCorrectPhrase_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_viewModel.CorrectPhrase))
            {
                // Display the correct phrase
                PhraseAssembledText.Text = _viewModel.CorrectPhrase;

                // Play background music when the "Show Correct Phrase" button is clicked
                PlayBackgroundMusic();

                // Optionally, you can also play a click sound
                PlayClickSound();
            }
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Set the background image programmatically
            string imagePath = "D:/Project1/Atelier des Mots/Views/Resources/Images/Kid2.jpg";
            ImageBrush backgroundBrush = new ImageBrush();
            backgroundBrush.ImageSource = new BitmapImage(new Uri(imagePath));
            this.Background = backgroundBrush;
        }

    }
}
