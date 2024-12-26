using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ООП_Курсовая
{
    public partial class VehicleWindow : Window
    {
        private List<Vehicle> vehicles; // Единый список для всех транспортных средств
        private static readonly string FilePath = @"C:\Users\User\source\repos\ООП_Курсовая\vehicles.txt"; // Путь к файлу

        public VehicleWindow()
        {
            InitializeComponent();

            // Загружаем список транспортных средств из файла
            vehicles = FileHandler.LoadVehicles(FilePath);

            // Привязываем автомобили и мотоциклы к соответствующим таблицам
            CarDataGrid.ItemsSource = vehicles.OfType<Car>().ToList();
            MotorcycleDataGrid.ItemsSource = vehicles.OfType<Motorcycle>().ToList();
        }

        // Добавление автомобиля
        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            var car = new Car
            {
                Model = "Новый автомобиль",
                PollutionDegree = 2,
                Price = 150,
                EngineType = "Бензиновый"
            };
            vehicles.Add(car); // Добавляем автомобиль в общий список
            RefreshDataGrids(); // Обновляем таблицы
        }

        // Редактирование автомобиля
        private void EditCar_Click(object sender, RoutedEventArgs e)
        {
            var selectedCar = CarDataGrid.SelectedItem as Car;
            if (selectedCar != null)
            {
                RefreshDataGrids(); // Обновляем таблицы и сохраняем данные
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите автомобиль для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Удаление автомобиля
        private void DeleteCar_Click(object sender, RoutedEventArgs e)
        {
            var selectedCar = CarDataGrid.SelectedItem as Car;
            if (selectedCar != null)
            {
                vehicles.Remove(selectedCar);
                RefreshDataGrids(); // Обновляем таблицы и сохраняем данные
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите автомобиль для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Добавление мотоцикла
        private void AddMotorcycle_Click(object sender, RoutedEventArgs e)
        {
            var motorcycle = new Motorcycle
            {
                Model = "Новый мотоцикл",
                PollutionDegree = 1,
                Price = 100,
                MotorcycleType = "Спортивный"
            };
            vehicles.Add(motorcycle); // Добавляем мотоцикл в общий список
            RefreshDataGrids(); // Обновляем таблицы
        }

        // Редактирование мотоцикла
        private void EditMotorcycle_Click(object sender, RoutedEventArgs e)
        {
            var selectedMotorcycle = MotorcycleDataGrid.SelectedItem as Motorcycle;
            if (selectedMotorcycle != null)
            {
                RefreshDataGrids(); // Обновляем таблицы и сохраняем данные
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите мотоцикл для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Удаление мотоцикла
        private void DeleteMotorcycle_Click(object sender, RoutedEventArgs e)
        {
            var selectedMotorcycle = MotorcycleDataGrid.SelectedItem as Motorcycle;
            if (selectedMotorcycle != null)
            {
                vehicles.Remove(selectedMotorcycle);
                RefreshDataGrids(); // Обновляем таблицы и сохраняем данные
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите мотоцикл для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Обновление таблиц и сохранение данных
        private void RefreshDataGrids()
        {
            CarDataGrid.ItemsSource = vehicles.OfType<Car>().ToList(); // Обновляем таблицу автомобилей
            MotorcycleDataGrid.ItemsSource = vehicles.OfType<Motorcycle>().ToList(); // Обновляем таблицу мотоциклов
            FileHandler.SaveVehicles(vehicles, FilePath); // Сохраняем изменения в файл
        }

        // Обработчик закрытия окна
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FileHandler.SaveVehicles(vehicles, FilePath); // Сохраняем данные при закрытии окна
        }
    }
}
