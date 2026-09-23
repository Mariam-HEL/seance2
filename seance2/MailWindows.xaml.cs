using System;
using System.Collections.Generic;
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
using System.Net;
using System.Net.Mail;
using System.Linq.Expressions;
namespace seance2
{
    /// <summary>
    /// Interaction logic for MailWindows.xaml
    /// </summary>
    public partial class MailWindows : Window
    {
        public MailWindows()
        {
            InitializeComponent();
        }

        private void btnEnvoyer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(txtEmail.Text);
                mail.To.Add(txtDestinataire.Text);
                mail.Subject = txtObjet.Text;
                mail.Body = txtMessage.Text;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(txtEmail.Text, pwdPassword.Password);
                smtp.Send(mail);
                MessageBox.Show("Mail envoye!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : "+ ex.Message, "Erreur : ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        
    }
}
