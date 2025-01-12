using Atelier_des_Mots.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier_des_Mots.ViewModels
{
    internal class MainViewModel
    {
        public WordModel WordExercise { get; set; }
        public PhraseModel PhraseExercise { get; set; }
        // Implement PropertyChanged event
    }
}
