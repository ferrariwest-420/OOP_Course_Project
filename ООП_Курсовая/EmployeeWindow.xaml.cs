using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace ООП_Курсовая
{
    public partial class EmployeeWindow : Window
    {
        private List<Employee> employees; // Список сотрудников
        private static readonly string FilePath = @"C:\Users\User\source\repos\ООП_Курсовая\employees.txt"; // Путь к файлу
        private int nextId = 0; // Следующий ID сотрудника

        public EmployeeWindow()
        {
            InitializeComponent();

            // Если файл не существует, создаём пустой
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();
            }

            // Загружаем список сотрудников из файла
            employees = FileHandler.LoadEmployees(FilePath);

            // Устанавливаем следующий ID
            if (employees.Count > 0)
            {
                nextId = employees.Max(e => e.Id) + 1;
            }

            EmployeeDataGrid.ItemsSource = employees; // Привязываем данные к таблице
        }

        // Обработчик для добавления сотрудника
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var newEmployee = new Employee
            {
                Id = nextId++, // Автоматически присваиваем ID
                Name = "Новый сотрудник",
                PhoneNumber = "1234567890", // Дефолтный номер телефона
                Position = "Должность",
                Salary = 30000
            };
            employees.Add(newEmployee); // Добавляем сотрудника в список
            RefreshDataGrid(); // Обновляем таблицу
        }

        // Обработчик для редактирования сотрудника
        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = EmployeeDataGrid.SelectedItem as Employee; // Получаем выбранного сотрудника
            if (selectedEmployee != null)
            {
                // Изменения уже внесены в DataGrid, просто сохраняем их
                RefreshDataGrid(); // Обновляем таблицу
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Обработчик для удаления сотрудника
        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = EmployeeDataGrid.SelectedItem as Employee; // Получаем выбранного сотрудника
            if (selectedEmployee != null)
            {
                employees.Remove(selectedEmployee); // Удаляем сотрудника из списка
                RefreshDataGrid(); // Обновляем таблицу
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Обновляем таблицу и сохраняем данные
        private void RefreshDataGrid()
        {
            EmployeeDataGrid.ItemsSource = null; // Сбрасываем источник данных для обновления
            EmployeeDataGrid.ItemsSource = employees; // Привязываем обновлённый список
            FileHandler.SaveEmployees(employees, FilePath); // Сохраняем изменения в файл
        }

        // Обработчик для закрытия окна
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Сохраняем список сотрудников в файл при закрытии окна
            FileHandler.SaveEmployees(employees, FilePath);
        }
    }
}
