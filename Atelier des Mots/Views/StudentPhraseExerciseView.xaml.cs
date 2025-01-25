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
            string imagePath = "pack://application:,,,/Atelier des Mots;component/Views/Resources/Images/Kid2.jpg"; // Adjust as needed
            ImageBrush backgroundBrush = new ImageBrush();
            backgroundBrush.ImageSource = new BitmapImage(new Uri(imagePath));
            this.Background = backgroundBrush;
        }



        private void PlayBackgroundMusic()
        {
            try
            {
                _player.Open(new Uri("Views/Resources/Sounds/Bingo.mp3", UriKind.Relative));
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
            // Define the image source for the background
            var imageBrush = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("pack://application:,,,/Atelier des Mots;component/Views/Resources/Images/Box1.jpg")),
                Stretch = Stretch.Fill // Ensures the image fully covers the box
            };

            // Create the main border
            return new Border
            {
                Background = imageBrush, // Set the image as the background
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),
                Width = 340, // Set the width of the box
                Height = 160, // Set the height of the box
                Margin = new Thickness(5),
                Child = new TextBlock
                {
                    Text = word,
                    FontSize = 65,
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontFamily = new FontFamily("Rockwell "), // Change the font family here

                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = Brushes.Black, // Ensure text is readable on the image
                    TextWrapping = TextWrapping.Wrap
                }
            };
        }



        private void ShowCorrectPhrase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if the correct phrase is available
                if (!string.IsNullOrEmpty(_viewModel.CorrectPhrase))
                {
                    // Display the correct phrase
                    PhraseAssembledText.Text = _viewModel.CorrectPhrase;

                    // Make the yellow block visible
                    PhraseAssemblyDisplay.Visibility = Visibility.Visible;

                    // Display the Bravo panel with image and message
                    BravoPanel.Visibility = Visibility.Visible;

                    // Optionally, play a sound or animation
                    PlayBackgroundMusic();
                }
                else
                {
                    MessageBox.Show("The correct phrase is not available.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            PlayBackgroundMusic() ;
        }




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Set the background image programmatically
            string imagePath = "pack://application:,,,/Atelier des Mots;component/Views/Resources/Images/Kid2.jpg";
            ImageBrush backgroundBrush = new ImageBrush();
            backgroundBrush.ImageSource = new BitmapImage(new Uri(imagePath));
            this.Background = backgroundBrush;
        }

    }
}
