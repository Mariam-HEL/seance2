using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seance2
{
    public class TacheItem : INotifyPropertyChanged
    {
        private string _titre;
        private bool _isDone;

        public string Titre
        {
            get { return _titre; }
            set
            {
                _titre = value;
                OnPropertyChanged(nameof(Titre));
            }
        }

        public bool IsDone
        {
            get { return _isDone; }
            set
            {
                _isDone = value;
                OnPropertyChanged(nameof(IsDone));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string nomPropriete)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomPropriete));
        }
    }
}
