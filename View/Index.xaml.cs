using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVMLightDemo.View
{
    /// <summary>
    /// Index.xaml 的交互逻辑
    /// </summary>
    public partial class Index : Window
    {
        public Index()
        {
            InitializeComponent();
        }

        private Assembly _assembly = Assembly.GetExecutingAssembly();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string winName = ((Button)e.OriginalSource).Tag.ToString();
            Window win = ((Window)_assembly.CreateInstance(string.Format("MVVMLightDemo.View.{0}", winName)));
            win.Owner = this;
            win.Show();
        }
    }
}
