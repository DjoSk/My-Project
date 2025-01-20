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
                Background = Brushes.LightCoral,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),
                Width = 240,
                Height = 180,
                Margin = new Thickness(10),
                Tag = syllable
            };

            var image = new Image
            {
                Source = new BitmapImage(new Uri("D:/Project1/Atelier des Mots/Views/Resources/Images/Kid1.jpg")),
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

                PlaySound();
            };

            return border;
        }



        private void PlaySound()
        {
            _player.Open(new Uri("D:/Project1/Atelier des Mots/Views/Resources/Sounds/Music.mp3"));
            _player.Play();
        }

        private async void ShowRandomSyllable()
        {
            if (_currentVisibleBorder != null && _currentVisibleBorder.Child is TextBlock)
            {
                var backImage = new Image
                {
                    Source = new BitmapImage(new Uri("D:/Project1/Atelier des Mots/Views/Resources/Images/cards.jpg")),
                    Stretch = Stretch.Fill,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                var fadeOutAnimation = new DoubleAnimation
                {
                    From = 1,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(1)
                };

                var textBlock = _currentVisibleBorder.Child as TextBlock;
                textBlock.BeginAnimation(TextBlock.OpacityProperty, fadeOutAnimation);
                await Task.Delay(700);

                _currentVisibleBorder.Child = backImage;
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

                    var textBlock = new TextBlock
                    {
                        Text = randomSyllable,
                        FontSize = 90,
                        FontWeight = FontWeights.Bold,
                        Opacity = 0,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    border.Child = textBlock;
                    _currentVisibleBorder = border;

                    PlaySound();

                    var fadeInAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(3)
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
