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
        ChannelContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new ChannelContext();

            db.Items.Load();

            DataGrid1.ItemsSource = db.Items.Local.ToBindingList();

            this.Closing += MainWindow_Closing;

            //using (ChannelContext db = new ChannelContext())
            //{
            //#region try1
            //// создаем два объекта Item
            //Item Item1 = new Item { Title = "test", Link = "test", Description = "test", PubDate = "test" };
            //Item Item2 = new Item { Title = "test2", Link = "test2", Description = "test2", PubDate = "test2" };

            //// добавляем их в бд
            //db.Items.Add(Item1);
            //db.Items.Add(Item2);
            //db.SaveChanges();

            //// получаем объекты из бд и выводим на консоль
            //var Items = db.Items;
            //foreach (Item u in Items)
            //{
            //    textBox1.Text += u.Id + " " + u.Title + " " + u.Link + " " + u.Description + " " + u.PubDate + "\n";
            //}
            //#endregion

            //Channel channel1 = new Channel
            //{
            //    Title = "one",
            //    Description = "one",
            //    Link = "one",
            //    Copyright = "one"
            //};

            //Channel channel2 = new Channel
            //{
            //    Title = "one2",
            //    Description = "one2",
            //    Link = "one2",
            //    Copyright = "one2"
            //};

            //db.Channels.AddRange(new List<Channel> { channel1, channel2 });

            //db.SaveChanges();

            // один к одному
            //ChannelImage ChannelImage1 = new ChannelImage
            //{
            //    Id = channel1.Id,
            //    ImgTitle = "one",
            //    ImgLink = "one",
            //    ImgURL = "one"
            //};

            //ChannelImage ChannelImage2 = new ChannelImage
            //{
            //    Id = channel2.Id,
            //    ImgTitle = "one2",
            //    ImgLink = "one2",
            //    ImgURL = "one2"
            //};

            //db.ChannelImages.AddRange(new List<ChannelImage> { ChannelImage1, ChannelImage2 });
            //db.SaveChanges();

            // вывоооод
            
            //MessageBox.Show("Ok!");
            //    foreach (Channel ch in  db.Channels.Include("ChannelImages").To
            //{
            //    textBox1.Text += u.Id + " " + u.Title + " " + u.Link + " " + u.Description + " " + u.PubDate + "\n";
            //}
            //}
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ItemWindow iWin = new ItemWindow();

            // из команд в бд формируем список
            List<Channel> channels = db.Channels.ToList();

            iWin.comboBox1.ItemsSource = db.Channels.Local.ToBindingList();
            iWin.comboBox1.DisplayMemberPath = "Title";

            //ComboBox.ItemsSource = DS.Tables["TypeUser"].DefaultView;
            //ComboBox.DisplayMemberPath = "Name";

            if (iWin.ShowDialog() == true)
            {
                Item item = new Item();
                item.Title = iWin.textBox1.Text;
                item.Description = iWin.textBox2.Text;
                item.Link = iWin.textBox3.Text;
                item.PubDate = iWin.textBox4.Text;
                item.Channel = (Channel)iWin.comboBox1.SelectedItem;

                db.Items.Add(item);
                db.SaveChanges();

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

                        List<Channel> channels = db.Channels.ToList();

                        iWin.comboBox1.ItemsSource = db.Channels.Local.ToBindingList();
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

                            db.Entry(item).State = EntityState.Modified;
                            db.SaveChanges();

                            MessageBox.Show("Статья редактирована");
                        }
                        else
                        {
                            return;
                        }
                        DataGrid1.ItemsSource = null;
                        DataGrid1.ItemsSource = db.Items.Local.ToBindingList();
                    }
                }
            }
        }
        //обновление данных грида
        private void UpdateDB(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            DataGrid1.ItemsSource = null;
            DataGrid1.ItemsSource = db.Items.Local.ToBindingList();
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
                        db.Items.Remove(item);
                    }
                }
            }
            db.SaveChanges();
            MessageBox.Show("Объект удален");
        }

        private void Channels_Click(object sender, RoutedEventArgs e)
        {
            ChannelWindow cWin = new ChannelWindow();
            cWin.Show();
        }
    }
}
