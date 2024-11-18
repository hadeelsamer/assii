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
    /// Interaction logic for signup.xaml
    /// </summary>
    public partial class signup : Page
    {
        assEntities db = new assEntities();
        public signup()
        {
            InitializeComponent();
        }

        private void signbutton_Click(object sender, RoutedEventArgs e)
        {


            string entername = Nametxt.Text;
            string enteremail = Emailtxt.Text;
            string enterpassword = Passwtxth.Text;
            string enterconfirmPassword = conftxt.Text;

            if (entername == "" || enteremail == "" || enterpassword == "" || enterconfirmPassword == "")
            {
                MessageBox.Show("please enter all data");
                return;
            }

            if (enterpassword != enterconfirmPassword)
            {
                MessageBox.Show("Password not match");
                return;
            }

            if (!(Regex.IsMatch(enterpassword, "[a-z]") && Regex.IsMatch(enterpassword, "[A-Z]") && Regex.IsMatch(enterpassword, "[!-@-#-$-%]") && Regex.IsMatch(enteremail, "[\\d]")))
            {
                MessageBox.Show("Weak Password");
                return;
            }




            var sss = db.studentsses.Where(x => x.SEmail == enteremail).FirstOrDefault();

            if (sss != null)
            {
                MessageBox.Show("email already in database");
                return;

            }

            else
            {

                studentss stu = new studentss();
                stu.SName = entername;
                stu.SEmail = enteremail;
                stu.Spassword = enterpassword;
                db.studentsses.Add(stu);
                 db.SaveChanges();
                login loginn = new login();
                this.NavigationService.Navigate(loginn);
                MessageBox.Show("DONE");


            }
        }

    }
}