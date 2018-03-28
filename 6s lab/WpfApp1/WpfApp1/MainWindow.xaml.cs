using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Windows.Resources;
using System.Globalization;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TabItem> _tabItems;
        private TabItem _tabAdd;
        List<RichTextBox> riches = new List<RichTextBox>();

        int u = 0;
        int slct;

        public MainWindow()
        {
            InitializeComponent();

            App.LanguageChanged += LanguageChanged;

            CultureInfo currLang = App.Language;
            List<string> styles = new List<string> { "light", "dark" };
            styleBox.SelectionChanged += ThemeChange;
            styleBox.ItemsSource = styles;
            styleBox.SelectedItem = "light";
            styleCheck.Click += SizeChange;
            //Заполняем меню смены языка:
            menuLanguage.Items.Clear();
            foreach (var lang in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Style = this.Resources["DarkROse"] as Style; //разобраться
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currLang);
                menuLang.Click += ChangeLanguageClick;
                menuLanguage.Items.Add(menuLang);
            }

            // initialize tabItem array
            _tabItems = new List<TabItem>();

            // add a tabItem with + in header 
            _tabAdd = new TabItem();
            _tabAdd.Header = "+";
            // tabAdd.MouseLeftButtonUp += new MouseButtonEventHandler(tabAdd_MouseLeftButtonUp);

            _tabItems.Add(_tabAdd);

            // add first tab
            this.AddTabItem();

            // bind tab control
            tabDynamic.DataContext = _tabItems;

            tabDynamic.SelectedIndex = 0;
            RecentFileList.MenuClick += (s, e) => FileOpenCore(e.Filepath);
            
        }

        private void SizeChange(object sender, RoutedEventArgs e)
        {
            if(styleCheck.IsChecked == true)
            {
                RowDef1.Height = new GridLength(30);
                Menu.FontSize = 20;
                RowDef2.Height = new GridLength(55);
                ToolBar1.Height = 40;
                But1.Style = this.Resources["bigButton"] as Style;
                But2.Style = this.Resources["bigButton"] as Style;
                But3.Style = this.Resources["bigButton"] as Style;
                But4.Style = this.Resources["bigButton"] as Style;
                But5.Style = this.Resources["bigButton"] as Style;
                ToolBar2.Height = 40;
                ToolBar2.FontSize = 22;
                ToolBar3.Height = 40;
                fonts.Height = 28;
                fonts.FontSize = 20;
                fontSize.Height = 28;
                fontSize.FontSize = 20;
                fontColor.Height = 28;
                fontColor.FontSize = 20;
                fontColor2.Height = 28;
                fontColor2.FontSize = 20;
                styleBox.Height = 28;
                styleBox.FontSize = 20;
                label2.Height = 37;
                label2.FontSize = 20;
                //как задать всем кнопкам один стиль
            }
            else
            {
                RowDef1.Height = new GridLength(20);
                Menu.FontSize = 12;
                RowDef2.Height = new GridLength(40);
                ToolBar1.Height = 30;
                ToolBar2.Height = 30;
                ToolBar3.Height = 30;
                But1.Style = this.Resources["smallButton"] as Style;
                But2.Style = this.Resources["smallButton"] as Style;
                But3.Style = this.Resources["smallButton"] as Style;
                But4.Style = this.Resources["smallButton"] as Style;
                But5.Style = this.Resources["smallButton"] as Style;
                ToolBar2.FontSize = 16;
                fonts.Height = 20;
                fonts.FontSize = 12;
                fontSize.Height = 20;
                fontSize.FontSize = 12;
                fontColor.Height = 20;
                fontColor.FontSize = 12;
                fontColor2.Height = 20;
                fontColor2.FontSize = 12;
                styleBox.Height = 20;
                styleBox.FontSize = 12;
                label2.Height = 25;
                label2.FontSize = 12;

            }
        }
        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = styleBox.SelectedItem as string;
            // определяем путь к файлу ресурсов
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

        }

        bool FileOpenCore(string filepath)
        {
                RecentFileList.InsertFile(filepath);
            return true;
        }



        private TabItem AddTabItem()
        {
            int count = _tabItems.Count;

            // create new tab item
            TabItem tab = new TabItem();

            tab.Header = string.Format("Tab {0}", count);
            tab.Name = string.Format("tab{0}", count);
            tab.HeaderTemplate = tabDynamic.FindResource("TabHeader") as DataTemplate;


            // add controls to tab item, this case I added just a textbox

            //<RichTextBox x:Name="richtextBox1" PreviewKeyDown="richtextBox1_PreviewKeyDown" AllowDrop="True" Block.LineStackingStrategy="BlockLineHeight"/>

            RichTextBox rich = new RichTextBox();
            rich.PreviewKeyDown += richtextBox1_PreviewKeyDown;
            rich.AllowDrop = true;
            rich.AddHandler(RichTextBox.DragOverEvent, new DragEventHandler(RichTextBox_DragOver), true);
            rich.AddHandler(RichTextBox.DropEvent, new DragEventHandler(RichTextBox_Drop), true);
            rich.Name = "richtextBox1";
            rich.PreviewKeyDown += richtextBox1_PreviewKeyDown;
            rich.AllowDrop = true;
            rich.Document.Blocks.Clear();
            riches.Add(rich);
            tab.Content = riches[u];
            u++;

            //TextBox txt = new TextBox();
            //txt.Name = "txt";

            //tab.Content = txt;

            // insert tab item right before the last (+) tab item
            _tabItems.Insert(count - 1, tab);

            return tab;
        }

        private void tabAdd_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // clear tab control binding
            tabDynamic.DataContext = null;

            TabItem tab = this.AddTabItem();

            // bind tab control
            tabDynamic.DataContext = _tabItems;

            // select newly added tab item
            tabDynamic.SelectedItem = tab;
        }


        private void tabDynamic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem tab = tabDynamic.SelectedItem as TabItem;
            slct = _tabItems.IndexOf(tab);
            if (tab == null) return;

            if (tab.Equals(_tabAdd))
            {
                // clear tab control binding
                tabDynamic.DataContext = null;

                TabItem newTab = this.AddTabItem();

                // bind tab control
                tabDynamic.DataContext = _tabItems;

                // select newly added tab item
                tabDynamic.SelectedItem = newTab;
            }
            else
            {
                // your code here...
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string tabName = (sender as Button).CommandParameter.ToString();

            var item = tabDynamic.Items.Cast<TabItem>().Where(i => i.Name.Equals(tabName)).SingleOrDefault();

            TabItem tab = item as TabItem;

            if (tab != null)
            {
                if (_tabItems.Count < 3)
                {
                    MessageBox.Show("Cannot remove last tab.");
                }
                else if (MessageBox.Show(string.Format("Сохранить текущий файл?", "Сохранение"),
                    "Сохранение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)

                {
                        Save_Click(sender, e);
                    // get selected tab
                    TabItem selectedTab = tabDynamic.SelectedItem as TabItem;

                    // clear tab control binding
                    tabDynamic.DataContext = null;

                    _tabItems.Remove(tab);

                    // bind tab control
                    tabDynamic.DataContext = _tabItems;

                    // select previously selected tab. if that is removed then select first tab
                    if (selectedTab == null || selectedTab.Equals(tab))
                    {
                        selectedTab = _tabItems[0];
                    }
                    tabDynamic.SelectedItem = selectedTab;
                }
                else
                {
                    // get selected tab
                    TabItem selectedTab = tabDynamic.SelectedItem as TabItem;

                    // clear tab control binding
                    tabDynamic.DataContext = null;

                    _tabItems.Remove(tab);

                    // bind tab control
                    tabDynamic.DataContext = _tabItems;

                    // select previously selected tab. if that is removed then select first tab
                    if (selectedTab == null || selectedTab.Equals(tab))
                    {
                        selectedTab = _tabItems[0];
                    }
                    tabDynamic.SelectedItem = selectedTab;
                }
            }
        }

        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (MenuItem i in menuLanguage.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
        }

        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
            }

        }

        private void RichTextBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.All;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = false;
        }

        

        private void RichTextBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] docPath = (string[])e.Data.GetData(DataFormats.FileDrop);

                // By default, open as Rich Text (RTF).
                var dataFormat = DataFormats.Rtf;

                // If the Shift key is pressed, open as plain text.
                if (e.KeyStates == DragDropKeyStates.ShiftKey)
                {
                    dataFormat = DataFormats.Text;
                }

                TextRange range;
                FileStream fStream;
                if (File.Exists(docPath[0]))
                {
                    try
                    {
                        // Open the document in the RichTextBox.
                        range = new TextRange(riches[slct].Document.ContentStart, riches[slct].Document.ContentEnd);
                        fStream = new FileStream(docPath[0], FileMode.OpenOrCreate);
                        FileOpenCore(docPath[0]);
                        range.Load(fStream, dataFormat);
                        fStream.Close();
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("File could not be opened. Make sure the file is a text file.");
                    }
                }
            }
        }

        private void TextEditLoad(object sender, RoutedEventArgs e)
        {
            for(double i = 7; i<49; i+=2)
            {
                fontSize.Items.Add(i);
            }

            fontColor.Items.Add("Black");
            fontColor.Items.Add("Red");
            fontColor.Items.Add("Green");
            fontColor.Items.Add("Blue");
            fontColor.Items.Add("Yellow");
            fontColor.Items.Add("Violet");
            fontColor.Items.Add("Pink");
            fontColor.Items.Add("Gold");

            fontColor2.Items.Add("Black");
            fontColor2.Items.Add("Red");
            fontColor2.Items.Add("Green");
            fontColor2.Items.Add("Blue");
            fontColor2.Items.Add("Yellow");
            fontColor2.Items.Add("Violet");
            fontColor2.Items.Add("Pink");
            fontColor2.Items.Add("Gold");
            StreamResourceInfo sri = Application.GetResourceStream(
            new Uri("Normal Select.ani", UriKind.Relative));
            Cursor customCursor = new Cursor(sri.Stream);
            this.Cursor = customCursor;
            riches[slct].VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
         
        }

      
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Сохранить текущий файл?", "Сохранение", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Save_Click(sender, e);
            }
            OpenFileDialog dialog = new OpenFileDialog(); //DynamicResource m_menu_file_Open
            dialog.Title = "Открыть файл";
            dialog.Filter = "Текстовый файл (*.txt)|*.txt| Все файлы (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                riches[slct].Document.Blocks.Clear();
                string strfilename = dialog.FileName;
                using (StreamReader sr = new StreamReader(strfilename, Encoding.Default))
                {
                    string filetext = sr.ReadToEnd();
                    riches[slct].AppendText(filetext);
                    FileOpenCore(strfilename);
                }
            }
        }
        
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Сохранить файл";
            dialog.Filter = "Текстовый файл (*.txt)|*.txt| Все файлы (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(dialog.FileName, true, Encoding.Default))
                {
                    string richText = new TextRange(riches[slct].Document.ContentStart, riches[slct].Document.ContentEnd).Text;
                    sw.Write(richText);
                    FileOpenCore(dialog.FileName);
                }
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application app = Application.Current;
            app.Shutdown();
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Сохранить текущий файл?", "Сохранение", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                Save_Click(sender, e);
            }
            riches[slct].Document.Blocks.Clear();
        }
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            Save_Click(sender, e);

            PrintDialog dialog = new PrintDialog();
            if(dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(riches[slct] as Visual, "Распечатываемый элемент блокнота");
            }
        }
        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            riches[slct].Undo();
        }
        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            riches[slct].Redo();
        }
        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            riches[slct].Cut();
        }
        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            riches[slct].Copy();
        }
        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            riches[slct].Paste();
        }
        private void Time_Click(object sender, RoutedEventArgs e)
        {
            riches[slct].AppendText(DateTime.Now.ToString());
        }
        private void Color_Click(object sender, RoutedEventArgs e)
        {
        }

        public void ApplySelection(DependencyProperty property, object value)
        {
            if(value != null)
            {
                riches[slct].Selection.ApplyPropertyValue(property, value);
            }
        }
        private void ToolBar_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox source = e.OriginalSource as ComboBox;
            if (source == null) return;

            switch (source.Name)
            {
                case "fonts":
                    ApplySelection(TextBlock.FontFamilyProperty, source.SelectedItem);
                    break;
                case "fontSize":
                    ApplySelection(TextBlock.FontSizeProperty, source.SelectedItem);
                    break;
                case "fontColor":
                    ApplySelection(TextBlock.ForegroundProperty, source.SelectedItem);
                    break;
                case "fontColor2":
                    ApplySelection(TextBlock.BackgroundProperty, source.SelectedItem);
                    break;
            }
        }

        int GetLength(RichTextBox rtb)
        {
            var textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);

            return textRange.Text.Length;
        }

        private void richtextBox1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            string str = (GetLength(riches[slct]) - 1).ToString();
            label2.Content = str;
        }






        //const string NoFile = "No file";
        //const string NewFile = "New nameless file";

        //public static DependencyProperty FilepathProperty =
        //    DependencyProperty.Register(
        //    "Filepath",
        //    typeof(string),
        //    typeof(MainWindow),
        //    new PropertyMetadata(NoFile));
        //public string Filepath
        //{
        //    get { return (string)GetValue(FilepathProperty); }
        //    set { SetValue(FilepathProperty, value); }
        //}

        //bool _IsFileNamed = false;
        //bool _IsFileLoaded = false;
        //MemoryStream _MemoryStream = new MemoryStream();

        //void AddCommandBindings()
        //{
        //    CommandBindings.Add(new CommandBinding(ApplicationCommands.New, (target, e) => FileNew()));
        //    CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, (target, e) => FileOpen()));
        //    CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, (target, e) => FileSave(), (s, e) => e.CanExecute = _IsFileLoaded));
        //    CommandBindings.Add(new CommandBinding(ApplicationCommands.SaveAs, (target, e) => FileSaveAs(), (s, e) => e.CanExecute = _IsFileLoaded));
        //    CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, (target, e) => FileClose(), (s, e) => e.CanExecute = _IsFileLoaded));
        //}

        //private void Exit(object sender, RoutedEventArgs e)
        //{
        //    Close();
        //}

        //void FileNew()
        //{
        //    Filepath = NewFile;

        //    _IsFileLoaded = true;
        //    _IsFileNamed = false;
        //}

        //bool FileOpen()
        //{
        //    OpenFileDialog dlg = new OpenFileDialog();
        //    dlg.Filter = "All Files ( *.* )|*.*";
        //    if (true != dlg.ShowDialog(this)) return false;
        //    return FileOpenCore(dlg.FileName);
        //}

        //bool FileSave()
        //{
        //    if (!_IsFileLoaded) return false;
        //    if (!_IsFileNamed) return FileSaveAs();

        //    return FileSaveCore(Filepath);
        //}

        //bool FileSaveAs()
        //{
        //    if (!_IsFileLoaded) return false;

        //    SaveFileDialog dlg = new SaveFileDialog();
        //    dlg.Filter = "All Files [ *.* ]|*.*";
        //    dlg.FileName = _IsFileNamed ? Filepath :
        //        Path.Combine(
        //            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        //            "NewFile.extension");
        //    if (true != dlg.ShowDialog(this)) return false;
        //    return FileSaveCore(dlg.FileName);
        //}

        //void FileClose()
        //{
        //    _IsFileLoaded = false;
        //    _IsFileNamed = false;
        //    Filepath = NoFile;
        //}

        //bool FileOpenCore(string filepath)
        //{
        //    FileDi
        //    FileDialog dlg = new FileDialog();
        //    dlg.Title = "Open file";
        //    dlg.Filepath = filepath;
        //    dlg.Question = "Did the open file operation succeed?";
        //    if (true != dlg.ShowDialog()) return false;

        //    if (dlg.Result == FileDialog.FileDialogResult.Yes)
        //    {
        //        RecentFileList.InsertFile(filepath);
        //        Filepath = filepath;
        //        _IsFileLoaded = true;
        //        _IsFileNamed = true;
        //        return true;
        //    }

        //    if (MessageBoxResult.Yes == MessageBox.Show("Do you want to remove this file from the recent file list?", "Failed to open file", MessageBoxButton.YesNo, MessageBoxImage.Question))
        //        RecentFileList.RemoveFile(filepath);

        //    return false;
        //}

        //bool FileSaveCore(string filepath)
        //{
        //    FileDialog dlg = new FileDialog();
        //    dlg.Title = "Save file";
        //    dlg.Filepath = filepath;
        //    dlg.Question = "Did the save file operation succeed?";
        //    if (true != dlg.ShowDialog()) return false;

        //    if (dlg.Result == FileDialog.FileDialogResult.Yes)
        //    {
        //        RecentFileList.InsertFile(filepath);
        //        Filepath = filepath;
        //        _IsFileNamed = true;
        //        return true;
        //    }

        //    return false;
        //}
    }
}

