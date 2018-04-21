using System.Windows;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EFGenericRep<Item> itemRep = new EFGenericRep<Item>(new ChannelContext());
        EFGenericRep<Channel> chRep = new EFGenericRep<Channel>(new ChannelContext());

        //ChannelContext db;
        public MainWindow()
        {
            InitializeComponent();

            //db = new ChannelContext();

            //db.Items.Load();

            DataGrid1.ItemsSource = itemRep.Get();

            //DataGrid1.ItemsSource = db.Items.Local.ToBindingList();

            //this.Closing += MainWindow_Closing;

        }

        //private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    db.Dispose();
        //}

        private void Add_Click(object sender, RoutedEventArgs e)
        {
                ItemWindow iWin = new ItemWindow();

            // из команд в бд формируем список

            //List<Channel> channels = db.Channels.ToList();
            //List<Channel> channels = (List<Channel>)chRep.Get();


            //iWin.comboBox1.ItemsSource = db.Channels.Local.ToBindingList();
            iWin.comboBox1.ItemsSource = chRep.Get();

            iWin.comboBox1.DisplayMemberPath = "Title";

            if (iWin.ShowDialog() == true)
            {
                Item item = new Item();
                item.Title = iWin.textBox1.Text;
                item.Description = iWin.textBox2.Text;
                item.Link = iWin.textBox3.Text;
                item.PubDate = iWin.textBox4.Text;
                item.Channel = (Channel)iWin.comboBox1.SelectedItem;

                itemRep.Create(item);
                UpdateDB();

                MessageBox.Show("Новая статья добавлена");
            }
            else
            {
                return;
            }
        }

        private void Change_Click(object sender, EventArgs e)
        {
            if (DataGrid1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < DataGrid1.SelectedItems.Count; i++)
                {
                    Item item = DataGrid1.SelectedItems[i] as Item;
                    if (item != null)
                    {
                        ItemWindow iWin = new ItemWindow();

                        iWin.textBox1.Text = item.Title;
                        iWin.textBox2.Text = item.Description;
                        iWin.textBox3.Text = item.Link;
                        iWin.textBox4.Text = item.PubDate;

                        //List<Channel> channels = db.Channels.ToList();

                        //iWin.comboBox1.ItemsSource = db.Channels.Local.ToBindingList();
                        iWin.comboBox1.ItemsSource = chRep.Get();

                        iWin.comboBox1.DisplayMemberPath = "Title";

                        if (item.Channel != null)
                            iWin.comboBox1.SelectedValue = item.Channel.Id;

                        if (iWin.ShowDialog() == true)
                        {
                            item.Title = iWin.textBox1.Text;
                            item.Description = iWin.textBox2.Text;
                            item.Link = iWin.textBox3.Text;
                            item.PubDate = iWin.textBox4.Text;
                            item.Channel = (Channel)iWin.comboBox1.SelectedItem;

                            itemRep.Update(item);
                            UpdateDB();
                            //db.Entry(item).State = EntityState.Modified;
                            //db.SaveChanges();

                            MessageBox.Show("Статья редактирована");
                        }
                        else
                        {
                            return;
                        }
                        //DataGrid1.ItemsSource = null;
                        //DataGrid1.ItemsSource = db.Items.Local.ToBindingList();
                    }
                }
            }
        }
        //обновление данных грида
        private void UpdateDB()
        {
            DataGrid1.ItemsSource = null;
            DataGrid1.ItemsSource = itemRep.Get();
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < DataGrid1.SelectedItems.Count; i++)
                {
                    Item item = DataGrid1.SelectedItems[i] as Item;
                    if (item != null)
                    {
                        itemRep.Remove(item);
                        UpdateDB();

                        //db.Items.Remove(item);
                    }
                }
            }
            //db.SaveChanges();
            MessageBox.Show("Объект удален");
        }

        private void Channels_Click(object sender, RoutedEventArgs e)
        {
            ChannelWindow cWin = new ChannelWindow();
            cWin.Show();
        }
    }
}
