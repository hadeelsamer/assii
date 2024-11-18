using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Interaction logic for apps.xaml
    /// </summary>
    public partial class apps : Page
    {
        assEntities db=new assEntities();
        
        public apps()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string entername = nametxt.Text;
            string enterage = Agtxt.Text;
            string enteraddres = Adresstxt.Text;
            string enterdepart = Dpartmenttxt.Text;
         
            if (entername == "" || enteraddres == "" || enterage == "" || enteraddres =="")
            {
                MessageBox.Show("plese enter your data");
                return;
            }
             var stuu= db.studentsses.Where(x=> x.SName==entername).FirstOrDefault();
            if (stuu != null)
            {
              
                department dep = new department();
                dep.D_Name = enterdepart;
                stuu.department = dep;
                stuu.SAddress = enteraddres;
                stuu.SAge = int.Parse(enterage);
               
                db.SaveChanges();
                MessageBox.Show(" succsful");
                login login = new login();
                this.NavigationService.Navigate(login);
                return;
            }
            else
            {
                MessageBox.Show(" error");
                return;
            }
        }
    }
}
