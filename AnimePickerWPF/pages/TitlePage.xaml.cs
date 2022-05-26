using Core;
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
    /// Логика взаимодействия для TitlrPage.xaml
    /// </summary>
    public partial class TitlePage : Page
    {
        private static Title currentTitle {get; set;}
        public TitlePage(Title title)
        {
            InitializeComponent();
            currentTitle = title;

            addComboBox.SelectedIndex = DataManager.GetTitleWithList(currentTitle.id);

            titleName.Text = currentTitle.name;

            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(currentTitle.imageUrl, UriKind.Absolute);
            bitmap.EndInit();
            titleImg.Source =  bitmap;

            titleDescription.Text = currentTitle.description;


            titleTypeTxt.Text = "Тип: " + ((currentTitle.titleType == 1) ? "Манга" : "Аниме");

            titleRateTxt.Text = "Оценка: " + (currentTitle.rating / 10).ToString();
        }

        private void addComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = (sender as ComboBox).SelectedIndex;
            switch (index)
            {
                case 0:
                    DataManager.DeleteTitleFromList(currentTitle);
                    break;
                default:
                    DataManager.AddTitleToList(currentTitle, index);
                    break;
            }
        }
    }
}
