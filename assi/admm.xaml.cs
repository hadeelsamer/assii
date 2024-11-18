using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace assi
{
    public partial class admm : Page
    {
        assEntities db = new assEntities();
        public admm()
        {
            InitializeComponent();
             comboBox.ItemsSource=db.departments.Select(v=> v.D_Name).Distinct().ToList();
            refrech();
        }
        public void refrech()
        {
            var st = db.studentsses
                            .Select(x => new { x.ID, x.SName, x.SAddress, Department = x.department.D_Name })
                            .ToList();
           data.ItemsSource = st;
        }

        private void Delet(object sender, RoutedEventArgs e)
        {
            if(studentId.Text=="")
            {
                MessageBox.Show(" enter id");
                return;
            }
            int id = int.Parse(studentId.Text);
            var stu= db.studentsses.Where(x=> x.ID==id).FirstOrDefault();
           if(stu != null)
           {
                db.studentsses.Remove(stu);
                db.SaveChanges();
                MessageBox.Show("delete sucssuel");

           }
            refrech();
        }
        private void update(object sender, RoutedEventArgs e)
        {

            if (studentId.Text == "" || DepName.Text == "")
            {
                MessageBox.Show("Fileds Are reqiured");
                return;
            }

            int id = int.Parse(studentId.Text);
            var stu =db.studentsses.Where(x=> x.ID==id).FirstOrDefault();
            if (stu != null)
            {   
                if (stu.department.D_Name== "" || stu.department.D_Name == null)
                {
                   department d = new department();
                    d.D_Name = DepName.Text;
                    stu.department = d;
                    return;
                    
                }
                else
                {
                    stu.department.D_Name = DepName.Text;
                }
                db.SaveChanges();
                MessageBox.Show("Updated Successfully");
            }
            refrech();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(search.Text =="")
            {
                MessageBox.Show("error");
                return;
            }
            var stu = db.studentsses.Where(X => X.SName.Contains(search.Text)).Select(X => new { X.SName,X.ID, X.SAddress, X.SAge, department = X.department.D_Name  }).ToList();
            data.ItemsSource = stu.ToList();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string j = comboBox.SelectedItem.ToString();
            if (!(j == null))
            {
                var stuu = db.studentsses.Where(s => s.department.D_Name == j).Select(stu => new { stu.ID, stu.SName, stu.SAddress, stu.SAge ,stu.department.D_Name }).ToList();
                data.ItemsSource = stuu;
            }

        }
    }
}

