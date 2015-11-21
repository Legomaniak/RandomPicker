using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace RandomPicker
{
    /// <summary>
    /// Interaction logic for MyLabel.xaml
    /// </summary>
    public partial class MyLabel : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public MyLabel()
        {
            InitializeComponent();

            Binding b = new Binding("Text");
            b.Mode = BindingMode.OneWay;
            b.Source = this;
            label.SetBinding(TextBlock.TextProperty, b);
        }
        public string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
                NotifyPropertyChanged("Text");
            }
        }
        string _Text = "";
    }
}
