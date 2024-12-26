using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_Курсовая
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class FileHandler
    {
        // Загружает товары и услуги из текстового файла
        public static List<Product> LoadProducts(string filePath)
        {
            var products = new List<Product>();

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length >= 3)
                    {
                        if (parts[0] == "Goods")
                        {
                            var goods = new Goods
                            {
                                Name = parts[1],
                                Price = decimal.Parse(parts[2]),
                                Volume = decimal.Parse(parts[3])
                            };
                            products.Add(goods);
                        }
                        else if (parts[0] == "Services")
                        {
                            var service = new Services
                            {
                                Name = parts[1],
                                Price = decimal.Parse(parts[2]),
                                Intensity = int.Parse(parts[3])
                            };
                            products.Add(service);
                        }
                    }
                }
            }

            return products;
        }

        // Сохраняет товары и услуги в файл
        public static void SaveProducts(List<Product> products, string filePath)
        {
            var lines = products.Select(product =>
            {
                if (product is Goods goods)
                    return $"Goods;{goods.Name};{goods.Price};{goods.Volume}";
                else if (product is Services service)
                    return $"Services;{service.Name};{service.Price};{service.Intensity}";
                return string.Empty;
            }).Where(line => !string.IsNullOrEmpty(line)).ToList();

            File.WriteAllLines(filePath, lines);
        }

        // Загружает клиентов из текстового файла
        public static List<Client> LoadClients(string filePath)
        {
            var clients = new List<Client>();

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length >= 3)
                    {
                        var client = new Client
                        {
                            Name = parts[0],
                            PhoneNumber = parts[1],
                            IsRegular = bool.Parse(parts[2])
                        };
                        clients.Add(client);
                    }
                }
            }

            return clients;
        }

        // Сохраняет клиентов в файл
        public static void SaveClients(List<Client> clients, string filePath)
        {
            var lines = clients.Select(client =>
                $"{client.Name};{client.PhoneNumber};{client.IsRegular}").ToList();
            File.WriteAllLines(filePath, lines);
        }

        // Загружаем список сотрудников из файла
        public static List<Employee> LoadEmployees(string filePath)
        {
            var employees = new List<Employee>();

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length == 5)
                    {
                        employees.Add(new Employee
                        {
                            Id = int.Parse(parts[0]),
                            Name = parts[1],
                            PhoneNumber = parts[2],
                            Position = parts[3],
                            Salary = decimal.Parse(parts[4])
                        });
                    }
                }
            }

            return employees;
        }

        // Сохраняем список сотрудников в файл
        public static void SaveEmployees(List<Employee> employees, string filePath)
        {
            var lines = employees.Select(e => $"{e.Id};{e.Name};{e.PhoneNumber};{e.Position};{e.Salary}").ToList();
            File.WriteAllLines(filePath, lines);
        }

        // Загрузка транспортных средств из файла
        public static List<Vehicle> LoadVehicles(string filePath)
        {
            var vehicles = new List<Vehicle>();

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts[0] == "Car" && parts.Length == 5)
                    {
                        vehicles.Add(new Car
                        {
                            Model = parts[1],
                            PollutionDegree = int.Parse(parts[2]),
                            Price = (int)decimal.Parse(parts[3]),
                            EngineType = parts[4]
                        });
                    }
                    else if (parts[0] == "Motorcycle" && parts.Length == 5)
                    {
                        vehicles.Add(new Motorcycle
                        {
                            Model = parts[1],
                            PollutionDegree = int.Parse(parts[2]),
                            Price = (int)decimal.Parse(parts[3]),
                            MotorcycleType = parts[4]
                        });
                    }
                }
            }

            return vehicles;
        }

        // Сохранение транспортных средств в файл
        public static void SaveVehicles(List<Vehicle> vehicles, string filePath)
        {
            var lines = vehicles.Select(vehicle =>
            {
                if (vehicle is Car car)
                {
                    return $"Car;{car.Model};{car.PollutionDegree};{car.Price};{car.EngineType}";
                }
                else if (vehicle is Motorcycle motorcycle)
                {
                    return $"Motorcycle;{motorcycle.Model};{motorcycle.PollutionDegree};{motorcycle.Price};{motorcycle.MotorcycleType}";
                }
                return string.Empty;
            }).Where(line => !string.IsNullOrEmpty(line)).ToList();

            File.WriteAllLines(filePath, lines);
        }

    }

}
