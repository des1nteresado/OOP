using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Windows.Resources;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            richtextBox1.AddHandler(RichTextBox.DragOverEvent, new DragEventHandler(RichTextBox_DragOver), true);
            richtextBox1.AddHandler(RichTextBox.DropEvent, new DragEventHandler(RichTextBox_Drop), true);
            
            label2.Content = Text.size;
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
                        range = new TextRange(richtextBox1.Document.ContentStart, richtextBox1.Document.ContentEnd);
                        fStream = new FileStream(docPath[0], FileMode.OpenOrCreate);
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
        public static void GetLength(object obj)
        {
            RichTextBox rtb = (RichTextBox)obj;
            var textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            Text.size = textRange.Text.Length;
        }


        public static class Text
        {
            public static int size;
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
            richtextBox1.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            TimerCallback tm = new TimerCallback(GetLength);
            Timer timer = new Timer(tm, richtextBox1, 0, 2000);
        }

      
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Открыть файл";
            dialog.Filter = "Текстовый файл (*.txt)|*.txt| Все файлы (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                richtextBox1.Document.Blocks.Clear();
                string strfilename = dialog.FileName;
                using (StreamReader sr = new StreamReader(strfilename, Encoding.Default))
                {
                    string filetext = sr.ReadToEnd();
                    richtextBox1.AppendText(filetext);
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
                    string richText = new TextRange(richtextBox1.Document.ContentStart, richtextBox1.Document.ContentEnd).Text;
                    sw.Write(richText);
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
                richtextBox1.Document.Blocks.Clear();
        }
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            Save_Click(sender, e);

            PrintDialog dialog = new PrintDialog();
            if(dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(richtextBox1 as Visual, "Распечатываемый элемент блокнота");
            }
        }
        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            richtextBox1.Undo();
        }
        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            richtextBox1.Redo();
        }
        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            richtextBox1.Cut();
        }
        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            richtextBox1.Copy();
        }
        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            richtextBox1.Paste();
        }
        private void Time_Click(object sender, RoutedEventArgs e)
        {
            richtextBox1.AppendText(DateTime.Now.ToString());
        }
        private void Color_Click(object sender, RoutedEventArgs e)
        {
        }

        public void ApplySelection(DependencyProperty property, object value)
        {
            if(value != null)
            {
                richtextBox1.Selection.ApplyPropertyValue(property, value);
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
            string str = "Кол.во символов: " + (GetLength(richtextBox1) - 1).ToString();
            label2.Content = str;
        }
    }
}
