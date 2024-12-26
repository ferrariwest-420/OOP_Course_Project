using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ООП_Курсовая
{
    public partial class ProductWindow : Window
    {
        private List<Product> products; // Общий список для товаров и услуг
        private static readonly string FilePath = @"C:\Users\User\source\repos\ООП_Курсовая\products.txt"; // Путь к файлу

        public ProductWindow()
        {
            InitializeComponent();

            // Загружаем список продуктов
            products = FileHandler.LoadProducts(FilePath);

            // Привязываем данные к таблицам
            ProductDataGrid.ItemsSource = products.OfType<Goods>().ToList();  // Показываем только товары
            ServiceDataGrid.ItemsSource = products.OfType<Services>().ToList(); // Показываем только услуги
        }

        // Обработчик для добавления товара или услуги
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (IsProductTabSelected())
            {
                var product = new Goods
                {
                    Name = "Новый товар",
                    Price = 100,
                    Volume = 500
                };
                products.Add(product);
            }
            else
            {
                var service = new Services
                {
                    Name = "Новая услуга",
                    Price = 150,
                    Intensity = 3
                };
                products.Add(service);
            }

            RefreshDataGrids(); // Обновляем таблицы
        }

        // Обработчик для редактирования выбранного товара или услуги
        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (IsProductTabSelected())
            {
                var selectedProduct = ProductDataGrid.SelectedItem as Goods;
                if (selectedProduct != null)
                {
                    // Данные уже изменены в DataGrid, поэтому просто обновляем источник данных
                    RefreshDataGrids();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите товар для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                var selectedService = ServiceDataGrid.SelectedItem as Services;
                if (selectedService != null)
                {
                    // Данные уже изменены в DataGrid, поэтому просто обновляем источник данных
                    RefreshDataGrids();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите услугу для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        // Обработчик для удаления выбранного товара или услуги
        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (IsProductTabSelected())
            {
                var selectedProduct = ProductDataGrid.SelectedItem as Goods;
                if (selectedProduct != null)
                {
                    products.Remove(selectedProduct);
                    RefreshDataGrids();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите товар для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                var selectedService = ServiceDataGrid.SelectedItem as Services;
                if (selectedService != null)
                {
                    products.Remove(selectedService);
                    RefreshDataGrids();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите услугу для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        // Проверяем, выбрана ли вкладка "Товары"
        private bool IsProductTabSelected()
        {
            var selectedTab = ProductTabControl.SelectedItem as TabItem;
            return selectedTab != null && selectedTab.Header.ToString() == "Товары";
        }

        // Обновляем таблицы и сохраняем данные
        private void RefreshDataGrids()
        {
            ProductDataGrid.ItemsSource = products.OfType<Goods>().ToList(); // Обновляем товары
            ServiceDataGrid.ItemsSource = products.OfType<Services>().ToList(); // Обновляем услуги
            FileHandler.SaveProducts(products, FilePath); // Сохраняем изменения в файл
        }
    }
}
