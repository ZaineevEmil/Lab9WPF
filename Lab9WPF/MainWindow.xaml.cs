using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.MobileControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab9WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }

        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ToggleBoldExecuted(object sender, ExecutedRoutedEventArgs e)//толщина шрифта
        {
            if (textBox.FontWeight.ToString() == "Normal")
            {
                textBox.FontWeight = FontWeight.FromOpenTypeWeight(700);
            }
            else
            {
                textBox.FontWeight = FontWeight.FromOpenTypeWeight(400);
            }
        }

        private void ToggleItalicExecuted(object sender, ExecutedRoutedEventArgs e)//наклон букв
        {
            if (textBox.FontStyle != FontStyles.Italic)
            {
                textBox.FontStyle = FontStyles.Italic;
            }
            else
            {
                textBox.FontStyle = FontStyles.Normal;
            }
        }

        private void ToggleUnderlineExecuted(object sender, ExecutedRoutedEventArgs e)//нижнее подчеркивание
        {
            if (textBox.TextDecorations != TextDecorations.Underline)
            {

                textBox.TextDecorations = TextDecorations.Underline;
            }
            else
            {
                textBox.TextDecorations = null;
            }
        }

        public void ColorExecutedButton()//цвет букв
        {
            if (textBox != null)
            {
                if (radioButtonBlack.Content == "Черный")
                {
                    if (radioButtonBlack.IsChecked == true)
                    {
                        textBox.Foreground = Brushes.Black;
                    }
                    else
                    {
                        textBox.Foreground = Brushes.Red;
                    }
                }
                if (radioButtonBlack.Content == "Белый")
                {
                    if (radioButtonBlack.IsChecked == true)
                    {
                        textBox.Foreground = Brushes.White;
                    }
                    else
                    {
                        textBox.Foreground = Brushes.Red;
                    }
                }
            }
        }


        private void ColorExecuted(object sender, ExecutedRoutedEventArgs e)//цвет букв
        {
            ColorExecutedButton();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = Convert.ToString((sender as ComboBox).SelectedItem);
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.FontSize = Convert.ToDouble((sender as ComboBox).SelectedItem);
            }
        }

        private void styleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int styleIndex = styleBox.SelectedIndex;
            Uri uri = new Uri("Light.xaml", UriKind.Relative);

            if (styleIndex == 0)
            {
                uri = new Uri("Light.xaml", UriKind.Relative);
                radioButtonBlack.Content = "Черный";
            }

            if (styleIndex == 1)
            {
                uri = new Uri("Dark.xaml", UriKind.Relative);
                radioButtonBlack.Content = "Белый";
            }
            ColorExecutedButton();
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }
    }
}
