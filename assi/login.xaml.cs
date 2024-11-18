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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace assi
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        assEntities db=new assEntities();
        public login()
        {
            InitializeComponent();
        }

        private void signbutton_Click(object sender, RoutedEventArgs e)
        {
            signup signup = new signup();
            NavigationService.Navigate(signup);



        }

        private void loginbutton_Click(object sender, RoutedEventArgs e)
        {
            string emailadmin = "1";
            string passwordadmin = "1";

            string enterpass = passtxt.Text;
            string enteremail = emailtxt.Text;

            if (enteremail == "" || enterpass == "")
            {
                MessageBox.Show("please enter email and password");
                return;
            }
            if (emailadmin == enteremail && passwordadmin == enterpass)
            {
                admm adminnn = new admm();
                NavigationService.Navigate(adminnn);
            }
            else

            {

                studentss studentss = new studentss();


                var stu = db.studentsses.FirstOrDefault(x => x.SEmail == enteremail && x.Spassword == enterpass);
                if (stu != null)
                {
                    MessageBox.Show("data is correct");
                    apps application = new apps();
                    NavigationService.Navigate(application);
                }

                else
                {
                    MessageBox.Show("data in not correct database");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            confermpass confermpass = new confermpass();
           NavigationService .Navigate(confermpass);
        }
    }
}
