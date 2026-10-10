using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace seance2
{
    internal class ChronoViewModel : INotifyPropertyChanged
    {
        private readonly ChronoModel _model = new ChronoModel();
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        public RelayCommand DemarrerCommand { get; }
        public RelayCommand ArreteCommand { get; }
        public RelayCommand ReinitialiserCommand { get; }

        public ChronoViewModel()
        {
            _timer.Interval = TimeSpan.FromSeconds(1); //un tic par 1 seconde
            _timer.Tick += Timer_Tick;
            DemarrerCommand = new RelayCommand(Demarrer, () => !_timer.IsEnabled);
            ArreteCommand = new RelayCommand(Arreter, () => _timer.IsEnabled);
            ReinitialiserCommand = new RelayCommand(Reinitialiser, () => !_timer.IsEnabled && _model.Secondes > 0);
        }
        public void Timer_Tick(object sender, EventArgs e)
        {
            _model.Incrementer();
            MettreAJourAffichage();
        }

        public void Demarrer()
        {
            _timer.Start();
            DemarrerCommand.RaiseCanExecuteChanged();
        }
        public void Arreter()
        {
            _timer.Stop();
            ArreteCommand.RaiseCanExecuteChanged();
        }
        private void Reinitialiser()
        {
            _model.Reinitialiser();
            MettreAJourAffichage();
            ReinitialiserCommand.RaiseCanExecuteChanged();
        }
        public double AngleSecondes
        {
            get { return (_model.Secondes % 60) * 6; }
        }
        public double AngleMinutes
        {
            get { return ((_model.Secondes / 60) % 60) * 6; }
        }
        public string TexteTemps
        {
            get { return $"{_model.Secondes / 60:00}:{_model.Secondes % 60:00}"; }
        }
        private void MettreAJourAffichage ()
        {
            OnPropertyChanged(nameof(AngleSecondes));
            OnPropertyChanged(nameof(AngleMinutes));
            OnPropertyChanged(nameof(TexteTemps));

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nomPropriete)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomPropriete));
        }
    }
}
