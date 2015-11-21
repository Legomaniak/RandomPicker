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
    /// Interaction logic for MyImage.xaml
    /// </summary>
    public partial class MyImage : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public MyImage()
        {
            InitializeComponent();

            Binding b = new Binding("Obrazek");
            b.Mode = BindingMode.OneWay;
            b.Source = this;
            image.SetBinding(Image.SourceProperty, b);
        }
        public BitmapImage Obrazek
        {
            get { return _Obrazek; }
            set
            {
                _Obrazek = value;
                NotifyPropertyChanged("Obrazek");
            }
        }
        BitmapImage _Obrazek = null;
    }

}
