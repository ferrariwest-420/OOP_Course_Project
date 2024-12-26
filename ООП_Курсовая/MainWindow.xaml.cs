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

namespace ООП_Курсовая
{
    /// <summary>
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            var employeeWindow = new EmployeeWindow(); // Окно для работы с сотрудниками
            employeeWindow.Show();
        }

        private void VehiclesButton_Click(object sender, RoutedEventArgs e)
        {
            var vehicleWindow = new VehicleWindow(); // Окно для работы с транспортом
            vehicleWindow.Show();
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            var productWindow = new ProductWindow(); // Окно для работы с товарами и услугами
            productWindow.Show();
        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            var clientWindow = new ClientWindow(); // Окно для работы с клиентами
            clientWindow.Show();
        }
    }

}