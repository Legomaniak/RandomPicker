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
using System.Windows.Shapes;

namespace RandomPicker
{
    /// <summary>
    /// Interaction logic for WindowProperities.xaml
    /// </summary>
    public partial class WindowProperities : Window
    {
        public WindowProperities()
        {
            InitializeComponent();
            checkBox.IsChecked = Properties.Settings.Default.timerEnabled;
            checkBox_Copy.IsChecked = Properties.Settings.Default.forgoting;
            textBox.Text = Properties.Settings.Default.startIndex.ToString();
            textBox_Copy1.Text = Properties.Settings.Default.timeVal.ToString();
            textBox_Copy.Text = Properties.Settings.Default.endIndex.ToString();
            textBox_Copy2.Text = Properties.Settings.Default.startIndex2.ToString();
            textBox_Copy3.Text = Properties.Settings.Default.endIndex2.ToString();
            checkBox_text.IsChecked = Properties.Settings.Default.showText;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Properties.Settings.Default.cesta = fbd.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void checkBox_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.timerEnabled = checkBox.IsChecked.Value;
            Properties.Settings.Default.Save();
        }

        private void textBox_Copy1_TextChanged(object sender, TextChangedEventArgs e)
        {
            int val = 0;
            int.TryParse(textBox_Copy1.Text, out val);
            Properties.Settings.Default.timeVal = val;
            Properties.Settings.Default.Save();
        }

        private void textBox_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
            int val = 0;
            int.TryParse(textBox_Copy.Text, out val);
            Properties.Settings.Default.endIndex = val;
            Properties.Settings.Default.Save();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int val = 0;
            int.TryParse(textBox.Text, out val);
            Properties.Settings.Default.startIndex = val;
            Properties.Settings.Default.Save();
        }

        private void checkBox_Copy_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.forgoting = checkBox_Copy.IsChecked.Value;
            Properties.Settings.Default.Save();
        }

        private void textBox_Copy_TextChanged2(object sender, TextChangedEventArgs e)
        {
            int val = 0;
            int.TryParse(textBox_Copy3.Text, out val);
            Properties.Settings.Default.endIndex2 = val;
            Properties.Settings.Default.Save();
        }

        private void textBox_TextChanged2(object sender, TextChangedEventArgs e)
        {
            int val = 0;
            int.TryParse(textBox_Copy2.Text, out val);
            Properties.Settings.Default.startIndex2 = val;
            Properties.Settings.Default.Save();
        }

        private void checkBox_Text_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.showText = checkBox_text.IsChecked.Value;
            Properties.Settings.Default.Save();
        }
    }
}
