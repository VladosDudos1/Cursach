using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Core;

namespace AnimePickerWPF.pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private static List<Title> AnimeList { get; set; }
        private static List<Title> Anime { get; set; }
        private static List<Title> Manga { get; set; }
        public MainPage(int titleType)
        {

            InitializeComponent();

            AnimeList = DataManager.GetTitles();
            Anime = new List<Title>();
            Manga = new List<Title>();

            if (titleType == 2)
            {
                AnimeLv2.Visibility = Visibility.Collapsed;
                cbPick.SelectedIndex = 0;
            }
            else
            {
                AnimeLv.Visibility = Visibility.Collapsed;
                cbPick.SelectedIndex = 1;
            }

                AnimeLv.ItemsSource = Anime;
            AnimeLv2.ItemsSource = Manga;

            foreach (Title i in AnimeList)
            {
                if (i.titleType == 2)
                {
                    Anime.Add(i);
                }
                else if (i.titleType == 1)
                {
                    Manga.Add(i);
                }

            }
            this.DataContext = this;
        }

        private void Cb_Unit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var s = cbPick.Text;

            if (s == "Anime")
            {
              
                AnimeLv.Visibility = Visibility.Collapsed;
                AnimeLv2.Visibility = Visibility.Visible;

            }
            else if(s == "Manga")
            {
                AnimeLv2.Visibility = Visibility.Collapsed;
                AnimeLv.Visibility = Visibility.Visible;
            }
        }

        private void AnimeLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new TitlePage((sender as ListView).SelectedItem as Title));
        }
    }
}
