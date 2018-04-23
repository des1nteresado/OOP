using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        TicketsContext db;

        private void OnStartup(object sender, StartupEventArgs e)
        {
            //List<AirTicket> airTickets = new List<AirTicket>()
            //{
            //new AirTicket(1, "Москва-Минск", "21.05.2018", "Бизнес класс", 5),
            //new AirTicket(2, "Борисполь-Хургада", "13.12.2018", "Эконом класс", 2),
            //new AirTicket(3, "Минск-Лондон", "30.07.2018", "Бизнес класс", 4)
            //};

            db = new TicketsContext();

            db.AirTickets.Load();

            List<AirTicket> airTickets = db.AirTickets.ToList();
            MainWindow view = new MainWindow();
            MainViewModel viewModel = new MainViewModel(airTickets);
            view.DataContext = viewModel;
            view.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            db.Dispose();
        }
    }
}
