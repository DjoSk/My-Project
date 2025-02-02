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
    public partial class StudentSyllablesOnlyExerciseView : Window
    {
        private TeacherViewModel _viewModel;
        private MediaPlayer _player;
        private Random _random;
        private Border _currentVisibleBorder;

        public StudentSyllablesOnlyExerciseView(TeacherViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;

            _player = new MediaPlayer();
            _random = new Random();
            _currentVisibleBorder = null;

            SetupSyllablesOnlyExercise();
            this.KeyDown += new KeyEventHandler(Window_KeyDown);
        }

        private void SetupSyllablesOnlyExercise()
        {
            SyllablesOnlyContainer.Children.Clear();
            foreach (var syllable in _viewModel.DisplaySyllables)
            {
                var card = CreateSyllableBox(syllable);
                SyllablesOnlyContainer.Children.Add(card);
            }
        }

        private Border CreateSyllableBox(string syllable)
        {
            var border = new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),
                Width = 260,
                Height = 190,
                Margin = new Thickness(10),
                Tag = syllable
            };

            // Initial image as the background
            var image = new Image
            {
                Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/Views/Resources/Images/Syllabe2.jpeg")),
                Stretch = Stretch.Fill,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            border.Child = image;

            // Handle clicks to reveal the syllable
            border.MouseDown += (s, e) =>
            {
                var clickedBorder = s as Border;
                var syllableText = clickedBorder.Tag.ToString();

                // Change the background to a new image
                clickedBorder.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("pack://siteoforigin:,,,/Views/Resources/Images/Syllabe2.jpeg"))
                };

                // Display the syllable text over the new background
                clickedBorder.Child = new TextBlock
                {
                    Text = syllableText,
                    FontSize = 90,
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                PlaySound();
            };

            return border;
        }

        private void PlaySound()
        {
            try
            {
                _player.Open(new Uri("pack://siteoforigin:,,,/Views/Resources/Sounds/Bingo.mp3", UriKind.Absolute));
                _player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing background music: {ex.Message}");
            }
        }

        private async void ShowRandomSyllable()
        {
            if (_currentVisibleBorder != null && _currentVisibleBorder.Child is TextBlock)
            {
                // Reset the previous border's background to the default card back
                _currentVisibleBorder.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("pack://siteoforigin:,,,/Views/Resources/Images/Syllabe2.jpeg"))
                };

                // Reset the content to the original image
                _currentVisibleBorder.Child = new Image
                {
                    Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/Views/Resources/Images/Syllabe2.jpeg")),
                    Stretch = Stretch.Fill,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                _currentVisibleBorder = null;
            }

            int index = _random.Next(_viewModel.DisplaySyllables.Count);
            string randomSyllable = _viewModel.DisplaySyllables[index];

            foreach (var child in SyllablesOnlyContainer.Children)
            {
                if (child is Border border && border.Tag.ToString() == randomSyllable)
                {
                    if (border.Child is TextBlock)
                        return;

                    // Change the background to a new image
                    border.Background = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("pack://siteoforigin:,,,/Views/Resources/Images/Back1.jpg"))
                    };

                    // Display the syllable text
                    var textBlock = new TextBlock
                    {
                        Text = randomSyllable,
                        FontSize = 120,
                        FontWeight = FontWeights.Bold,
                        Opacity = 0,
                        FontFamily = new FontFamily("Rockwell"), // Change the font family here
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    border.Child = textBlock;
                    _currentVisibleBorder = border;

                    PlaySound();

                    // Animate the text fading in
                    var fadeInAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(2.5)
                    };
                    textBlock.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);

                    break;
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && _viewModel.DisplaySyllables != null && _viewModel.DisplaySyllables.Count > 0)
            {
                ShowRandomSyllable();
            }
        }
    }
}
