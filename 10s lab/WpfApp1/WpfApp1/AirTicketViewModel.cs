using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SampleMVVM.Commands;

namespace WpfApp1
{
    class AirTicketViewModel : INotifyPropertyChanged
    {
        public AirTicket airTicket;
        TicketsContext db;


        public AirTicketViewModel(AirTicket ticket)
        {
            this.airTicket = ticket;
        }

        public int Id
        {
            get
            {
                return airTicket.Id;
            }
            set
            {
                airTicket.Id = value;
                //OnPropertyChanged("Id");
            }
        }

        public string Title
        {
            get
            {
                return airTicket.Title;
            }
            set
            {
                airTicket.Title = value;
                //OnPropertyChanged("Title");
            }
        }

        public string Date
        {
            get
            {
                return airTicket.Date;
            }
            set
            {
                airTicket.Date = value;
                //OnPropertyChanged("Date");
            }
        }

        public string Type
        {
            get
            {
                return airTicket.Type;
            }
            set
            {
                airTicket.Type = value;
                //OnPropertyChanged("Type");
            }
        }

        public int Count
        {
            get
            {
                return airTicket.Count;
            }
            set
            {
                airTicket.Count = value;
                OnPropertyChanged("Count");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #region Commands

        #region Купить

        private DelegateCommand getItemCommand;

        public ICommand GetItemCommand
        {
            get
            {
                if (getItemCommand == null)
                {
                    getItemCommand = new DelegateCommand(GetItem);
                }
                return getItemCommand;
            }
        }

        private void GetItem()
        {
            Count++;
            db = new TicketsContext();
            db.AirTickets.Load();
            AirTicket ticket = new AirTicket();
            ticket = db.AirTickets.Find(Id);
            ticket.Count = Count;
            db.SaveChanges();
            db.Dispose();
        }

        #endregion

        #region Возврат

        private DelegateCommand giveItemCommand;

        public ICommand GiveItemCommand
        {
            get
            {
                if (giveItemCommand == null)
                {
                    giveItemCommand = new DelegateCommand(GiveItem, CanGiveItem);
                }
                return giveItemCommand;
            }
        }

        private void GiveItem()
        {
            Count--;
            db = new TicketsContext();
            db.AirTickets.Load();
            AirTicket ticket = new AirTicket();
            ticket = db.AirTickets.Find(Id);
            ticket.Count = Count;
            db.SaveChanges();
            db.Dispose();
        }

        private bool CanGiveItem()
        {
            return Count > 0;
        }

        #endregion

        #region Добавление книги
        private DelegateCommand addItemCommand;

        public ICommand AddItemCommand
        {
            get
            {
                if (addItemCommand == null)
                {
                    addItemCommand = new DelegateCommand(AddItem);
                }
                return addItemCommand;
            }
        }

        private void AddItem()
        {
            db = new TicketsContext();
            db.AirTickets.Load();
            Random rand = new Random();
            AirTicket ticket = new AirTicket();
            ticket.Title = Title;
            ticket.Count = rand.Next(1, 100);
            ticket.Date = Date;
            ticket.Type = Type;

            db.AirTickets.Add(ticket);
            db.SaveChanges();
            db.Dispose();
            Console.WriteLine("che nit" + ticket.Title);
        }
        #endregion
        #endregion
    }
}
