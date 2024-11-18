using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace assi
{
    /// <summary>
    /// Interaction logic for confermpass.xaml
    /// </summary>
    public partial class confermpass : Page
    {
        assEntities db = new assEntities();
        public confermpass()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

           if(pass.Text== ""|| confemi.Text=="")
           {
                MessageBox.Show("error");
           }
            if (!(Regex.IsMatch(pass.Text, "[a-z]") && Regex.IsMatch(pass.Text, "[A-Z]") && Regex.IsMatch(pass.Text, "[!-@-#-$-%]") && Regex.IsMatch(pass.Text, "[\\d]")))
            {
                MessageBox.Show("Weak Password");
                return;
            }
            var stu = db.studentsses.Where(x=> x.SEmail==confemi.Text).FirstOrDefault();
            if (stu != null)
            {
                stu.Spassword = pass.Text;
                db.SaveChanges();
                MessageBox.Show("password succful");
                login login = new login();
                this.NavigationService.Navigate(login);
            }
            else 
            {

                MessageBox.Show("error");
            }

           

        }
    }
}
