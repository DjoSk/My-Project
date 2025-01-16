using Atelier_des_Mots.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Atelier_des_Mots.Views
{
    public partial class StudentExerciseView : Window
    {
        private TeacherViewModel _viewModel;
        private MediaPlayer _player;
        private Random _random;
        private Border _currentVisibleBorder;
        private int _currentWordIndex = 0; // Tracks the current word being displayed
        private string[] _words; // Stores all input words

        public StudentExerciseView(TeacherViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;

            // Initialize MediaPlayer for sound playback
            _player = new MediaPlayer();
            _random = new Random();

            // Initialize current visible syllable border as null
            _currentVisibleBorder = null;

            // Determine the type of exercise and update the UI
            if (_viewModel.DisorderedWords != null && _viewModel.DisorderedWords.Length > 0)
            {
                SetupPhraseExercise();
            }
            else if (_viewModel.DisplaySyllables != null && _viewModel.DisplaySyllables.Length > 0)
            {
                if (_viewModel.CorrectWord == null) // Syllables only exercise
                {
                    SetupSyllablesOnlyExercise();
                }
                else // Syllables + Word Exercise
                {
                    SetupSyllableExercise();
                }
            }

            // Register the keydown event to listen for spacebar press
            this.KeyDown += new KeyEventHandler(Window_KeyDown);
        }

        // Method to display syllables dynamically, each word on a separate line
        public void DisplaySyllables(string[] words)
        {
            // Clear existing content
            SyllableContainer.Children.Clear();

            foreach (var word in words)
            {
                // Split the word into syllables by space or hyphen
                string[] syllables = word.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

                // Create a WrapPanel for this word to hold the syllables side by side
                StackPanel wordPanel = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Center, // Stack the words vertically
                    Orientation = Orientation.Horizontal, // Ensure syllables appear horizontally inside each word
                    Margin = new Thickness(0, 5, 0, 5)  // Add some margin for spacing between words
                };

                foreach (var syllable in syllables)
                {
                    // Create a new TextBlock for each syllable, enclosed in square brackets
                    TextBlock syllableTextBlock = new TextBlock
                    {
                        Text = $"{syllable}",
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(5)  // Spacing between syllables
                    };

                    // Add the TextBlock to the word panel
                    wordPanel.Children.Add(syllableTextBlock);
                }

                // Add the word panel to the main container
                SyllableContainer.Children.Add(wordPanel);
            }
        }

        // Example usage: Call this method to display syllables on button click or other event
        private void OnSyllablesExerciseStart()
        {
            // Example words to display syllables
            string[] words = { "bonjour", "bonsoir" };

            // Call the method to display syllables
            DisplaySyllables(words);
        }

        // Play sound method
        private void PlaySound()
        {
            // Ensure the sound file path is correct
            _player.Open(new Uri("D:/Project1/Atelier des Mots/Views/Resources/Sounds/Music.mp3"));
            _player.Play();
        }

        // Setup Syllables Only Exercise
        private void SetupSyllablesOnlyExercise()
        {
            SyllablesOnlyExercisePanel.Visibility = Visibility.Visible;
            SyllableExercisePanel.Visibility = Visibility.Collapsed;
            PhraseExercisePanel.Visibility = Visibility.Collapsed;

            // Populate syllables in boxes with images
            SyllablesOnlyContainer.Children.Clear();
            foreach (var syllable in _viewModel.DisplaySyllables)
            {
                var card = CreateSyllableBox(syllable); // Pass syllable to display
                SyllablesOnlyContainer.Children.Add(card);
            }
        }

        // Setup Syllable Exercise
        private void SetupSyllableExercise()
        {
            SyllableExercisePanel.Visibility = Visibility.Visible;
            SyllablesOnlyExercisePanel.Visibility = Visibility.Collapsed;
            PhraseExercisePanel.Visibility = Visibility.Collapsed;

            // Populate syllables directly (no hidden state)
            SyllableContainer.Children.Clear();
            foreach (var syllable in _viewModel.DisplaySyllables)
            {
                var card = CreateVisibleSyllableCard(syllable); // New method to show syllables directly
                SyllableContainer.Children.Add(card);
            }
        }

        // Create a visible syllable card for syllable exercise (display immediately)
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
                Text = syllable, // Display the syllable directly
                FontSize = 70,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            border.Child = textBlock;

            return border;
        }

        // Setup Phrase Exercise
        private void SetupPhraseExercise()
        {
            PhraseExercisePanel.Visibility = Visibility.Visible;
            SyllableExercisePanel.Visibility = Visibility.Collapsed;
            SyllablesOnlyExercisePanel.Visibility = Visibility.Collapsed;

            // Populate disordered words
            PhraseContainer.Children.Clear();
            foreach (var word in _viewModel.DisorderedWords)
            {
                var card = CreateWordCard(word);
                PhraseContainer.Children.Add(card);
            }
        }

        // Create a syllable box for syllables only exercise
        private Border CreateSyllableBox(string syllable)
        {
            var border = new Border
            {
                Background = Brushes.LightCoral,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),
                Width = 240,  // Increased width
                Height = 180, // Increased height
                Margin = new Thickness(10), // Increased spacing
                Tag = syllable
            };

            var image = new Image
            {
                Source = new BitmapImage(new Uri("D:/Project1/Atelier des Mots/Views/Resources/Images/cards.jpg")),
                Stretch = Stretch.Fill,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            border.Child = image;

            border.MouseDown += (s, e) =>
            {
                var b = s as Border;
                var syllableText = b.Tag.ToString();
                b.Child = new TextBlock
                {
                    Text = syllableText,
                    FontSize = 100,
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                // Play the sound when a syllable is clicked
                PlaySound();
            };

            return border;
        }

        // Create a hidden syllable card for syllable exercise
        private Border CreateHiddenSyllableCard(string syllable)
        {
            var border = new Border
            {
                Background = Brushes.LightGray,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),
                Width = 200,
                Height = 150,
                Margin = new Thickness(5),
                Tag = syllable
            };

            var textBlock = new TextBlock
            {
                Text = "", // Removed the "?" symbol and left it empty initially
                FontSize = 70,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            border.Child = textBlock;
            border.MouseDown += (s, e) =>
            {
                var b = s as Border;
                var tb = b.Child as TextBlock;

                // Reveal syllable and update selected syllable display
                tb.Text = b.Tag.ToString();

                // Highlight the selected syllable
                foreach (var child in SyllableContainer.Children)
                {
                    if (child is Border childBorder)
                    {
                        childBorder.Background = Brushes.LightGray; // Reset background for other syllables
                    }
                }
                b.Background = Brushes.LightGreen; // Highlight selected syllable

                // Play the sound when a syllable is revealed
                PlaySound();
            };

            return border;
        }

        // Create a word card for phrase exercise
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
                    FontSize = 45,
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            };
        }

        // Show random syllable and flip back the previous one
        private async void ShowRandomSyllable()
        {
            // If there is a currently displayed syllable, flip it back to the image
            if (_currentVisibleBorder != null && _currentVisibleBorder.Child is TextBlock)
            {
                // Create the back image
                var backImage = new Image
                {
                    Source = new BitmapImage(new Uri("D:/Project1/Atelier des Mots/Views/Resources/Images/cards.jpg")),
                    Stretch = Stretch.Fill,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                // Apply fade-out animation to the current text
                var fadeOutAnimation = new DoubleAnimation
                {
                    From = 1,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(1) // Fade-out duration
                };

                var textBlock = _currentVisibleBorder.Child as TextBlock;
                textBlock.BeginAnimation(TextBlock.OpacityProperty, fadeOutAnimation);

                // Wait for the fade-out animation to complete
                await Task.Delay(700);

                // Replace the text with the back image
                _currentVisibleBorder.Child = backImage;
                _currentVisibleBorder = null;
            }

            // Get a random index for the syllable
            int index = _random.Next(_viewModel.DisplaySyllables.Length);
            string randomSyllable = _viewModel.DisplaySyllables[index];

            // Find the Border corresponding to the random syllable
            foreach (var child in SyllablesOnlyContainer.Children)
            {
                if (child is Border border && border.Tag.ToString() == randomSyllable)
                {
                    // Check if the card is already revealed; if so, skip it
                    if (border.Child is TextBlock)
                        return;

                    // Flip it to show the syllable with fade-in animation
                    var textBlock = new TextBlock
                    {
                        Text = randomSyllable,
                        FontSize = 90,
                        FontWeight = FontWeights.Bold,
                        Opacity = 0, // Start hidden
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    border.Child = textBlock; // Set the syllable text
                    _currentVisibleBorder = border; // Track the current card

                    // Play the sound
                    PlaySound();

                    // Apply fade-in animation
                    var fadeInAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(3) // Fade-in duration
                    };
                    textBlock.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);

                    // Exit the loop after revealing the syllable
                    break;
                }
            }
        }

        // Key press event to reveal random syllable
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && _viewModel.DisplaySyllables != null && _viewModel.DisplaySyllables.Length > 0)
            {
                ShowRandomSyllable();
            }
        }

        // Assemble syllables into a word
        private void AssembleSyllable_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.DisplaySyllables != null && _viewModel.DisplaySyllables.Length > 0)
            {
                // Join the syllables into a word
                SyllableAssembledWordText.Text = _viewModel.AssembledWord;

                // Play the sound when syllables are assembled
                PlaySound();
            }
        }

        // Show the correct phrase for phrase exercise
        private void ShowCorrectPhrase_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_viewModel.CorrectPhrase))
            {
                PhraseAssembledText.Text = _viewModel.CorrectPhrase;

                // Play the sound when correct phrase is shown
                PlaySound();
            }
        }


    }
}
