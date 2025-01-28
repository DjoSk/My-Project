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
            string imagePath = "pack://siteoforigin:,,,/Views/Resources/Images/Kid2.jpg";
            ImageBrush imageBrush = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Absolute)),
                Stretch = Stretch.UniformToFill
            };
            this.Background = imageBrush;
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
            PhraseContainer.Children.Clear(); // Clear existing UI elements

            foreach (var word in _viewModel.DisorderedWords)
            {
                var card = CreateWordCard(word); // Create a card for each word
                PhraseContainer.Children.Add(card); // Add it to the container
            }
        }




        private Border CreateWordCard(string word)
        {
            string imagePath = "pack://siteoforigin:,,,/Views/Resources/Images/Box1.jpg";
            ImageBrush imageBrush = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Absolute)),
                Stretch = Stretch.Fill
            };

            return new Border
            {
                Background = imageBrush,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),
                Width = 340,
                Height = 160,
                Margin = new Thickness(5),
                Child = new TextBlock
                {
                    Text = word,
                    FontSize = 65,
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontFamily = new FontFamily("Rockwell"),
                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = Brushes.Black,
                    TextWrapping = TextWrapping.Wrap
                }
            };
        }




      private void ShowCorrectPhrase_Click(object sender, RoutedEventArgs e)
{
    try
    {
        if (!string.IsNullOrEmpty(_viewModel.CorrectPhrase))
        {
            // Display the correct phrase for the current phrase
            PhraseAssembledText.Text = _viewModel.CorrectPhrase;
            PhraseAssemblyDisplay.Visibility = Visibility.Visible; // Show the yellow block with the correct phrase

            // Play background music or sound (optional)
            PlayBackgroundMusic();

            // Hide the disordered words temporarily
            PhraseContainer.Visibility = Visibility.Collapsed;

            // Scroll to the bottom of the ScrollViewer
            ScrollViewer parentScrollViewer = GetParentScrollViewer(PhraseExercisePanel);
            if (parentScrollViewer != null)
            {
                parentScrollViewer.ScrollToBottom();
            }
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
}

// Helper method to find the parent ScrollViewer
private ScrollViewer GetParentScrollViewer(DependencyObject element)
{
    while (element != null)
    {
        if (element is ScrollViewer scrollViewer)
        {
            return scrollViewer;
        }
        element = VisualTreeHelper.GetParent(element);
    }
    return null;
}

        private void NextPhrase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_viewModel.HasNextPhrase())
                {
                    _viewModel.SetNextPhrase(); // Update to the next phrase
                    SetupPhraseExercise(); // Update the UI with new disordered words
                    PhraseAssemblyDisplay.Visibility = Visibility.Collapsed; // Hide the correct phrase
                    PhraseContainer.Visibility = Visibility.Visible; // Show the disordered words
                }
                else
                {
                    MessageBox.Show("All phrases completed!", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }







        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Set the background image programmatically
            string imagePath = "pack://siteoforigin:,,,/Views/Resources/Images/Principal.jpg";
            ImageBrush imageBrush = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Absolute)),
                Stretch = Stretch.UniformToFill
            };
            this.Background = imageBrush;
        }

    }
}
