using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace seance2
{
    /// <summary>
    /// Interaction logic for ToDoListWindow.xaml
    /// </summary>
    public partial class ToDoListWindow : Window
    {
        private ObservableCollection<TacheItem> taches = new ObservableCollection<TacheItem>();

        private readonly string cheminFichier = System.IO.Path.Combine(
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments),
            "todolist.xml");

        public ToDoListWindow()
        {
            InitializeComponent();
            ChargerTaches();
            ListeTaches.ItemsSource = taches;
        }

        private void ChargerTaches()
        {
            if (!File.Exists(cheminFichier))
                return;

            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<TacheItem>));
            using (FileStream fs = new FileStream(cheminFichier, FileMode.Open))
            {
                taches = (ObservableCollection<TacheItem>)serializer.Deserialize(fs);
            }
        }

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            string titre = TxtNouvelleTache.Text.Trim();
            if (titre == "")
                return;

            taches.Add(new TacheItem { Titre = titre, IsDone = false });
            TxtNouvelleTache.Clear();
        }

        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (ListeTaches.SelectedItem is TacheItem tache)
                taches.Remove(tache);
        }

        private void BtnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<TacheItem>));
            using (FileStream fs = new FileStream(cheminFichier, FileMode.Create))
            {
                serializer.Serialize(fs, taches);
            }
            MessageBox.Show("To-do liste enregistrée.");
        }
    }
}
