using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Atelier_des_Mots.Views;

namespace Atelier_des_Mots.Views
{
    public partial class MainWindow : Window
    {
        private MediaPlayer _player = new MediaPlayer();
        private MediaPlayer _secondPlayer = new MediaPlayer(); // Second player for new sound
                                                               // Schedule second sound to play after 10 seconds
        private string appDataPath;  // Declare the appDataPath variable
        private string PhraseExerciseData = "";  // Store the phrase exercise content
        public string ExerciseData { get; private set; }





        public MainWindow()
        {
            InitializeComponent();
            PlayBackgroundMusic();
            ScheduleNextSound();
            appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Atelier Des Mots");

            InitializeAppData();

        }
        private void InitializeAppData()
        {
            // Path to the exercises.txt file in the Data folder (local file)
            string sourceFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "Resources", "Data", "Exercices.txt");
            string tempFilePath = Path.Combine(appDataPath, "Exercices.txt");

            // Check if the file exists in the local folder or needs to be copied from a template
            if (!File.Exists(tempFilePath) || File.GetLastWriteTime(sourceFilePath) > File.GetLastWriteTime(tempFilePath))
            {
                CopyFileIfNewer(sourceFilePath, tempFilePath);
            }

            // Now read the exercises data from the local temp file
            ReadExerciseData(tempFilePath);
        }

        private void CopyFileIfNewer(string sourceFilePath, string tempFilePath)
        {
            // Ensure the folder exists
            string directoryPath = Path.GetDirectoryName(tempFilePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Copy the content from the source file (template or original) to the destination with UTF-8 encoding
            using (var reader = new StreamReader(sourceFilePath, Encoding.UTF8))
            using (var writer = new StreamWriter(tempFilePath, false, Encoding.UTF8))
            {
                writer.Write(reader.ReadToEnd());
            }
        }


        private void ReadExerciseData(string filePath)
        {
            if (!File.Exists(filePath))
            {
                ExerciseData = File.ReadAllText(filePath, Encoding.UTF8);
                MessageBox.Show("The exercise file is missing.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
            bool isPhraseExerciseSection = false;
            List<string> phraseLines = new List<string>();

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                // Check if the line is a phrase, syllable, or syllable-only exercise
                if (trimmedLine.StartsWith("# Syllable Exercise") ||
                    trimmedLine.StartsWith("# Syllables Only Exercise"))
                {
                    isPhraseExerciseSection = false; // Stop collecting phrases
                }

                if (isPhraseExerciseSection && !string.IsNullOrWhiteSpace(trimmedLine))
                {
                    phraseLines.Add(trimmedLine); // Collect valid phrase lines
                }

                if (trimmedLine.StartsWith("# Phrase Exercise"))
                {
                    isPhraseExerciseSection = true; // Start collecting phrases
                }
            }

            // Convert the phrases to the desired format
            PhraseExerciseData = phraseLines.Count > 0 ? string.Join("/", phraseLines) : "No phrase exercise found.";
        }






        private void PlayBackgroundMusic()
        {
            try
            {
                _player.Open(new Uri("Views/Resources/Sounds/MainMusic.mp3", UriKind.Relative));
                _player.Volume = 0.1; // Adjust volume (e.g., 0.2 for 20%)
                _player.Play();

                // Loop the music when it ends
                _player.MediaEnded += (sender, e) =>
                {
                    _player.Position = TimeSpan.Zero; // Reset position
                    _player.Play(); // Restart playback
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing background music: {ex.Message}");
            }
        }
        private void ScheduleNextSound()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10); // 10-second delay
            timer.Tick += (sender, e) =>
            {
                timer.Stop(); // Stop the timer
                PlaySecondSound();
            };
            timer.Start();
        }

        private void PlaySecondSound()
        {
            try
            {
                _secondPlayer.Open(new Uri("Views/Resources/Sounds/Bonjour.mp3", UriKind.Relative));
                _secondPlayer.Volume = 0.9; // Adjust volume (40%)
                _secondPlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing second sound: {ex.Message}");
            }
        }



        private void SyllablesExercise_Click(object sender, RoutedEventArgs e)
        {
            // Open the Syllable Exercise Preparation View
            SyllableExercisePreparationView syllablePreparationView = new SyllableExercisePreparationView();
            syllablePreparationView.Show();

            // Trigger the button click event in SyllableExercisePreparationView automatically
            syllablePreparationView.DisplayToStudents_Click(sender, e);
        }


        private void DisorderedPhraseExercise_Click(object sender, RoutedEventArgs e)
        {
            // Open the Phrase Exercise Preparation View
            PhraseExercisePreparationView phraseView = new PhraseExercisePreparationView(PhraseExerciseData);
            phraseView.Show();

            // Trigger the button click event in PhraseExercisePreparationView automatically
            phraseView.DisplayToStudents_Click(sender, e);
        }




        private void SyllablesOnlyExercise_Click(object sender, RoutedEventArgs e)
        {
            // Open the Syllables Only Exercise Preparation View
            SyllablesOnlyExercisePreparationView syllablesOnlyView = new SyllablesOnlyExercisePreparationView();
            syllablesOnlyView.Show();

            // Trigger the button click event in SyllablesOnlyExercisePreparationView automatically
            syllablesOnlyView.DisplayToStudents_Click(sender, e);
        }
    }
}
