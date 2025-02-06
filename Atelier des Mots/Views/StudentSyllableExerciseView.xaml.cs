using Atelier_des_Mots.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
                _player.Open(new Uri("Views/Resources/Sounds/Bingo.mp3", UriKind.Relative));
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
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),
                Width = 290,
                Height = 150,
                Margin = new Thickness(5),
                Tag = syllable
            };

            // Set the background image using ImageBrush
            string imagePath = "pack://siteoforigin:,,,/Views/Resources/Images/Box2.jpg";
            ImageBrush imageBrush = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Absolute)),
                Stretch = Stretch.Fill
            };

            border.Background = imageBrush;



            border.Background = imageBrush;

            var textBlock = new TextBlock
            {
                Text = syllable,
                FontSize = 95,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Rockwell"), // Change the font family here

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
                _player.Open(new Uri("Views/Resources/Sounds/Bingo.mp3", UriKind.Relative));
                _player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing background music: {ex.Message}");
            }
        }

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

            // Display the correct word in the yellow block
            SyllableAssembledWordText.Text = _viewModel.AssembledWord;

            // Show the yellow block
            SyllableWordAssemblyDisplay.Visibility = Visibility.Visible;

            // Play the background music once
            PlayBackgroundMusic();

            // Scroll to the bottom of the outer ScrollViewer
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (OuterScrollViewer != null)
                {
                    OuterScrollViewer.ScrollToBottom();
                }
            }), System.Windows.Threading.DispatcherPriority.Background);
        }

        private void NextWord_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SetNextWord();
            SetupSyllableExercise(); // Update the UI to show the next word's syllables

            // Hide the yellow block
            SyllableWordAssemblyDisplay.Visibility = Visibility.Collapsed;

            // Scroll to the bottom of the ScrollViewer
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (OuterScrollViewer != null)
                {
                    OuterScrollViewer.ScrollToBottom();
                }
            }), System.Windows.Threading.DispatcherPriority.Background);
        }


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
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window
        }



    }
}
