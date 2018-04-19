using System.Windows;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ChannelWindow.xaml
    /// </summary>
    public partial class ChannelWindow : Window
    {
        ChannelContext db;

        public ChannelWindow()
        {
            InitializeComponent();

            db = new ChannelContext();

            db.Channels.Load();

            DataGrid1.ItemsSource = db.Channels.Local.ToBindingList();

        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ChannelWin cWin = new ChannelWin();

            if (cWin.ShowDialog() == true)
            {
                Channel channel = new Channel();
                channel.Title = cWin.textBox1.Text;
                channel.Description = cWin.textBox2.Text;
                channel.Link = cWin.textBox3.Text;
                channel.Copyright = cWin.textBox4.Text;

                db.Channels.Add(channel);
                db.SaveChanges();

                MessageBox.Show("Новый канал добавлен");
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
                    Channel channel = DataGrid1.SelectedItems[i] as Channel;
                    if (channel != null)
                    {
                        ChannelWin cWin = new ChannelWin();

                        cWin.textBox1.Text = channel.Title;
                        cWin.textBox2.Text = channel.Description;
                        cWin.textBox3.Text = channel.Link;
                        cWin.textBox4.Text = channel.Copyright;

                        if (cWin.ShowDialog() == true)
                        {
                            channel.Title = cWin.textBox1.Text;
                            channel.Description = cWin.textBox2.Text;
                            channel.Link = cWin.textBox3.Text;
                            channel.Copyright = cWin.textBox4.Text;

                            db.Entry(channel).State = EntityState.Modified;
                            db.SaveChanges();

                            MessageBox.Show("Статья редактирована");
                        }
                        else
                        {
                            return;
                        }
                        DataGrid1.ItemsSource = null;

                        DataGrid1.ItemsSource = db.Channels.Local.ToBindingList();

                    }
                }
            }
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < DataGrid1.SelectedItems.Count; i++)
                {
                    Channel channel = DataGrid1.SelectedItems[i] as Channel;
                    if (channel != null)
                    {
                        // db.Database.ExecuteSqlCommand("ALTER TABLE Items ADD CONSTRAINT Items_Channels FOREIGN KEY (ChannelId) REFERENCES Channels (Id) ON DELETE SET NULL");
                        Console.WriteLine("CHANNEL ID " + channel.Id);
                        Console.WriteLine("count items" + db.Items.Count());
                        for (int j = 0; j < db.Items.Count(); j++)
                        {
                            var items = db.Items.Where(p => p.ChannelId == channel.Id);
                            foreach(Item it in items)
                            {
                                it.ChannelId = null;
                            }
                        }
                        db.Channels.Remove(channel);
                        db.SaveChanges();


                    }
                }
            }
            MessageBox.Show("Объект удален");
        }

        private void Items_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < DataGrid1.SelectedItems.Count; i++)
                {
                    Channel channel = DataGrid1.SelectedItems[i] as Channel;
                    if (channel != null)
                    {
                        Label1.Content = "Кол.во статей: " + db.Items.Count(item => item.Channel.Id.Equals(channel.Id)).ToString();
                        //MessageBox.Show(db.Items.Count(item => item.Channel.Title.Equals(channel.Title)).ToString());
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
