using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<AirTicketViewModel> TicketsList { get; set; }

        public MainViewModel(List<AirTicket> airTickets)
        {
            TicketsList = new ObservableCollection<AirTicketViewModel>(airTickets.Select(b => new AirTicketViewModel(b)));
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
