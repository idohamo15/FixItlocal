using Model;
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
using ViewModel;

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //StudentDB studentDB = new StudentDB();
            //StudentList students = studentDB.SelectAll();

            //Student student = studentDB.SelectById(1);

            //student.LastName = "Levi";
            //studentDB.Insert(student);
            //StudentDB.SaveChanges();
        }
    }
}