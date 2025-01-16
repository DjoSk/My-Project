using Atelier_des_Mots.Models;
using System.ComponentModel;

namespace Atelier_des_Mots.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private WordModel _wordExercise;
        private PhraseModel _phraseExercise;
        private SyllabeModel _syllabeExercise;

        public WordModel WordExercise
        {
            get => _wordExercise;
            set
            {
                _wordExercise = value;
                OnPropertyChanged(nameof(WordExercise));
            }
        }

        public PhraseModel PhraseExercise
        {
            get => _phraseExercise;
            set
            {
                _phraseExercise = value;
                OnPropertyChanged(nameof(PhraseExercise));
            }
        }

        public SyllabeModel SyllabeExercise
        {
            get => _syllabeExercise;
            set
            {
                _syllabeExercise = value;
                OnPropertyChanged(nameof(SyllabeExercise));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
