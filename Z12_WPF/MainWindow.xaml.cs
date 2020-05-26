using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Z12_WPF
{ 
    public partial class MainWindow : Window
    {
        public Model Model { get; set; } = new Model();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = Model;
        }

        private void grid_Loaded(object sender, RoutedEventArgs e)
        {
            var test = this.FindResource("Title");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["Brush"] = new SolidColorBrush(Colors.DarkMagenta);
            var res = new ResourceDictionary();
            res.Add("test", "test");
            Resources.MergedDictionaries.Add(res);
        }
        private void DynamicLoadStyles()
        {
            string fileName = Environment.CurrentDirectory + @"\Dic3.xaml";
            if (File.Exists(fileName))
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    ResourceDictionary dic = (ResourceDictionary)XamlReader.Load(fs);
                    Resources.MergedDictionaries.Add(dic);
                }
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            DynamicLoadStyles();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Model.Zoom += 10;
        }
    }
}
