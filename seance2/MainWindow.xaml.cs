using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace seance2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuMail_Click(object sender, RoutedEventArgs e)
        {
            MailWindows fenetreMail = new MailWindows();
            fenetreMail.Show();
        }

        private void ToDoList_Click(object sender, RoutedEventArgs e)
        {
            ToDoListWindow fenetreToDo = new ToDoListWindow();
            fenetreToDo.Show();
        }
        private void Chrono_Click(object sender, RoutedEventArgs e)
        {
            ChronoWindow fenetreChrono = new ChronoWindow();
            fenetreChrono.Show();
        }
    }
}