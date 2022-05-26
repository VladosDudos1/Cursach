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

namespace AnimePickerWPF.pages
{
    /// <summary>
    /// Логика взаимодействия для ChoosePage.xaml
    /// </summary>
    public partial class ChoosePage : Page
    {
        public ChoosePage()
        {
            InitializeComponent();

        }
   
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainPage(2));
        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainPage(1));

        }
    }
}
