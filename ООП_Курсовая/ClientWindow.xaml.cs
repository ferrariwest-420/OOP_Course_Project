using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ООП_Курсовая
{
    public partial class ClientWindow : Window
    {
        private List<Client> clients; // Список клиентов
        private static readonly string FilePath = @"C:\Users\User\source\repos\ООП_Курсовая\clients.txt"; // Путь к файлу

        public ClientWindow()
        {
            InitializeComponent();

            // Если файл не существует, создаём пустой
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();
            }

            // Загружаем список клиентов из файла
            clients = FileHandler.LoadClients(FilePath);
            ClientDataGrid.ItemsSource = clients; // Привязываем данные к таблице
        }

        // Обработчик для добавления клиента
        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            var newClient = new Client
            {
                Name = "Новый клиент",
                PhoneNumber = "123456789",
                IsRegular = false // Новый клиент по умолчанию не постоянный
            };
            clients.Add(newClient); // Добавляем клиента в список
            RefreshDataGrid(); // Обновляем таблицу и сохраняем изменения
        }

        // Обработчик для редактирования клиента
        private void EditClient_Click(object sender, RoutedEventArgs e)
        {
            var selectedClient = ClientDataGrid.SelectedItem as Client;
            if (selectedClient != null)
            {
                // Данные уже изменены пользователем в DataGrid, просто сохраняем их
                RefreshDataGrid(); // Обновляем таблицу и сохраняем изменения
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите клиента для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Обработчик для удаления клиента
        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            var selectedClient = ClientDataGrid.SelectedItem as Client;
            if (selectedClient != null)
            {
                // Удаляем выбранного клиента из списка
                clients.Remove(selectedClient);
                RefreshDataGrid(); // Обновляем таблицу и сохраняем изменения
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите клиента для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Обновляем таблицу и сохраняем данные
        private void RefreshDataGrid()
        {
            ClientDataGrid.ItemsSource = null; // Сбрасываем источник данных для обновления
            ClientDataGrid.ItemsSource = clients; // Привязываем обновлённый список
            FileHandler.SaveClients(clients, FilePath); // Сохраняем изменения в файл
        }

        // Обработчик для закрытия окна
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Сохраняем список клиентов в файл при закрытии окна
            FileHandler.SaveClients(clients, FilePath);
        }
    }
}
